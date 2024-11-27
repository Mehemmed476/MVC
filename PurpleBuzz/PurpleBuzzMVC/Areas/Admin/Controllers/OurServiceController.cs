using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class OurServiceController : Controller
{
    private readonly IGenericCRUDService _service;
    
    IWebHostEnvironment _webHostEnvironment;
    
    public OurServiceController(IGenericCRUDService service, IWebHostEnvironment webHostEnvironment)
    {
        _service = service;
        _webHostEnvironment = webHostEnvironment;
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
        
        
        if (!ourService.Image.ContentType.Contains("image"))
        {
            ModelState.AddModelError("Image", "Only image format accepted");
            return View(ourService);
        }
        
        string path = _webHostEnvironment.WebRootPath + @"~\Upload\OurServiceImages\";
        string fileName = ourService.Image.FileName;
        using(FileStream fileStream = new FileStream(path + fileName, FileMode.Create))
        {
            ourService.Image.CopyTo(fileStream);
        }

        ourService.MainImageUrl = path;
        
        if (!ModelState.IsValid)
        {
            return View(ourService);
        }
        
        await _service.CreateAsync(ourService);
        return RedirectToAction("Index");
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

    public async Task<IActionResult> Details(int id)
    {
        OurService ourService = await _service.GetByIdAsync<OurService>(id);
        return View(ourService);
    }
}