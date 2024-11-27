using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
namespace PurpleBuzz.DAL.Models;

public class OurService : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string? MainImageUrl { get; set; }
    [NotMapped]
    public IFormFile Image { get; set; }
    public ICollection<Work>? Works { get; set; }
}