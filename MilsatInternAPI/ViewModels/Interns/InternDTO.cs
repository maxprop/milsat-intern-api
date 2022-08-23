using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class InternDTO
    {
        public int InternId { get; set; }
        public string Name { get; set; }
        public DepartmentType Department { get; set; }
        public int MentorId { get; set; }
        public string MentorName { get; set; }
    }
}
