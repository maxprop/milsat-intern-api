using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Enums;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.Data
{
    public class MilsatInternAPIContext : DbContext
    {
        public MilsatInternAPIContext (DbContextOptions<MilsatInternAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Intern> Intern { get; set; } = default!;
        public DbSet<Mentor> Mentor { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mentor>().HasData(
                new Mentor { MentorId = 1, Name = "Sodiq Agboola", Department = DepartmentType.Backend },
                new Mentor { MentorId = 2, Name = "Emmanuel Victor", Department = DepartmentType.Frontend },
                new Mentor { MentorId = 3, Name = "Meenat Victoria", Department = DepartmentType.DevOps },
                new Mentor { MentorId = 4, Name = "Ayodeji Smart", Department = DepartmentType.UIUX },
                new Mentor { MentorId = 5, Name = "Michael Smith", Department = DepartmentType.Analytics },
                new Mentor { MentorId = 6, Name = "Elon Musk", Department = DepartmentType.Cybersecurity }
            );
        }
    }
}
