using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class InternResponseDTO
    {
        public Guid InternId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentType Department { get; set; }
        public string MentorName { get; set; }
    }
}
    