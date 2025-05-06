using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SeniorLearn.Data;

public class ApplicationDbContext : IdentityDbContext
{

    //DbSets - Map to tables in database
    public DbSet<Member> Member { get; set; }
    public DbSet<Lesson> Lessons { get; set; }  


    //CTOR
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //Overide of OnModelCreating to use custom entity mapping
    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        new EntityMapper(mb);
    }
}
