using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilsatInternAPI.Models
{
    public class Mentor
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public MentorStatus Status { get; set; }
        [ForeignKey("MentorId")]
        public Guid MentorId { get; set; }
        public User User { get; set; }
        public List<Intern> Interns { get; set; }
    }
}
