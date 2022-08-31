using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilsatInternAPI.Models
{
    public class Intern
    {
        public Guid InternId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DepartmentType Department { get; set; }
        public User User { get; set; }
        public Mentor? Mentor { get; set; }
    }
}
