using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzMVC.Controllers;

public class PricingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}