using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class UpdateInternVm
    {
        public Guid UserId { get; set; }
        public Guid MentorId { get; set; }
        public DepartmentType Department { get; set; }
    }
}
