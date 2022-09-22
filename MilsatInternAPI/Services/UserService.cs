using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Enums;
using MilsatInternAPI.Interfaces;
using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Users;
using Newtonsoft.Json;

namespace MilsatInternAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> _userRepo;
        private readonly ILogger<InternService> _logger;
        private readonly IConfiguration _iconfig;
        public UserService(IConfiguration iconfig,
            ILogger<InternService> logger, IAsyncRepository<User> userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
            _iconfig = iconfig;
        }


        public async Task<GenericResponse<List<UserResponseDTO>>> GetAllUsers(int pageNumber, int pageSize)
        {
            _logger.LogInformation($"Received a request to fetch paginated User(s): Request: pageNumber:{pageNumber}, pageSize:{pageSize}");
            try
            {
                var pagedData = await _userRepo.GetAll()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var users = UserResponseData(pagedData);
                return new GenericResponse<List<UserResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = users
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<UserResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<UserResponseDTO>>> GetUserById(Guid id)
        {
            _logger.LogInformation($"Received a request to fetch a User: Request(user id):{id}");
            try
            {
                var user = await _userRepo.GetByIdAsync(id);
                if (user == null)
                {
                    return new GenericResponse<List<UserResponseDTO>>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }
                return new GenericResponse<List<UserResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = UserResponseData(new List<User> { user })
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Deleting User. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<UserResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<List<UserResponseDTO>>> FilterUsers(GetUserVm vm, int pageNumber, int pageSize)
        {
            _logger.LogInformation($"Received a request to Fetch User(s): Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var filtered = await _userRepo.GetAll()
                                                 .Where(x =>
                                                         (vm.name == null || x.FirstName.Contains(vm.name) || x.LastName.Contains(vm.name))
                                                         && (vm.department != null && x.Department == vm.department)
                                                         && (vm.role != null && x.Role == vm.role))
                                                 .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                var users = UserResponseData(filtered);
                return new GenericResponse<List<UserResponseDTO>>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Data = users
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occured while Fecthing Data Request. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<List<UserResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }


        public string GetUserPicture(string fileName)
        {
            var filePath = Path.Combine(_iconfig["ProfilePicturesPath"], fileName);
            if (!File.Exists(filePath))
            {
                return String.Empty;
            }
            byte[] contents = File.ReadAllBytes(filePath);
            string image = Convert.ToBase64String(contents);
            return image;
        }


        public async Task<GenericResponse<UserResponseDTO>> UpdateProfile(UpdateUserVm vm)
        {
            _logger.LogInformation($"Received to update user profile: Request:{JsonConvert.SerializeObject(vm)}");
            try
            {
                var user = await _userRepo.GetByIdAsync(vm.UserId);

                if (user == null)
                {
                    return new GenericResponse<UserResponseDTO>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound,
                        Message = "Unsuccessful update."
                    };
                }

                if (vm.ProfilePicture.Length > 0)
                {
                    var fileName = user.ProfilePicture;
                    if (String.IsNullOrEmpty(fileName))
                    {
                        fileName = Path.GetRandomFileName(); 
                    }
                    var filePath = Path.Combine(_iconfig["ProfilePicturesPath"], fileName);

                    using (var stream = File.Create(filePath))
                    {
                        await vm.ProfilePicture.CopyToAsync(stream);
                    }
                    user.ProfilePicture = fileName;
                }

                return new GenericResponse<UserResponseDTO>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful,
                    Message = "Update is Successful"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while updating user profile. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<UserResponseDTO>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        public async Task<GenericResponse<UserResponseDTO>> RemoveUser(Guid id)
        {
            _logger.LogInformation($"Received a request to delete a User: Request(user id):{id}");
            try
            {
                var user = await _userRepo.GetByIdAsync(id);
                if (user == null)
                {
                    return new GenericResponse<UserResponseDTO>
                    {
                        Successful = false,
                        ResponseCode = ResponseCode.NotFound
                    };
                }

                await _userRepo.DeleteAsync(user);
                return new GenericResponse<UserResponseDTO>
                {
                    Successful = true,
                    ResponseCode = ResponseCode.Successful
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while Deleting User. Messg: {ex.Message} : StackTrace: {ex.StackTrace}");
                return new GenericResponse<UserResponseDTO>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.EXCEPTION_ERROR
                };
            }
        }

        private List<UserResponseDTO> UserResponseData(List<User> pagedData)
        {
            List<UserResponseDTO> users = new();
            foreach (var user in pagedData)
            {
                users.Add(new UserResponseDTO
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Bio = user.Bio,
                    ProfilePicture = GetUserPicture(user.ProfilePicture),
                    Department = user.Department,
                    Role = user.Role,
                });
            };
            return users;
        }
    }
}
