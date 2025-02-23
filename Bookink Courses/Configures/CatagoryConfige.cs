using Bookink_Courses.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookink_Courses.Configures
{
    public class CatagoryConfige : IEntityTypeConfiguration<Catagory>
    {
        public void Configure(EntityTypeBuilder<Catagory> builder)
        {
            builder.Property(e => e.Name)
                .HasMaxLength(20);
          
        }
    }
}
