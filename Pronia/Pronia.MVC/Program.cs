using Microsoft.EntityFrameworkCore;
using Pronia.BL.Services.Abstractions;
using Pronia.BL.Services.Concretes;
using Pronia.DAL.Contexts;
using Pronia.DAL.Models;

namespace Pronia.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ProniaDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("Room2MsSql"));
        });

        builder.Services.AddScoped<IGenericCRUDService, GenericCRUDService>();

        var app = builder.Build();
        app.UseStaticFiles();

        app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        app.Run();
    }
}
