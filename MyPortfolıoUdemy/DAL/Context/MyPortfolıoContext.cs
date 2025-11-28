using System;
using Microsoft.EntityFrameworkCore;
using MyPortfolıoUdemy.DAL.Entities;

namespace MyPortfolıoUdemy.DAL.Context
{
    public class MyPortfolıoContext : DbContext
    {
        // Parametresiz constructor (eski kod için)
        public MyPortfolıoContext()
        {
        }

        // Constructor with options (DI için)
        public MyPortfolıoContext(DbContextOptions<MyPortfolıoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Railway environment variables varsa onları kullan
                var pgHost = Environment.GetEnvironmentVariable("PGHOST");
                
                if (!string.IsNullOrEmpty(pgHost))
                {
                    var pgPort = Environment.GetEnvironmentVariable("PGPORT");
                    var pgDatabase = Environment.GetEnvironmentVariable("PGDATABASE");
                    var pgUser = Environment.GetEnvironmentVariable("PGUSER");
                    var pgPassword = Environment.GetEnvironmentVariable("PGPASSWORD");
                    
                    var connectionString = $"Host={pgHost};Port={pgPort};Database={pgDatabase};Username={pgUser};Password={pgPassword};SSL Mode=Require;Trust Server Certificate=true";
                    optionsBuilder.UseNpgsql(connectionString);
                }
                else
                {
                    // Local development
                    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyPortfolıoDb;Username=postgres;Password=12345678");
                }
            }
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
