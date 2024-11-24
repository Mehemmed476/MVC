using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class OurServiceController : Controller
{
    private readonly IGenericCRUDService _service;

    public OurServiceController(IGenericCRUDService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<OurService> ourServices = await _service.GetAllAsync<OurService>();
        List<OurService> activeOurServices = ourServices.Where(x => x.IsDeleted == false).ToList();
        return View(activeOurServices);
    }
    
    [HttpGet]
    public async Task<IActionResult> SoftDeletedOurServices()
    {
        IEnumerable<OurService> ourServices = await _service.GetAllAsync<OurService>();
        List<OurService> offlineOurServices = ourServices.Where(x => x.IsDeleted).ToList();
        return View(offlineOurServices);
    }
    
    [HttpGet]
    public IActionResult CreateOurService()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOurService(OurService ourService)
    {
        if (ModelState.IsValid)
        { 
            await _service.CreateAsync(ourService);
            return RedirectToAction(nameof(Index));
        }
        
        return View();
    }

    [HttpGet]

    public async Task<IActionResult> EditOurService(int id)
    {
        OurService ourService = await _service.GetByIdAsync<OurService>(id);
        return View(ourService);
    }
   
    [HttpPost]
    
    public async Task<IActionResult> EditOurService(OurService ourService)
    {
        await _service.UpdateAsync(ourService);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]

    public async Task<IActionResult> SoftDeleteOurService(int id)
    {
        await _service.SoftDeleteAsync<OurService>(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    
    public async Task<IActionResult> DeleteOurService(int id)
    {
        await _service.DeleteAsync<OurService>(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]

    public async Task<IActionResult> RestoreOurService(int id)
    {
        await _service.RestoreAsync<OurService>(id);
        return RedirectToAction(nameof(SoftDeletedOurServices));
    }

    [HttpGet]

    public IActionResult Details()
    {
        return View();
    }
}