using System;
using Microsoft.EntityFrameworkCore;
using MyPortfolıoUdemy.DAL.Entities;

namespace MyPortfolıoUdemy.DAL.Context
{
    public class MyPortfolıoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Önce DATABASE_URL'i kontrol et (Render için en güvenilir)
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            
            if (!string.IsNullOrEmpty(databaseUrl))
            {
                // DATABASE_URL kullan
                optionsBuilder.UseNpgsql(databaseUrl);
            }
            else
            {
                // Railway/Render PG variables
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
                    // Local'de
                    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=MyPortfolıoDb;User Id=postgres;Password=12345678;");
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
