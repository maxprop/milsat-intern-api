using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.ViewModels
{
    public class UserLoginDTO
    {
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter Valid Email ID")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
