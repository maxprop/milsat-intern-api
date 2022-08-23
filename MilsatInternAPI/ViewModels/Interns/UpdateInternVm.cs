using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class UpdateInternVm
    {
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Id { get; set; }
        public DepartmentType Department { get; set; }
    }
}
