using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class TeamMemberController : Controller
{
    private readonly IGenericCRUDService _service;

    public TeamMemberController(IGenericCRUDService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<TeamMember> teamMembers = await _service.GetAllAsync<TeamMember>();
        List<TeamMember> activeTeamMembers = teamMembers.Where(x => x.IsDeleted == false).ToList();
        return View(activeTeamMembers);
    }
    
    [HttpGet]
    public async Task<IActionResult> SoftDeletedTeamMembers()
    {
        IEnumerable<TeamMember> teamMembers = await _service.GetAllAsync<TeamMember>();
        List<TeamMember> offlineTeamMembers = teamMembers.Where(x => x.IsDeleted).ToList();
        return View(offlineTeamMembers);
    }
    
    [HttpGet]
    public IActionResult CreateTeamMember()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTeamMember(TeamMember teamMember)
    {
        if (ModelState.IsValid)
        { 
            await _service.CreateAsync(teamMember);
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }

    [HttpGet]

    public async Task<IActionResult> EditTeamMember(int id)
    {
        TeamMember teamMember = await _service.GetByIdAsync<TeamMember>(id);
        return View(teamMember);
    }
   
    [HttpPost]
    
    public async Task<IActionResult> EditTeamMember(TeamMember teamMember)
    {
        await _service.UpdateAsync(teamMember);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]

    public async Task<IActionResult> SoftDeleteTeamMember(int id)
    {
        await _service.SoftDeleteAsync<TeamMember>(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    
    public async Task<IActionResult> DeleteTeamMember(int id)
    {
        await _service.DeleteAsync<TeamMember>(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]

    public async Task<IActionResult> RestoreTeamMembers(int id)
    {
        await _service.RestoreAsync<TeamMember>(id);
        return RedirectToAction(nameof(SoftDeletedTeamMembers));
    }
    
    [HttpGet]

    public IActionResult Details()
    {
        return View();
    }
}