using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC5.Models;
using MVC5.ViewModels.AuthVM;
using System.Data;
using System.Xml.Linq;

namespace MVC5.Controllers
{
    public class AuthController : Controller
    {
        SignInManager<AppUser> _signInManager { get; }
        UserManager<AppUser> _userManager { get; }
        RoleManager<AppUser> _roleManager { get; }
        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppUser> roleManager)
        {
            _signInManager = signInManager;
            _userManager=userManager;
            _roleManager=roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginVM vm)
        {
            AppUser user;
            if (vm.UsernameOrEmail.Contains("@"))
            {

                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);

            }
            else
            {
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);

            }
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is wrong");
                return View(vm);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is wrong");
                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = vm.Username,
                    Email = vm.Email,
                    Name = vm.Name,
                    Surname = vm.Surname
                };

                if (vm.Password == null)
                {
                    return View(vm);
                }
                var result = await _userManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, "User");

                    return RedirectToAction("Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }



            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

       
    }
}
