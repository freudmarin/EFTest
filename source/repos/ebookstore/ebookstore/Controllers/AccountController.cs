using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

using ebookstore.Controllers;
using ebookstore.Models.AccountViewModel;

namespace ebookstore.Web.Controllers
{

    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ebookstoreUser> _userManager;
        private readonly SignInManager<ebookstoreUser> _signInManager;
 
 

        public AccountController(
            UserManager<ebookstoreUser> userManager,
            SignInManager<ebookstoreUser> signInManager
          
            )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
           
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByNameAsync(model.Username);

            // var result = await _signInManager.PasswordSignInAsync(user., model.Password,false,false);
            //vetem admini do te drejtohet tek paneli


            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {

                    var isAdmin = await _userManager.IsInRoleAsync(user, "Admin"); //Roli ketu duhej te ishte administrator dhe jo admin ,prandaj nuk kryhej logini
                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "Books");
                    }
                    return RedirectToAction("Index", "Home");
                    //     var User = HttpContext.User;
                    //    var isAdmin = User.IsInRole("Admin");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Keni vendosur username ose fjalekalim te gabuar");

                    return View(model);
                }
            }
            else return View();
            }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        //Emaili tek register dhe username tek login jane praktikisht e njejta gje
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {


                
                var user = new ebookstoreUser { UserName = model.Username, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }


                //  var error = string.Join(", ", result.Errors);
                var message = string.Join(" Ekziston ky username ", result.Errors);
                this.ModelState.AddModelError(" ", message);

            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
        
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }



    }
}