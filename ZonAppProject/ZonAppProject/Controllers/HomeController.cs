using Microsoft.AspNetCore.Mvc;

namespace ZonAppProject.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}