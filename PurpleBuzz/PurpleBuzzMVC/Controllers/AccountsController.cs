using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.BL.DTOs;
using PurpleBuzz.BL.Services.Abstractions;
using PurpleBuzz.DAL.Models;

namespace PurpleBuzzMVC.Controllers;

public class AccountsController : Controller
{
    private readonly IGenericCRUDService _service;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountsController(IGenericCRUDService service, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _service = service;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
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

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();
        }
        AppUser? user = await _userManager.FindByEmailAsync(loginDto.UsernameOrEmail);
        if (user == null)
        {
            user = await _userManager.FindByNameAsync(loginDto.UsernameOrEmail);
            
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return View(); 
            }
        }
        
        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, true);

        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(); 
        }
        
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}