using Microsoft.EntityFrameworkCore;
using ZonAppProject.Models;

namespace ZonAppProject.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<TeamMember> TeamMembers { get; set; }
    DbSet<ResponceContactForm> ResponceContactForms { get; set; }
}