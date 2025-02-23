using Bookink_Courses.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookink_Courses.Configures
{
    public class CourseConfige : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(20);

            builder.Property(e => e.Description)
                .HasMaxLength(250);
        }
    }
}
