using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class WorkController : Controller
{
    private readonly IWorkService _service;

    public WorkController(IWorkService service)
    {
        _service = service;
    }
    
    [HttpGet]
    
    public async Task<IActionResult> Index()
    {
        List<Work> works = await _service.GetAllWorksAsync();
        List<Work> activeWorks = works.Where(x => x.IsDeleted == false).ToList();
        return View(activeWorks);
    }
    
    [HttpGet]
    public async Task<IActionResult> SoftDeletedWorks()
    {
        List<Work> works = await _service.GetAllWorksAsync();
        List<Work> offlineWorks = works.Where(x => x.IsDeleted == true).ToList();
        return View(offlineWorks);
    }
    
    [HttpGet]
    
    public async Task<IActionResult> CreateWork()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateWork(Work work)
    {
        if (ModelState.IsValid)
        { 
            await _service.AddWork(work);
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }

    [HttpGet]

    public async Task<IActionResult> EditWork(int Id)
    {
        Work work = await _service.GetWorkAsync(Id);
        return View(work);
    }
   
    [HttpPost]
    
    public async Task<IActionResult> EditWork(Work work)
    {
        await _service.UpdateWorkAsync(work);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]

    public async Task<IActionResult> SoftDeleteWork(int Id)
    {
        await _service.SoftDeleteWorkAsync(Id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    
    public async Task<IActionResult> DeleteWork(int Id)
    {
        await _service.DeleteWorkAsync(Id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]

    public async Task<IActionResult> RestoreWork(int Id)
    {
        await _service.RestoreWorkAsync(Id);
        return RedirectToAction(nameof(SoftDeletedWorks));
    }
}