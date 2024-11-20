using Microsoft.AspNetCore.Mvc;
using MVCtask1.Data;
using MVCtask1.Models;

namespace MVCtask1.Controllers;

public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(DataStore.Students);
    }
    
    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        
            student.Id = DataStore.Students.Count + 1;
            DataStore.Students.Add(student);

            return RedirectToAction("Index");
            
    }
    
    [HttpGet]
    public IActionResult AddStudent()
    {
        ViewBag.Groups = DataStore.Groups;
        return View();
    }
}