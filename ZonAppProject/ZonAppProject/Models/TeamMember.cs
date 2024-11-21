namespace ZonAppProject.Models;

public class TeamMember : BaseEntity
{
    public string Name { get; set; }
    public string Profession { get; set; }
    public string ImageUrl { get; set; }
}

/*
 * John Doe
 * Business Development
 * team-01.jpg
 *
 * Jane Doe
 * Media Development
 * team-02.jpg
 *
 * Sam
 * Developer
 * team-03.jpg
*/