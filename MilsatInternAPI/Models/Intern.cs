using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilsatInternAPI.Models
{
    public class Intern
    {
        public Guid InternId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid? MentorId { get; set; }
        public Mentor? Mentor { get; set; }
    }
}
