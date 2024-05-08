//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EnterpriseMobileApp_ASS1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Store> Store { get; set; }
        public DbSet<Favourite_Store> Favourite { get; set; }

        public DbSet<Student> Student { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure table name for Tourist entity
            builder.Entity<Student>().ToTable("Student");
            builder.Entity<Store>().ToTable("Store");
            builder.Entity<Favourite_Store>().ToTable("Favourite");
        }


    }
}
