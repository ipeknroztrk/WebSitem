using System;
using Microsoft.EntityFrameworkCore;
using MyPortfolıoUdemy.DAL.Entities;

namespace MyPortfolıoUdemy.DAL.Context
{
    public class MyPortfolıoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // DATABASE_URL'i kontrol et
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            
            // DEBUG: Hangi connection kullanıldığını görmek için
            Console.WriteLine($"DATABASE_URL: {(string.IsNullOrEmpty(databaseUrl) ? "EMPTY" : "EXISTS")}");
            
            if (!string.IsNullOrEmpty(databaseUrl))
            {
                Console.WriteLine("Using DATABASE_URL connection");
                optionsBuilder.UseNpgsql(databaseUrl);
            }
            else
            {
                var pgHost = Environment.GetEnvironmentVariable("PGHOST");
                Console.WriteLine($"PGHOST: {pgHost ?? "EMPTY"}");
                
                if (!string.IsNullOrEmpty(pgHost))
                {
                    var pgPort = Environment.GetEnvironmentVariable("PGPORT");
                    var pgDatabase = Environment.GetEnvironmentVariable("PGDATABASE");
                    var pgUser = Environment.GetEnvironmentVariable("PGUSER");
                    var pgPassword = Environment.GetEnvironmentVariable("PGPASSWORD");
                    
                    Console.WriteLine($"Using PG variables: Host={pgHost}");
                    var connectionString = $"Host={pgHost};Port={pgPort};Database={pgDatabase};Username={pgUser};Password={pgPassword};SSL Mode=Require;Trust Server Certificate=true";
                    optionsBuilder.UseNpgsql(connectionString);
                }
                else
                {
                    Console.WriteLine("Using LOCAL connection");
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
