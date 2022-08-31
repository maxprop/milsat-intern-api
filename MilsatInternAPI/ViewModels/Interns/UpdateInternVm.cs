using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class UpdateInternVm
    {
        public string Id { get; set; }
        public DepartmentType Department { get; set; }
    }
}
