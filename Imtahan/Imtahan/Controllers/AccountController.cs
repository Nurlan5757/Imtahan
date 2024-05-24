using Imtahan.Models;
using Imtahan.ViewModels.account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Imtahan.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : Controller
    {

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            AppUser appUser = new AppUser()
            {
                Name = vm.Name,
                Email = vm.Email,
                Surname = vm.Surname,
                UserName = vm.Username,
            };
            IdentityResult result = await _userManager.CreateAsync(appUser, vm.Password);
            if (result == null)
            {
                ModelState.AddModelError("", "isdifadeci adi ve yaa email yanlisdir");
            }

             return RedirectToAction(nameof(Login));

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            AppUser appUser = await _userManager.FindByNameAsync(vm.UsernameOrEmail);

            if (appUser == null)
            {
                appUser = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
                if (appUser == null)
                {
                    ModelState.AddModelError("", "isdifadeci adi ve yaa email yanlisdir");
                }
                return View(vm);
            }
                var data = await _signInManager.PasswordSignInAsync(appUser, vm.Password, true, true);         
                return RedirectToAction("Index", "Account");
            
           

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Account");
        }
    }
}
