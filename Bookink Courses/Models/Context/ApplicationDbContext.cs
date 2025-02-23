using Bookink_Courses.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bookink_Courses.Models.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Courses> Courses { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Course_Trainer> Course_Trainers { get; set; }
   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Course_Trainer>()
                .HasKey(e => new { e.Trainer_Id, e.Course_Id });

            builder.Entity<Course_Trainer>()
                .HasOne(c => c.Courses)
                .WithMany(ct => ct.course_Trainers)
                .HasForeignKey(cf => cf.Course_Id);

            builder.Entity<Course_Trainer>()
                .HasOne(t => t.Trainer)
                .WithMany(ct => ct.course_Trainers)
                .HasForeignKey(tf => tf.Trainer_Id);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
