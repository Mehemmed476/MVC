using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ZonAppProject.DAL;
using ZonAppProject.Models;

namespace ZonAppProject.Controllers;

public class AboutController : Controller
{
    private readonly AppDbContext _context;

    public AboutController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    public IActionResult Index()
    {
        /*TeamMember member1 = new TeamMember()
        {
            Name = "John Doe",
            Profession = "Development",
            ImageUrl = "team-01.jpg",
            CreatedDate = DateTime.Now
        };
        TeamMember member2 = new TeamMember()
        {
            Name = "Jone Doe",
            Profession = "Development",
            ImageUrl = "team-02.jpg",
            CreatedDate = DateTime.Now
        };
        TeamMember member3 = new TeamMember()
        {
            Name = "Sam",
            Profession = "Developer",
            ImageUrl = "team-03.jpg",
            CreatedDate = DateTime.Now
        };

        _context.TeamMembers.Add(member1);
        _context.TeamMembers.Add(member2);
        _context.TeamMembers.Add(member3);
        _context.SaveChanges();*/

        IEnumerable<TeamMember> TeamMembers = _context.TeamMembers.ToList();
        return View(TeamMembers);
    }
}