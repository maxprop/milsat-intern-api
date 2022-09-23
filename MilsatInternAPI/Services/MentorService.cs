using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Enums;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Mentors;
using Newtonsoft.Json;

namespace MilsatInternAPI.Services
{
    public class MentorService : IMentorService
    {
        private readonly ILogger<MentorService> _logger;
        private readonly IAsyncRepository<User> _userRepo;
        private readonly IAsyncRepository<Mentor> _mentorRepo;
        private readonly IAuthentication _authService;
        public MentorService(IAsyncRepository<Mentor> mentorRepo,
            ILogger<MentorService> logger, IAuthentication authService,
            IAsyncRepository<User> userRepo)
        {
            _mentorRepo = mentorRepo;
            _logger = logger;
            _authService = authService;
            _userRepo = userRepo;
        }

        public async Task<GenericResponse<List<MentorResponseDTO>>> AddMentor(List<CreateMentorVm> vm)
        {
            _logger.LogInformation($"Received a request to add new Mentor(s): Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var mentors = new List<Mentor>();
                foreach (CreateMentorVm mentor in vm)
                {
                    var user = await _userRepo.GetAll().Where(x => x.Email == mentor.Email).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        return new GenericResponse<List<MentorResponseDTO>>
                        {
                            Successful = false,
                            ResponseCode = ResponseCode.INVALID_REQUEST,
                            Message = "User with this Email already exists"
                        };
                    }
                    var newUser = new User { 
                        Email = mentor.Email, Role = RoleType.Mentor,
                        FullName = mentor.FullName, Gender = mentor.Gender,
                        PhoneNumber = mentor.PhoneNumber, Department = mentor.Department
                    };
                    newUser = _authService.RegisterPassword(newUser, mentor.PhoneNumber);
                    await _userRepo.AddAsync(newUser);
                    var singleMentor = new Mentor { UserId = newUser.UserId, Interns = new List<Intern>() };
                    singleMentor.UserId = newUser.UserId;
                    mentors.Add(singleMentor);
                }
                await _mentorRepo.AddRangeAsync(mentors);

                //Crete response body
                var newMentors = MentorResponseData(mentors);
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = newMentors
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Creating Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<MentorResponseDTO>>> GetAllMentors(int pageNumber, int pageSize)
        {
            try
            {
                var pagedData = await _userRepo.GetAll().Include(x => x.Mentor).ThenInclude(x => x.Interns)
                                                      .Where(x => x.Role == RoleType.Mentor)
                                                      .Skip((pageNumber - 1) * pageSize)
                                                      .Take(pageSize).ToListAsync();
                var collectedMentors = MentorResponseData(pagedData);
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = collectedMentors
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<MentorResponseDTO>>> GetMentors(GetMentorVm vm)
        {
            _logger.LogInformation($"Received a request to Fetch Intern(s): Request:{JsonConvert.SerializeObject(vm)}");
            if (vm.id == null && vm.name == null && vm.department == null)
            {
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.NotFound
                };
            }

            try
            {
                if (vm.id != null) {
                    var mentor = await _mentorRepo.GetAll().Include(mentor => mentor.Interns)
                                                       .Where(x => x.UserId == vm.id)
                                                       .FirstOrDefaultAsync();

                    if (mentor == null)
                    {
                        _logger.LogInformation($"Invalid ID Received: Request:{JsonConvert.SerializeObject(vm)}");
                        return new GenericResponse<List<MentorResponseDTO>>
                        {
                            Successful = false,
                            ResponseCode = ResponseCode.NotFound
                        };
                    }

                    var collectedMentor = MentorResponseData(new List<Mentor> { mentor });
                    return new GenericResponse<List<MentorResponseDTO>>
                    {
                        Successful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedMentor
                    };
                }
                else if (vm.name != null && vm.department == null)
                {
                    var interns = await _mentorRepo.GetAll()
                        .Include(x => x.Interns)
                        .Where(x => x.User.FullName.Contains(vm.name))
                        .ToListAsync();
                    var collectedInterns = MentorResponseData(interns);
                    return new GenericResponse<List<MentorResponseDTO>>
                    {
                        Successful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedInterns
                    };
                }
                else
                {
                    var interns = await _mentorRepo.GetAll().Include(x => x.Interns).Where(x => x.User.Department == vm.department).ToListAsync();

                    var collectedInterns = MentorResponseData(interns);
                    return new GenericResponse<List<MentorResponseDTO>>
                    {
                        Successful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = collectedInterns
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<MentorResponseDTO>> UpdateMentor(UpdateMentorVm vm)
        {
            _logger.LogInformation($"Received a request to update Mentor: Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var mentor = await _mentorRepo.GetAll()
                    .Include(x => x.Interns)
                    .Where(x => x.UserId.ToString() == vm.MentorId)
                    .FirstOrDefaultAsync();

                if (mentor == null)
                {
                    return new GenericResponse<MentorResponseDTO>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }
                if (vm.Department != mentor.User.Department)
                {
                    mentor.User.Department = vm.Department;
                    foreach (var intern in mentor.Interns)
                    {
                        intern.Mentor = null;
                    }
                    //mentor.Interns = new List<Intern> { };

                    await _mentorRepo.UpdateAsync(mentor);
                }

                var updatedIntern = new MentorResponseDTO
                {
                    UserId = mentor.UserId,
                    FullName = mentor.User.FullName,
                    Department = mentor.User.Department,
                    InternUserIDs = new List<Guid>()
                };
                return new GenericResponse<MentorResponseDTO>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = updatedIntern
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<MentorResponseDTO>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public static List<MentorResponseDTO> MentorResponseData(List<Mentor> source)
        {
            List<MentorResponseDTO> mentors = new();
            foreach (var mentor in source)
            {
                var interns = AssignedIntern(mentor.Interns);
                mentors.Add(new MentorResponseDTO
                {
                    UserId = mentor.UserId,
                    Email = mentor.User.Email,
                    FullName = mentor.User.FullName,
                    PhoneNumber = mentor.User.PhoneNumber,
                    Department = mentor.User.Department,
                    Gender = mentor.User.Gender,
                    Bio = mentor.User.Bio,
                    ProfilePicture = mentor.User.ProfilePicture,
                    InternUserIDs = interns
                });
            };
            return mentors;
        }

        public static List<MentorResponseDTO> MentorResponseData(List<User> source)
        {
            List<MentorResponseDTO> mentors = new();
            foreach (var mentor in source)
            {
                var interns = AssignedIntern(mentor.Mentor.Interns);
                mentors.Add(new MentorResponseDTO
                {
                    UserId = mentor.UserId,
                    Email = mentor.Email,
                    FullName = mentor.FullName,
                    PhoneNumber = mentor.PhoneNumber,
                    Department = mentor.Department,
                    Gender = mentor.Gender,
                    Bio = mentor.Bio,
                    ProfilePicture = mentor.ProfilePicture,
                    InternUserIDs = interns
                });
            };
            return mentors;
        }

        public static List<Guid> AssignedIntern(List<Intern> interns)
        {
            List<Guid> internIDs = new();
            foreach (var intern in interns)
            {
                internIDs.Add(intern.UserId );
            }
            return internIDs;
        }
    }
}
