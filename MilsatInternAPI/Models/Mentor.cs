using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilsatInternAPI.Models
{
    public class Mentor
    {
        public Guid MentorId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public MentorStatus Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Intern> Interns { get; set; }
    }
}
