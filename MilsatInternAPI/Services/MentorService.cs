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
                        Email = mentor.Email, FirstName = mentor.FirstName,
                        PhoneNumber = mentor.PhoneNumber,
                        LastName = mentor.LastName, Department = mentor.Department
                    };
                    newUser = _authService.RegisterPassword(newUser, mentor.PhoneNumber);
                    await _userRepo.AddAsync(newUser);
                    var singleMentor = new Mentor { UserId = newUser.UserId, Interns = new List<Intern>()};
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
                var pagedData = await _mentorRepo.GetAll().Include(x => x.User)
                                                      .Include(x => x.Interns)
                                                        .ThenInclude(x => x.User)
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
                                                       .Where(x => x.MentorId == vm.id)
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
                        .Where(x => x.User.FirstName.Contains(vm.name) || x.User.LastName.Contains(vm.name))
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
                    .Where(x => x.MentorId.ToString() == vm.MentorId)
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
                    MentorId = mentor.MentorId,
                    FirstName = mentor.User.FirstName,
                    LastName = mentor.User.LastName,
                    Department = mentor.User.Department,
                    Interns = new List<MentorInternDTO>()
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
                var interns = AssignedIntern(mentor);
                mentors.Add(new MentorResponseDTO
                {
                    MentorId = mentor.MentorId,
                    FirstName = mentor.User.FirstName,
                    LastName = mentor.User.LastName,
                    Department = mentor.User.Department,
                    Interns = interns
                });
            };
            return mentors;
        }

        public static List<MentorInternDTO> AssignedIntern(Mentor mentor)
        {
            List<MentorInternDTO> interns = new List<MentorInternDTO>();
            foreach (var intern in mentor.Interns)
            {
                interns.Add(new MentorInternDTO
                {
                    InternId = intern.InternId,
                    Name = $"{intern.User?.FirstName} {intern.User?.LastName}",
                });
            }
            return interns;
        }
    }
}
