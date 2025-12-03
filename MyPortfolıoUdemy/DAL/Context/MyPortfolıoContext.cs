using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.DAL.Entities;
using System;

namespace MyPortfolioUdemy.DAL.Context
{
    public class MyPortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (!string.IsNullOrEmpty(databaseUrl))
            {
                Console.WriteLine("Using Render DATABASE_URL");

                // Render URL → EF Core formatına çevrilir
                var uri = new Uri(databaseUrl.Replace("postgres://", "https://"));

                string host = uri.Host;
                int port = uri.Port;
                string db = uri.AbsolutePath.TrimStart('/');
                string user = uri.UserInfo.Split(':')[0];
                string pass = uri.UserInfo.Split(':')[1];

                var connectionString =
                    $"Host={host};Port={port};Database={db};Username={user};Password={pass};SSL Mode=Require;Trust Server Certificate=true";

                Console.WriteLine("Converted connection string OK");
                optionsBuilder.UseNpgsql(connectionString);
            }
            else
            {
                Console.WriteLine("Using LOCAL connection");
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyPortfolioDb;Username=postgres;Password=12345678;");
            }
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
