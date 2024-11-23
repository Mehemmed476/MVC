using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzMVC.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}