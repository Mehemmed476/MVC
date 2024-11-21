using Microsoft.AspNetCore.Mvc;

namespace ZonAppProject.Controllers;

public class WorkController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}