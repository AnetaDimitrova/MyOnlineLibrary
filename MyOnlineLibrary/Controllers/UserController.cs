using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyOnlineLibrary.Core.Models;
using MyOnlineLibrary.Infrastructure.Data.Models;
using MyOnlineLibrary.Models;

namespace MyOnlineLibrary.Controllers
{
    [Authorize]
    public class UserController : Controller
    {



        private readonly UserManager<LibraryUser> userManager;
        private readonly SignInManager<LibraryUser> signInManager;


        public UserController(
            UserManager<LibraryUser> _userManager,
            SignInManager<LibraryUser> _signInManager
            )
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new LibraryUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                

            };

            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {

                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }


            return View(model);
        }




        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Books");
            }
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {

                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {

                    return RedirectToAction("All", "Books");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
