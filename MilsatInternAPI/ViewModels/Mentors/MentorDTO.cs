using MilsatInternAPI.Enums;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.ViewModels.Mentors
{
    public class MentorDTO
    {
        public int MentorId { get; set; }
        public string Name { get; set; }
        public DepartmentType Department { get; set; }
        public MentorStatus Status { get; set; }

        public List<MentorInternDTO> Interns { get; set; }
    }

    public class MentorInternDTO
    {
        public int InternId { get; set; }
        public string Name { get; set; }
    }
}

