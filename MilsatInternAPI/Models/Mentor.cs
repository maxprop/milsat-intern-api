using MilsatInternAPI.Enums;

namespace MilsatInternAPI.Models
{
    public class Mentor
    {
        public int MentorId { get; set; }
        public string Name { get; set; }
        public DepartmentType Department { get; set; }
        public MentorStatus Status { get; set; }

        public ICollection<Intern> Interns { get; set; }
    }
}
