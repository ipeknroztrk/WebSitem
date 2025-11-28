using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPortfolıoUdemy.DAL.Entities;

namespace MyPortfolıoUdemy.DAL.Context
{
    public class MyPortfolıoContext : DbContext
    {
        public MyPortfolıoContext(DbContextOptions<MyPortfolıoContext> options) : base(options)
        {
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
