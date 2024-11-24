namespace PurpleBuzz.DAL.Models;

public class Work : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string MainImageUrl { get; set; }
    public int OurServiceId { get; set; }
    public OurService OurService { get; set; }
}