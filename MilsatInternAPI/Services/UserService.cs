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
        public UserService(
            ILogger<InternService> logger, IAsyncRepository<User> userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
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

        public async Task<GenericResponse<List<UserResponseDTO>>> GetUsers(GetUserVm vm)
        {
            _logger.LogInformation($"Received a request to Fetch User(s): Request:{JsonConvert.SerializeObject(vm)}");
            if (vm.id == null && vm.name == null && vm.department == null)
            {
                return new GenericResponse<List<UserResponseDTO>>
                {
                    Successful = false,
                    ResponseCode = ResponseCode.NotFound
                };
            }
            try
            {
                if (vm.id != null)
                {
                    var intern = await _userRepo.GetAll().Where(x => x.UserId == vm.id).FirstOrDefaultAsync();
                    if (intern == null)
                    {
                        _logger.LogInformation($"Invalid ID Received: Request:{JsonConvert.SerializeObject(vm)}");
                        return new GenericResponse<List<UserResponseDTO>>
                        {
                            Successful = false,
                            ResponseCode = ResponseCode.NotFound
                        };
                    }

                    var users = UserResponseData(new List<User> { intern });
                    return new GenericResponse<List<UserResponseDTO>>
                    {
                        Successful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = users
                    };
                }

                // Received only name without department
                else if (vm.name != null && vm.department == null)
                {
                    var interns = await _userRepo.GetAll()
                                                 .Where(x => x.FirstName.Contains(vm.name) || x.LastName.Contains(vm.name))
                                                 .ToListAsync();
                    var users = UserResponseData(interns);
                    return new GenericResponse<List<UserResponseDTO>>
                    {
                        Successful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = users
                    };
                }

                //Received only Department without name
                //else if (model.name == null && model.department != null)
                else
                {
                    var interns = await _userRepo.GetAll()
                                                 .Where(x => x.Department == vm.department)
                                                 .ToListAsync();
                    var users = UserResponseData(interns);
                    return new GenericResponse<List<UserResponseDTO>>
                    {
                        Successful = true,
                        ResponseCode = ResponseCode.Successful,
                        Data = users
                    };
                }
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
                    Department = user.Department,
                    Role = user.Role,
                });
            };
            return users;
        }
    }
}
