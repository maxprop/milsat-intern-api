﻿using System.ComponentModel.DataAnnotations;

namespace MilsatInternAPI.Models
{
    public class UpdateInternVm
    {
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Id { get; set; }
        public string Department { get; set; }
    }
}
