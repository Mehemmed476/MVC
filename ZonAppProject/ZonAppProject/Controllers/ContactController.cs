using Microsoft.AspNetCore.Mvc;

namespace ZonAppProject.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}