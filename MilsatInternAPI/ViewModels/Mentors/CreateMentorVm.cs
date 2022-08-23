using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Mentors
{
    public class CreateMentorVm
    {
        public int MentorId { get; set; }
        public string Name { get; set; }
        public DepartmentType Department { get; set; }
    }
}

