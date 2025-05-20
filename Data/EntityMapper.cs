using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SeniorLearn.Data;

public class EntityMapper
{

    public EntityMapper(ModelBuilder mb)
    {

        //Member mapping
        mb.Entity<Member>(m =>
        {
            m.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
            m.Property(m => m.LastName).IsRequired().HasMaxLength(50);
            //This is sketch - trying to use the built in annotation for email address validation in the mapping
            m.Property(m => m.Email).HasAnnotation("EmailAddress", new EmailAddressAttribute());
            m.Property(m => m.PhoneNumber).HasMaxLength(12);
            m.Property(m => m.Role)
             .HasConversion<int>();
            m.HasDiscriminator(m => m.Role)
               .HasValue<Member>(Roles.STANDARD)
               .HasValue<Member>(Roles.PROFESSIONAL)
               .HasValue<Member>(Roles.HONORARY);
        });

        //Membership mapping
        mb.Entity<Membership>(m =>
        {
            m.Property(m => m.Member).IsRequired();
            m.Property(m => m.StartDate).IsRequired().HasDefaultValue(DateTime.Now);
            m.Property(m => m.RenewalDate).IsRequired().HasDefaultValue(DateTime.Now.AddMonths(3));
            m.Property(m => m.Paid).IsRequired().HasDefaultValue(false);
            //Metadata changetracker tag - consider building metadata suite
            m.Property<DateTime>("LastChange");

        });

        //Lesson mapping
        mb.Entity<Lesson>(l =>
        {
            l.Property(l => l.Title).IsRequired().HasMaxLength(50);
            l.Property(l => l.Description).IsRequired().HasMaxLength(1000).HasDefaultValue("Lorem Ipsum");
            l.Property(l => l.StartTime).IsRequired();
            l.Property(l => l.EndTime).IsRequired();
            l.Property(l => l.Location).IsRequired();
            l.Property(l => l.Capacity).IsRequired();
            l.Property(l => l.Status)
                .HasConversion<int>();
            l.HasDiscriminator(l => l.Status)
               .HasValue<Lesson>(Status.DRAFT)
               .HasValue<Lesson>(Status.SCHEDULED)
               .HasValue<Lesson>(Status.CLOSED)
               .HasValue<Lesson>(Status.COMPLETE)
               .HasValue<Lesson>(Status.CANCELLED);
        });
    }
}
