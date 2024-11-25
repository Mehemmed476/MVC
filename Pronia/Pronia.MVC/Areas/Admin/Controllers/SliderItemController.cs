using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pronia.BL.Services.Abstractions;
using Pronia.DAL.Models;

namespace Pronia.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderItemController : Controller
    {
        private readonly IGenericCRUDService _service;

        public SliderItemController(IGenericCRUDService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            IEnumerable<SliderItem> sliderItems = await _service.GetAllAsync<SliderItem>();
            List<SliderItem> activeSliderItems = sliderItems.Where(x => x.IsDeleted == false).ToList();
            return View(activeSliderItems);
        }

        [HttpGet]
        public async Task<IActionResult> SoftDeletedSliderItems()
        {
            IEnumerable<SliderItem> SliderItems = await _service.GetAllAsync<SliderItem>();
            List<SliderItem> offlineSliderItems = SliderItems.Where(x => x.IsDeleted).ToList();
            return View(offlineSliderItems);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSliderItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSliderItem(SliderItem sliderItem)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _service.CreateAsync(sliderItem);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]

        public async Task<IActionResult> EditSliderItem(int id)
        {
            SliderItem sliderItem = await _service.GetByIdAsync<SliderItem>(id);
            return View(sliderItem);
        }

        [HttpPost]

        public async Task<IActionResult> EditSliderItem(SliderItem sliderItem)
        {
            await _service.UpdateAsync(sliderItem);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> SoftDeleteSliderItem(int id)
        {
            await _service.SoftDeleteAsync<SliderItem>(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> DeleteSliderItem(int id)
        {
            await _service.DeleteAsync<SliderItem>(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> RestoreSliderItem(int id)
        {
            await _service.RestoreAsync<SliderItem>(id);
            return RedirectToAction(nameof(SoftDeletedSliderItems));
        }

        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            SliderItem sliderItem = await _service.GetByIdAsync<SliderItem>(id);
            return View(sliderItem);
        }
    }
}
