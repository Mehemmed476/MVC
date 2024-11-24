using Microsoft.AspNetCore.Mvc.Rendering;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Areas.Admin.ViewModels;

public class WorkViewModel
{
    public Work? Work { get; set; }
    public IEnumerable<SelectListItem>? Selecteds { get; set; }
}