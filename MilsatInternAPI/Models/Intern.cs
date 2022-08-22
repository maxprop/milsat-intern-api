namespace MilsatInternAPI.Models
{
    public class Intern
    {
        public int InternId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public Mentor Mentor { get; set; }
    }
}
