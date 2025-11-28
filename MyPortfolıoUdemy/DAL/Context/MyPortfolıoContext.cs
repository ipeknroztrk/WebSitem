using System;
using Microsoft.EntityFrameworkCore;
using MyPortfolıoUdemy.DAL.Entities;

namespace MyPortfolıoUdemy.DAL.Context
{
	public class MyPortfolıoContext:DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = Environment.GetEnvironmentVariable("PGHOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("PGPORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("PGDATABASE") ?? "MyPortfolıoDb";
            var username = Environment.GetEnvironmentVariable("PGUSER") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("PGPASSWORD") ?? "12345678";
            
            var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};SSL Mode=Require;Trust Server Certificate=true";
            
            optionsBuilder.UseNpgsql(connectionString);
        }
        
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolıo> Portfolıos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> socialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}
