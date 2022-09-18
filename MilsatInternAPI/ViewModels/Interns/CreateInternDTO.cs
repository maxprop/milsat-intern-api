﻿using MilsatInternAPI.Enums;
using System.ComponentModel;

namespace MilsatInternAPI.ViewModels.Interns
{
    public class CreateInternDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [DefaultValue("")]
        public string MentorId { get; set; }
        public DepartmentType Department { get; set; }
    }
}
