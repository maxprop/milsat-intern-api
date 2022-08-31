using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class GetInternVm
    {
        public Guid? id { get; set; }
        public string? name { get; set; }
        public DepartmentType? department { get; set; }
    }
}
