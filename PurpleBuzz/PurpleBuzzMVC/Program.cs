using Microsoft.EntityFrameworkCore;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.BL.Services.Concretes;
using PurpleBuzz.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PurpleBuzzDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MacBookMsSql"));
        options.EnableSensitiveDataLogging(); 
        options.LogTo(Console.WriteLine);
    }
);
builder.Services.AddScoped<IGenericCRUDService, GenericCRUDService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
        name : "areas",
        pattern : "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();