using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class CreateInternDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DepartmentType Department { get; set; }
    }
}
