using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.BL.Services.Concretes;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class WorkController : Controller
{
    private readonly IGenericCRUDService _service;

    public WorkController(IGenericCRUDService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<Work> works = await _service.GetAllAsync<Work>();
        List<Work> activeWorks = works.Where(x => x.IsDeleted == false).ToList();
        return View(activeWorks);
    }
    
    [HttpGet]
    public async Task<IActionResult> SoftDeletedWorks()
    {
        IEnumerable<Work> works = await _service.GetAllAsync<Work>();
        List<Work> offlineWorks = works.Where(x => x.IsDeleted).ToList();
        return View(offlineWorks);
    }
    
    [HttpGet]
    public IActionResult CreateWork()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateWork(Work work)
    {
        if (ModelState.IsValid)
        { 
            await _service.CreateAsync(work);
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }

    [HttpGet]

    public async Task<IActionResult> EditWork(int id)
    {
        Work work = await _service.GetByIdAsync<Work>(id);
        return View(work);
    }
   
    [HttpPost]
    
    public async Task<IActionResult> EditWork(Work work)
    {
        await _service.UpdateAsync(work);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]

    public async Task<IActionResult> SoftDeleteWork(int id)
    {
        await _service.SoftDeleteAsync<Work>(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    
    public async Task<IActionResult> DeleteWork(int id)
    {
        await _service.DeleteAsync<Work>(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]

    public async Task<IActionResult> RestoreWork(int id)
    {
        await _service.RestoreAsync<Work>(id);
        return RedirectToAction(nameof(SoftDeletedWorks));
    }
}