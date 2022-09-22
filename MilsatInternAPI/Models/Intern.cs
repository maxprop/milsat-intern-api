using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilsatInternAPI.Models
{
    public class Intern
    {
        public Guid InternId { get; set; }
        [Required]
        public string CourseOfStudy { get; set; }
        [Required]
        public string Institution { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int Year { get; set; } = DateTime.UtcNow.Year;
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid MentorId { get; set; }
        public Mentor? Mentor { get; set; }
    }
}
