using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.ViewModels
{
    public class UserLoginDTO
    {
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter Valid Email ID")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
