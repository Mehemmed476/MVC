using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Controllers;

public class WorkController : Controller
{
    private readonly IWorkService _service;

    public WorkController(IWorkService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<Work> allWorks = await _service.GetAllWorksAsync();
        IEnumerable<Work> lastSixWorks = allWorks.Where(x => x.IsDeleted = false).OrderByDescending(tm => tm.CreatedDate).Take(6);
        return View(lastSixWorks);
    }
}