using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Users;

namespace MilsatInternAPI.Interfaces
{
    public interface IUserService
    {
        Task<GenericResponse<List<UserResponseDTO>>> GetAllUsers(int pageNumber, int pageSize);
        Task<GenericResponse<List<UserResponseDTO>>> GetUsers(GetUserVm vm);
        Task<GenericResponse<UserResponseDTO>> RemoveUser(Guid id);
    }
}