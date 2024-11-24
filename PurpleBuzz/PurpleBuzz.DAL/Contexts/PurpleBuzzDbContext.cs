using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzz.DAL.Contexts;

public class PurpleBuzzDbContext : DbContext
{
    public PurpleBuzzDbContext(DbContextOptions<PurpleBuzzDbContext> options) : base(options) { }

    public DbSet<TeamMember> TeamsMembers { get; set; }
    public DbSet<Work> Works { get; set; }
}