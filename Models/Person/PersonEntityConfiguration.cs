using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(i => i.ID);
            builder.Property(i => i.ID).ValueGeneratedOnAdd();
            builder.Property(i => i.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(i => i.LastName).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Email).IsRequired().HasMaxLength(100);
            builder.Property(i => i.BirthDate).IsRequired();

            builder.HasMany<Address>(g => g.Address)
           .WithOne(s => s.Person).HasForeignKey(s => s.PersonID)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
