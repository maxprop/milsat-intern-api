using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilsatInternAPI.Models
{
    public class Mentor
    {
        public Guid MentorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DepartmentType Department { get; set; }
        public MentorStatus Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Intern> Interns { get; set; }
    }
}
