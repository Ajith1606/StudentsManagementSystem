using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using StudentsManagement.Models;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<SystemCode> SystemCodes { get; set; }
        public DbSet<SystemCodeDetails> SystemCodeDetails { get; set; }
        public DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Parent>()
           .HasOne(p => p.ParentType)
           .WithMany()
            .HasForeignKey(p => p.ParentTypeId)
           .OnDelete(DeleteBehavior.Restrict);  // No cascade here

            // Configure GenderId relationship with Restrict (if necessary)
            modelBuilder.Entity<Parent>()
                .HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderId)
                .OnDelete(DeleteBehavior.Restrict);  // Restrict this too

            // Optionally leave cascading on other foreign keys, like StudentId
            modelBuilder.Entity<Parent>()
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
   
}
