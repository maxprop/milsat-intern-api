using MilsatInternAPI.Enums;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.ViewModels.Mentors
{
    public class MentorDTO
    {
        public Guid MentorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentType Department { get; set; }
        //public MentorStatus Status { get; set; }

        public List<MentorInternDTO> Interns { get; set; }
    }

    public class MentorInternDTO
    {
        public Guid InternId { get; set; }
        public string Name { get; set; }
    }
}

