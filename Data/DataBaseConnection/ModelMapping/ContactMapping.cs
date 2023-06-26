using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBaseConnection.ModelMapping
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(contact => contact.Id);
            builder.Property(contact => contact.Id).ValueGeneratedOnAdd();

            builder.Property(contact => contact.Name).IsRequired();
            builder.Property(contact => contact.Phone).IsRequired();
            
            builder.HasOne(contact => contact.User)
                .WithMany(user => user.Contacts)
                .HasForeignKey(contact => contact.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
