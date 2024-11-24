using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzz.DAL.Contexts;

public class PurpleBuzzDbContext : DbContext
{
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost;Database=PurpleBuzzDB;User ID=SA; Password=reallyStrongPwd123;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True");
    }*/

    public PurpleBuzzDbContext(DbContextOptions<PurpleBuzzDbContext> options) : base(options) { }

    public DbSet<TeamMember> TeamsMembers { get; set; }
    public DbSet<Work> Works { get; set; }
    public DbSet<OurService> OurServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Work>()
            .HasOne(e => e.OurService)
            .WithMany(e => e.Works)
            .HasForeignKey(e => e.OurServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    
}