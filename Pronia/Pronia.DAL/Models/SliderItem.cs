using Pronia.DAL.Models.Base;

namespace Pronia.DAL.Models;

public class SliderItem : BaseAuditableEntity
{
    public string Title { get; set; }
    public string ShortDesc { get; set; }
    public int Offer { get; set; }
    public string ImagePath { get; set; }
}
