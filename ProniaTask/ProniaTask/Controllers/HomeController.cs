using Microsoft.AspNetCore.Mvc;
using ProniaTask.DAL;
using System.Collections.Generic;
using ProniaTask.Models;

namespace ProniaTask.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    
    public IActionResult Index()
    {
        /*SliderItem sliderItem1 = new SliderItem()
        {
            Title = "New Plant",
            ShortDesc = "Pronia, With 100% Natural, Organic & Plant Shop.", 
            Offer = 65,
            ImagePath = "1-1-524x617.png",
            CreatedDate = DateTime.Now
        };

        SliderItem sliderItem2 = new SliderItem()
        {
            Title = "New Plant",
            ShortDesc = "Pronia, With 100% Natural, Organic & Plant Shop.",
            Offer = 65,
            ImagePath = "1-2-524x617.png",
            CreatedDate = DateTime.Now
        };
        _context.SliderItems.Add(sliderItem1);
        _context.SliderItems.Add(sliderItem2);
        _context.SaveChanges();*/
        
        IEnumerable<SliderItem> sliderItems = _context.SliderItems.ToList();
        return View(sliderItems);
    }
}