namespace PurpleBuzz.DAL.Models;

public class TeamMember : BaseEntity
{
    public string Name { get; set; }
    public string Profession { get; set; }
    public string ImageUrl { get; set; }
}