using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Controllers;

public class WorkController : Controller
{
    private readonly IGenericCRUDService _service;

    public WorkController(IGenericCRUDService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<Work> allWorks = await _service.GetAllAsync<Work>();
        IEnumerable<Work> lastSixWorks = allWorks.Where(x => x.IsDeleted == false).OrderByDescending(tm => tm.CreatedDate).Take(6);
        return View(allWorks);
    }
}