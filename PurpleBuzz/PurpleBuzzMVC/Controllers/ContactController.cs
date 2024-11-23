using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzMVC.Controllers;

public class ContactController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}