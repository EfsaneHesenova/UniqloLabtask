using EmployeeMVC.DAL;
using EmployeeMVC.DTOs.UserDTOs;
using EmployeeMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountsController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    FirstName = createUserDto.FirstName,
                    LastName = createUserDto.LastName,
                    Email = createUserDto.Email,
                    UserName = createUserDto.UserName
                };
                var result = await _userManager.CreateAsync(appUser, createUserDto.Password);
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
            return View(createUserDto);
        }

        public IActionResult Login()
        { return View(); }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login");
                return View();
            }
            AppUser? user = await _userManager.FindByEmailAsync(loginUserDto.EmailOrUsername);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(loginUserDto.EmailOrUsername);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                    return View();
                }
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, loginUserDto.isPersistant, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login");
                return View();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
