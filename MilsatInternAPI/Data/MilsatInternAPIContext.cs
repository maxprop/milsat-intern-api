using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilsatInternAPI.Enums;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.Data
{
    public class MilsatInternAPIContext : DbContext
    {
        public MilsatInternAPIContext(DbContextOptions<MilsatInternAPIContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Intern> Intern { get; set; }
        public DbSet<Mentor> Mentor { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Intern>()
                .HasOne(e => e.User)
                .WithOne(e => e.Intern)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Intern>()
                .HasOne(e => e.Mentor)
                .WithMany(e => e.Interns)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Mentor>()
                .HasOne(e => e.User)
                .WithOne(e => e.Mentor)
                .OnDelete(DeleteBehavior.Cascade);

            var all = createUsers();
            modelBuilder.Entity<User>().HasData(all[0], all[1], all[2]);

            modelBuilder.Entity<Mentor>().HasData(
            new Mentor {UserId = all[0].UserId },
            new Mentor {UserId = all[1].UserId });
        }
        private List<User> createUsers()
        {
            var all = new List<User>();
            for (int i = 1; i < 3; i++)
            {
                var user = new User { 
                    UserId = Guid.NewGuid(), Email = $"mentor{i}@gmail.com", Role = RoleType.Mentor,
                    FullName = "Sodiq Agboola", PhoneNumber = "string", Department = DepartmentType.Backend,
                };
                var _user = setter(user, user.PhoneNumber);
                all.Add(_user);
            }

            var admin = new User {
                UserId = Guid.NewGuid(), Email = "admin@milsat.com", Role = RoleType.Admin,
                FullName = "Admin", PhoneNumber = "home", Department = DepartmentType.Staff
            };
            var _admin = setter(admin, admin.PhoneNumber);
            all.Add(_admin);
            return all;
        }

        public User setter(User user, string defaultPassword)
        {
            CreatePasswordHash(defaultPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
