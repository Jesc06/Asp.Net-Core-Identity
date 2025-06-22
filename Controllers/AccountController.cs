using Asp.NetCore_Identity_Auth.Database;
using Asp.NetCore_Identity_Auth.Models;
using Asp.NetCore_Identity_Auth.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Asp.NetCore_Identity_Auth.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;

        public AccountController(SignInManager<Users> _signInManager, UserManager<Users> _userManager)
        {
            signInManager = _signInManager;
            userManager = _userManager; 
        }

        
        public IActionResult login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Trying_Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect email and password");
                }
            }
            return View("login");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Trying_Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users
                {
                    Fullname = model.Name,//ito hindi kasama sa package ng IdentityUser kaya nilagay sa User na model class
                    Email = model.Email,//ito galing sa User Model pero package siya ng IdentityUser naka inherit lang sa model Users natin kaya access
                    UserName = model.Email//ito galing sa User Model pero package siya ng IdentityUser naka inherit lang sa model Users natin kaya access
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("Register");
                }
            }
            return View("Register");
        }



        public IActionResult VerifyEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Trying_VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if(user == null)
                {
                    ModelState.AddModelError("", "Something is wrong!");
                    return View("VerifyEmail");
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account", new { username = user.UserName});
                }
            }
            return View("VerifyEmail"); 
        }



        public IActionResult ChangePassword(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("VerifyEmail","Account");
            }
            return View( new ChangePasswordViewModel { Email = username });
        }
        [HttpPost]
        public async Task<IActionResult> Trying_ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong. try again");
                return View("ChangePassword");
            }

            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email not found!");
                return View("ChangePassword");
            }

            var result = await userManager.RemovePasswordAsync(user);
            if (result.Succeeded)
            {
                result = await userManager.AddPasswordAsync(user, model.NewPassword);
                return RedirectToAction("login", "Account");
            }

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ChangePassword");
            }

            return View("ChangePassword");
        }






    }
}
