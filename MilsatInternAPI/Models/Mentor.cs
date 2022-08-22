namespace MilsatInternAPI.Models
{
    public class Mentor
    {
        public int MentorId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public List<Intern> Interns { get; set; }

    }

    public enum DepartmentEnum
    {
        Analytics,
        Backend,
        Cybersecurity,
        DevOps,
        Frontend,   
        UIUX
    }
}
