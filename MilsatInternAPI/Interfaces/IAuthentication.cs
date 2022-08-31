using MilsatInternAPI.Models;
using MilsatInternAPI.ViewModels;
using MilsatInternAPI.ViewModels.Interns;

namespace MilsatInternAPI.Interfaces
{
    public interface IAuthentication
    {
        User RegisterPassword(User request, string phoneNumber);
        Task<AuthResponseDTO> Login(UserDTO request);
        Task<AuthResponseDTO> RefreshToken();
        //void SetRefreshToken(RefreshToken refreshToken, User user);
    }
}
