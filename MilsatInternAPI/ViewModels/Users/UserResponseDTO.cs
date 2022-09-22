using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Users
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public DepartmentType Department { get; set; }
        public RoleType Role { get; set; }
    }
}
