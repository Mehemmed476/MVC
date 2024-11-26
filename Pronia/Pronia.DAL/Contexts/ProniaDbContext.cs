using Microsoft.EntityFrameworkCore;
using Pronia.DAL.Models;

namespace Pronia.DAL.Contexts;

public class ProniaDbContext : DbContext
{
    public ProniaDbContext(DbContextOptions<ProniaDbContext> options) : base(options) {
    
    }

    public DbSet<SliderItem> SliderItems { get; set; }
}
