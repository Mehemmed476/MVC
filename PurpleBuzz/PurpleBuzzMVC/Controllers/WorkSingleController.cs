using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzMVC.Controllers;

public class WorkSingleController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}