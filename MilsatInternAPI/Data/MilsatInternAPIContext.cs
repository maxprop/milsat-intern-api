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
            var all = createUsers("string");
            modelBuilder.Entity<User>().HasData(all[0], all[1], all[2], all[3], all[4], all[5], all[6]);

            modelBuilder.Entity<Mentor>().HasData(
            new Mentor { 
                MentorId = Guid.NewGuid(), UserId = all[0].UserId,
                FirstName = "Sodiq", LastName = "Agboola", PhoneNumber = "string",
                Department = DepartmentType.Backend},
            new Mentor {
                MentorId = Guid.NewGuid(), UserId = all[1].UserId,
                FirstName = "Emmanuel", LastName = "Victor",
                PhoneNumber = "string",
                Department = DepartmentType.Frontend },
            new Mentor {
                MentorId = Guid.NewGuid(), UserId = all[2].UserId,
                FirstName = "Meenat", LastName = "Victoria",
                PhoneNumber = "string",
                Department = DepartmentType.DevOps },
            new Mentor { 
                MentorId = Guid.NewGuid(), UserId = all[3].UserId,
                FirstName = "Ayodeji", LastName = "Smart",
                PhoneNumber = "string",
                Department = DepartmentType.UIUX },
            new Mentor { 
                MentorId = Guid.NewGuid(), UserId = all[4].UserId,
                FirstName = "Michael", LastName = "Smith",
                PhoneNumber = "string",
                Department = DepartmentType.Analytics },
            new Mentor { 
                MentorId = Guid.NewGuid(), UserId = all[5].UserId,
                FirstName = "Elon", LastName = "Musk",
                PhoneNumber = "string",
                Department = DepartmentType.Cybersecurity }
            );
        }
        private List<User> createUsers( string password)
        {
            var all = new List<User>();
            for (int i = 0; i < 6; i++)
            {
                var user = new User { UserId = Guid.NewGuid(), Email = $"{i}@gmail.com", Role = "Mentor"};
                var _user = setter(user, password);
                all.Add(_user);
            }

            var admin = new User { UserId = Guid.NewGuid(), Email = "admin@milsat.com", Role = "Admin"};
            var _admin = setter(admin, password);
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
