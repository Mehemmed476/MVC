using Microsoft.AspNetCore.Mvc;

namespace ZonAppProject.Controllers;

public class Work_singleController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}