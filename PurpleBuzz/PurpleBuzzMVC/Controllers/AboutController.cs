using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;
using System.Linq;
using System.Collections.Generic;

namespace PurpleBuzzMVC.Controllers;

public class AboutController : Controller
{
    private readonly ITeamMemberService _service;

    public AboutController(ITeamMemberService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<TeamMember> allTeamMembers = await _service.GetAllTeamMembersAsync();
        IEnumerable<TeamMember> lastThreeTeamMembers = allTeamMembers.Where(x => x.IsDeleted = false).OrderByDescending(tm => tm.CreatedDate).Take(3);
        return View(lastThreeTeamMembers);
    }
}