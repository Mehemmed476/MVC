using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.BL.Services.Abstractions;
using Pronia.DAL.Models;
using System.Collections.Generic;

namespace Pronia.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericCRUDService _service;
        public HomeController(IGenericCRUDService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderItem> sliderItems = await _service.GetAllAsync<SliderItem>();
            IEnumerable<SliderItem> LastTwoSlider = sliderItems.Where(x => x.IsDeleted == false).OrderByDescending(tm => tm.CreatedDate).Take(2);
            return View(LastTwoSlider);
        }
    }
}
