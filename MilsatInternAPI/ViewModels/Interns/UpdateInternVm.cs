﻿using MilsatInternAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class UpdateInternVm
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public Guid? MentorId { get; set; } = Guid.Empty;
        [Required]
        public DepartmentType Department { get; set; }
    }
}
