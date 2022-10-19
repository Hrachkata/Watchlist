using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models.UserViewModels;

namespace Watchlist.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;

        private readonly UserManager<User> userManager;

        private readonly WatchlistDbContext data;

        public UserController(
            SignInManager<User> _signInManager,
            UserManager<User> _userManager,
            WatchlistDbContext _data)
        {
            signInManager = _signInManager;

            userManager = _userManager;

            data = _data;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new UserRegisterViewModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if(!ModelState.IsValid) return View(model);

            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                
            };
            
            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
                
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            
            return View(model);

        }

        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
            signInManager.SignOutAsync();
            }


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new UserLoginViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "User does not exist.");

                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or password incorrect.");

            return View(model);
        }
    }
}
