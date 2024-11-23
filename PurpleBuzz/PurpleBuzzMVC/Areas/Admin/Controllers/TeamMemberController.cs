using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.BL.Services.Concretes;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class TeamMemberController : Controller
{
    private readonly ITeamMemberService _service;

    public TeamMemberController(ITeamMemberService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<TeamMember> teamMembers = await _service.GetAllTeamMembersAsync();
        List<TeamMember> activeTeamMembers = teamMembers.Where(x => x.IsDeleted == false).ToList();
        return View(activeTeamMembers);
    }
    
    [HttpGet]
    public async Task<IActionResult> SoftDeletedTeamMembers()
    {
        List<TeamMember> teamMembers = await _service.GetAllTeamMembersAsync();
        List<TeamMember> offlineTeamMembers = teamMembers.Where(x => x.IsDeleted == true).ToList();
        return View(offlineTeamMembers);
    }
    
    [HttpGet]
    public async Task<IActionResult> CreateTeamMember()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTeamMember(TeamMember teamMember)
    {
        if (ModelState.IsValid)
        { 
            await _service.AddTeamMember(teamMember);
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }

    [HttpGet]

    public async Task<IActionResult> EditTeamMember(int Id)
    {
        TeamMember teamMember = await _service.GetTeamMemberAsync(Id);
        return View(teamMember);
    }
   
    [HttpPost]
    
    public async Task<IActionResult> EditTeamMember(TeamMember teamMember)
    {
        await _service.UpdateTeamMemberAsync(teamMember);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]

    public async Task<IActionResult> SoftDeleteTeamMember(int Id)
    {
        await _service.SoftDeleteTeamMemberAsync(Id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    
    public async Task<IActionResult> DeleteTeamMember(int Id)
    {
        await _service.DeleteTeamMemberAsync(Id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]

    public async Task<IActionResult> RestoreTeamMembers(int Id)
    {
        await _service.RestoreTeamMemberAsync(Id);
        return RedirectToAction(nameof(SoftDeletedTeamMembers));
    }
}