using Microsoft.EntityFrameworkCore;
using ProniaTask.Models;

namespace ProniaTask.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<SliderItem> SliderItems { get; set; }
}