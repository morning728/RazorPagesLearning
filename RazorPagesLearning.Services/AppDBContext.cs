using Microsoft.EntityFrameworkCore;
using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services
{
    public class AppDBContext: DbContext
    {
        //public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {}
        public AppDBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=loqaciadb;Integrated security=true");
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            string adminLogin = "secretAdminLogin";
            string adminPassword = "123456";

            User adminUser = new User { Id = 1, login = adminLogin, password = adminPassword, role = "Admin" };
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
