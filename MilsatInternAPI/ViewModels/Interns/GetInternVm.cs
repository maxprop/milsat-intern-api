using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class GetInternVm
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public DepartmentType department { get; set; }
    }
}
