using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.Data
{
    public class MilsatInternAPIContext : DbContext
    {
        public MilsatInternAPIContext (DbContextOptions<MilsatInternAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MilsatInternAPI.Models.Intern> Intern { get; set; } = default!;
    }
}
