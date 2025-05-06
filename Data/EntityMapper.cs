using Microsoft.EntityFrameworkCore;

namespace SeniorLearn.Data;

public class EntityMapper
{


    public EntityMapper(ModelBuilder mb)
    {

        mb.Entity<Member>(m =>
        {
            m.Property(m => m.PhoneNumber).HasMaxLength(12);

            m.Property(m => m.Role)
             .HasConversion<int>();
            m.HasDiscriminator(u => u.Role)
               .HasValue<Member>(Roles.STANDARD)
               .HasValue<Member>(Roles.PROFESSIONAL)
               .HasValue<Member>(Roles.HONORARY);
        });

    }
}
