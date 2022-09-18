using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Users
{
    public class GetUserVm
    {
        public Guid? id { get; set; }
        public string? name { get; set; }
        public DepartmentType? department { get; set; }
    }
}
