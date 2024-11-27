using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.BL.Services.Concretes;
using PurpleBuzz.DAL.Contexts;
using PurpleBuzz.DAL.Models;

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

builder.Services.AddIdentity<AppUser, IdentityRole>(
    opt =>
    {
        opt.Password.RequiredLength = 8;
        opt.Password.RequireUppercase = true;
        opt.Password.RequireNonAlphanumeric = false;
        opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        opt.SignIn.RequireConfirmedEmail = false;
        opt.User.RequireUniqueEmail = true;
    }
).AddDefaultTokenProviders().AddEntityFrameworkStores<PurpleBuzzDbContext>();

builder.Services.AddScoped<IGenericCRUDService, GenericCRUDService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
        name : "areas",
        pattern : "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();