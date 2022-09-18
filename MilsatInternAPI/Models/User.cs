using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DepartmentType Department { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? RefreshToken { get; set; }
        public RoleType Role { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public Intern Intern { get; set; }
        public Mentor Mentor { get; set; }
    }
}
