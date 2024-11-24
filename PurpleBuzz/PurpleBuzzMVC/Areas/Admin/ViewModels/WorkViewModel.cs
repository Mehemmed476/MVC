using Microsoft.AspNetCore.Mvc.Rendering;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Areas.Admin.ViewModels;

public class WorkViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string MainImageUrl { get; set; }
    public int OurServiceId { get; set; }
    public IEnumerable<SelectListItem>? Selecteds { get; set; }
}