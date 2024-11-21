using Microsoft.AspNetCore.Mvc;

namespace ZonAppProject.Controllers;

public class PricingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}