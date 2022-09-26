using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Enums;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Mentors;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MilsatInternAPI.Services
{
    public class MentorService : IMentorService
    {
        private readonly ILogger<MentorService> _logger;
        private readonly IAsyncRepository<User> _userRepo;
        private readonly IAsyncRepository<Mentor> _mentorRepo;
        private readonly IAuthentication _authService;
        private readonly IHttpContextAccessor _httpContext;
        public MentorService(IAsyncRepository<Mentor> mentorRepo,
            ILogger<MentorService> logger, IAuthentication authService,
            IAsyncRepository<User> userRepo, IHttpContextAccessor httpContext)
        {
            _mentorRepo = mentorRepo;
            _logger = logger;
            _authService = authService;
            _userRepo = userRepo;
            _httpContext = httpContext;
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
            _logger.LogInformation($"Received a request to fetch all mentors with : Pagination - (pageNumber):{pageNumber}, (pageSize):{pageSize}");
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

        public async Task<GenericResponse<List<MentorResponseDTO>>> GetMentorById(Guid id)
        {
            _logger.LogInformation($"Received a request to fetch a Mentor: Request(user id):{id}");
            try
            {
                var user = await _userRepo.GetAll()
                   .Include(x => x.Mentor).ThenInclude(x => x.Interns)
                   .Where(x => x.UserId == id).SingleOrDefaultAsync();

                if (user == null)
                {
                    return new GenericResponse<List<MentorResponseDTO>>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = MentorResponseData(new List<User> { user })
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

        public async Task<GenericResponse<List<MentorResponseDTO>>> GetMentors(GetMentorVm vm, int pageNumber, int pageSize)
        {
            try
            {
                _logger.LogInformation($"Received a request to Fetch Intern(s): Request:{JsonConvert.SerializeObject(vm)}");
                var filtered = await _userRepo.GetAll().Include(e => e.Mentor).ThenInclude(e => e.Interns)
                                                     .Where(x => x.Role == RoleType.Mentor &&
                                                            (vm.name == null || x.FullName.Contains(vm.name)
                                                            && vm.department == null || x.Department == vm.department))
                                                     .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                var users = MentorResponseData(filtered);
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = users
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

        public async Task<GenericResponse<List<MentorResponseDTO>>> UpdateMentor(UpdateMentorVm vm)
        {
            _logger.LogInformation($"Received a request to update Mentor: Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var mentor = await _userRepo.GetAll()
                    .Include(x => x.Mentor).ThenInclude(x => x.Interns)
                    .Where(x => x.UserId.ToString() == vm.MentorId)
                    .FirstOrDefaultAsync();

                if (mentor == null)
                {
                    return new GenericResponse<List<MentorResponseDTO>>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound,
                        Message = "User not found"
                    };
                }
                if (vm.Department != mentor.Department)
                {
                    mentor.Mentor.Interns = new List<Intern> { };

                    await _userRepo.UpdateAsync(mentor);
                }

                var updatedIntern = MentorResponseData(new List<User> { mentor });
                return new GenericResponse<List<MentorResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = updatedIntern
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<MentorResponseDTO>>
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
