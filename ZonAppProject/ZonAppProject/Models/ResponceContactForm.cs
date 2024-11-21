namespace ZonAppProject.Models;

public class ResponceContactForm : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CompanyName { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}

