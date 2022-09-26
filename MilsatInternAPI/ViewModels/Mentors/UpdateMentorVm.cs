using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Mentors
{
    public class UpdateMentorVm
    {
        public Guid MentorId { get; set; }
        public string FullName { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DepartmentType Department { get; set; }
    }
}
