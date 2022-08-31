using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Mentors
{
    public class GetMentorVm
    {
        public Guid? id { get; set; }
        public string? name { get; set; }
        public DepartmentType? department { get; set; }
    }
}
