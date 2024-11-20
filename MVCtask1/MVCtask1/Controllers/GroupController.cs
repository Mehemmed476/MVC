using Microsoft.AspNetCore.Mvc;
using MVCtask1.Data;
using MVCtask1.Models;

namespace MVCtask1.Controllers;

public class GroupController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(DataStore.Groups);
    }
    
    [HttpPost]
    public IActionResult AddGroup(Group group)
    {
        if (ModelState.IsValid)
        {
            group.Id = DataStore.Groups.Count + 1;
            DataStore.Groups.Add(group);

            return RedirectToAction("Index");
        }
        
        return View(group);
    }

    [HttpGet]
    public IActionResult AddGroup()
    {
        return View();
    }
}