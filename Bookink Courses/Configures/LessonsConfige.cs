using Bookink_Courses.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookink_Courses.Configures
{
    public class LessonsConfige : IEntityTypeConfiguration<Lessons>
    {
        public void Configure(EntityTypeBuilder<Lessons> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(50);
       
        }
    }
}
