namespace PurpleBuzz.DAL.Models;

public class Work : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string MainImageUrl { get; set; }
}