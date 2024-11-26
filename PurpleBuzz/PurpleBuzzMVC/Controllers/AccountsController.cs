using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzz.BL.DTOs;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Controllers;

public class AccountsController : Controller
{
    private readonly IGenericCRUDService _service;

    public AccountsController(IGenericCRUDService service, UserManager<AppUser> userManager)
    {
        _service = service;
        _userManager = userManager;
    }

    private readonly UserManager<AppUser> _userManager;
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Register(CreateUserDTO createUserDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createUserDto);
        }

        AppUser user = new();
        user.FirstName = createUserDto.FirstName;
        user.LastName = createUserDto.LastName;
        user.Email = createUserDto.Email;
        user.UserName = createUserDto.NickName;
        var result = await _userManager.CreateAsync(user, createUserDto.Password);
        if (!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            return View(createUserDto);
        }
        
        return RedirectToAction("Index", "Home");
    }
}