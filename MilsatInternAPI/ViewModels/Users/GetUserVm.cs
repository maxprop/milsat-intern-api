﻿using MilsatInternAPI.Enums;

namespace MilsatInternAPI.ViewModels.Users
{
    public class GetUserVm
    {
        public string? name { get; set; }
        public DepartmentType? department { get; set; }
        public RoleType? role { get; set; }
    }
}
