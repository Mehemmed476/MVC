using System.ComponentModel.DataAnnotations;

namespace PurpleBuzz.BL.DTOs;

public class LoginDTO
{
    [Required, Display(Prompt = "Username or Email...")]
    public string UsernameOrEmail { get; set; }
    [Required, Display(Prompt = "Password..."), DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}