using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Common;
using MilsatInternAPI.Data;
using MilsatInternAPI.Enums;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Interns;
using Newtonsoft.Json;

namespace MilsatInternAPI.Services
{
    public class InternService : IInternService
    {
        private readonly IAsyncRepository<Intern> _internRepo;
        private readonly IAsyncRepository<Mentor> _mentorRepo;
        private readonly IAsyncRepository<User> _userRepo;
        private readonly IAuthentication _authService;
        private readonly ILogger<InternService> _logger;
        private readonly IConfiguration _iconfig;
        public InternService(IAsyncRepository<Intern> internRepo, IAsyncRepository<Mentor> mentorRepo,
            ILogger<InternService> logger, IAuthentication authService, IAsyncRepository<User> userRepo,
            IConfiguration iconfig)
        {
            _internRepo = internRepo;
            _mentorRepo = mentorRepo;
            _userRepo = userRepo;
            _logger = logger;
            _authService = authService;
            _iconfig = iconfig;
        }

        public async Task<GenericResponse<List<InternResponseDTO>>> AddIntern(CreateInternDTO request)
        {
            _logger.LogInformation($"Received a request to add new Intern(s): Request:{JsonConvert.SerializeObject(request)}");
            try
            {
                var user = await _userRepo.GetAll().Where(x => x.Email == request.Email).FirstOrDefaultAsync();
                if (user != null)
                {
                    return new GenericResponse<List<InternResponseDTO>>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.INVALID_REQUEST,
                        Message = "User with this Email already exists"
                    };
                }

                var newUser = new User {
                    Email = request.Email, Role = RoleType.Intern,
                    FullName = request.FullName, Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber, Department = request.Department
                };
                newUser = _authService.RegisterPassword(newUser, request.PhoneNumber);

                var newIntern = new Intern 
                { 
                    UserId = newUser.UserId,
                    CourseOfStudy = request.CourseOfStudy,
                    Institution = request.Institution,
                };

                if (request.MentorId != null)
                {
                    Mentor selectedMentor = await _mentorRepo.GetAll().Include(x => x.User).SingleAsync(x => x.UserId == request.MentorId);
                    if (selectedMentor != null && selectedMentor.User.Department == newUser.Department)
                    {
                        newIntern.MentorId = selectedMentor.UserId;
                    }
                }
                else
                {
                    newIntern.MentorId = null;
                }
                await _userRepo.AddAsync(newUser);
                newIntern.UserId = newUser.UserId;
                await _internRepo.AddAsync(newIntern);

                //Crete response body
                var newInterns = InternResponseData(new List<User> { newUser });
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = newInterns
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Creating Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                { 
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<InternResponseDTO>>> GetAllInterns(int pageNumber, int pageSize)
        {
            _logger.LogInformation($"Received a request to fetch paginated Intern(s): Request: pageNumber:{pageNumber}, pageSize:{pageSize}");
            try
            {
                var pagedData = await _userRepo.GetAll()
                    .Include(x => x.Intern)
                    .Where(x => x.Role == RoleType.Intern)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var interns = InternResponseData(pagedData);
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = interns
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<InternResponseDTO>>> GetInternById(Guid id)
        {
            _logger.LogInformation($"Received a request to fetch an Intern: Request(user id):{id}");
            try
            {
                var user = await _userRepo.GetAll()
                    .Include(x => x.Intern)
                    .Where(x => x.UserId == id).SingleOrDefaultAsync();
                if (user == null)
                {
                    return new GenericResponse<List<InternResponseDTO>>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = InternResponseData(new List<User> { user })
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Fetching Intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }

        }

        public async Task<GenericResponse<List<InternResponseDTO>>> FilterInterns(GetInternVm vm, int pageNumber, int pageSize)
        {
            _logger.LogInformation($"Received a request to Fetch Intern(s): Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var filtered = await _userRepo.GetAll().Include(e => e.Intern)
                                                 .Where(x => x.Role == RoleType.Intern &&
                                                        (vm.name == null || x.FullName.Contains(vm.name)
                                                        && vm.department == null || x.Department == vm.department))
                                                 .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                var users = InternResponseData(filtered);
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = users
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }


        public async Task<GenericResponse<List<InternResponseDTO>>> UpdateIntern(UpdateInternVm vm)
        {
            _logger.LogInformation($"Received a request to update Intern: Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var user = await _userRepo.GetAll()
                    .Include(x => x.Intern)
                    .Where(x => x.UserId == vm.UserId)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return new GenericResponse<List<InternResponseDTO>>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }

                user.Department = vm.Department;
                user.FullName = vm.FullName;
                user.Email = vm.Email;
                user.PhoneNumber = vm.PhoneNumber;

                if (vm.MentorId != null)
                {
                    var selectedMentor = await _userRepo.GetAll().Where(x => x.UserId == vm.MentorId
                                                                        && x.Department == vm.Department
                                                                        && x.Role == RoleType.Mentor)
                                                                        .FirstOrDefaultAsync();
                    if (selectedMentor != null)
                    {
                        user.Intern.MentorId = selectedMentor.UserId;
                    }
                }
                else
                {
                    user.Intern.MentorId = null;
                }

                await _userRepo.UpdateAsync(user);
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = InternResponseData(new List<User> { user })
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating intern. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<InternResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public List<InternResponseDTO> InternResponseData(List<User> source)
        {
            List<InternResponseDTO> interns = new();
            foreach (var user in source)
            {
                string profilePicture = Utils.GetUserPicture(_iconfig["ProfilePicturesPath"], user.ProfilePicture);
                interns.Add(new InternResponseDTO
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    Department = user.Department,
                    CourseOfStudy = user.Intern.CourseOfStudy,
                    Institution = user.Intern.Institution,
                    Gender = user.Gender,
                    Year = user.Intern.Year,
                    Bio = user.Bio,
                    ProfilePicture = profilePicture, 
                    MentorUserId = user.Intern.MentorId,
                });
            };
            return interns;
        }
    }

}
