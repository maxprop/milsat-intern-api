using MilsatInternAPI.Enums;

namespace MilsatInternAPI.Models
{
    public class Intern
    {
        public int InternId { get; set; }
        public string Name { get; set; }
        public DepartmentType Department { get; set; }
        public Mentor Mentor { get; set; }
    }
}
