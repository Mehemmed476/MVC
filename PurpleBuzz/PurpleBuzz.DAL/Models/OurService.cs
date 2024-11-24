using System.Runtime.CompilerServices;

namespace PurpleBuzz.DAL.Models;

public class OurService : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string MainImageUrl { get; set; }
    public ICollection<Work>? Works { get; set; }
    
}