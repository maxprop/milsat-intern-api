using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Mentors
{
    public class CreateMentorVm
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public GenderType Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DepartmentType Department { get; set; }
    }
}

