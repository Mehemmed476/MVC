using Microsoft.AspNetCore.Mvc;

namespace ZonAppProject.Controllers;

public class AboutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}