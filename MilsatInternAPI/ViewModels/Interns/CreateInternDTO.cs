using MilsatInternAPI.Enums;
using System.ComponentModel;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class CreateInternDTO
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public GenderType Gender { get; set; }
        public string CourseOfStudy { get; set; }
        public string Institution { get; set; }
        public string PhoneNumber { get; set; }
        [DefaultValue("")]
        public string MentorId { get; set; }
        public DepartmentType Department { get; set; }
    }
}
