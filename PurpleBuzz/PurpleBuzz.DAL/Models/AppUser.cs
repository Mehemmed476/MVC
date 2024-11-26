using Microsoft.AspNetCore.Identity;

namespace PurpleBuzz.DAL.Models;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}