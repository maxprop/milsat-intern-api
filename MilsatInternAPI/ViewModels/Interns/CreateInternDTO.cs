using MilsatInternAPI.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class CreateInternDTO
    {
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter Valid Email ID")]
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
