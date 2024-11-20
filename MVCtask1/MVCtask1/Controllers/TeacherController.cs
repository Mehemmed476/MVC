using Microsoft.AspNetCore.Mvc;
using MVCtask1.Data;
using MVCtask1.Models;

namespace MVCtask1.Controllers;

public class TeacherController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(DataStore.Teachers);
    }
    
    [HttpPost]
    public IActionResult AddTeacher(Teacher teacher)
    {
        if (ModelState.IsValid)
        {
            teacher.Id = DataStore.Teachers.Count + 1;
            DataStore.Teachers.Add(teacher);

            return RedirectToAction("Index");
        }

        ViewBag.Groups = DataStore.Groups;
        return View(teacher);
    }

    [HttpGet]
    public IActionResult AddTeacher()
    {
        ViewBag.Groups = DataStore.Groups;
        return View();
    }
}