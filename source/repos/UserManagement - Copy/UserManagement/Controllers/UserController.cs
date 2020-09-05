using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using UserManagement.Identity;
using UserManagement.ViewModels;

namespace UserManagement.Controllers
{
    public class UserController : Controller
    {


        public UserController()
        {



        }


        public ActionResult Index()
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);

            return View(appDbContext.Users.Where(user => user.UserName != "Admin"));
        }
        // GET: User

        [HttpGet]
        public ActionResult AddUser()
        {


            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);

                ApplicationUser user = new ApplicationUser
                {
                    name = model.Name,
                    UserName = model.UserName,
                    Email = model.Email,
                    PasswordHash = Crypto.HashPassword(model.Password),
                };
                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {

                    var role = new IdentityRole();
                    role.Name = "user";
                    roleManager.Create(role);

                    IdentityResult roleResult = userManager.AddToRole(user.Id, role.Name);
                }

                return RedirectToAction("Index", "User");

            }
            else
            {
                ModelState.AddModelError("", "Invalid data");

                return View(model);
            }

        }

        public ActionResult Details(string Id)
        {
            var appDbContext = new ApplicationDbContext();
            ApplicationUser u = appDbContext.Users.Where(temp => temp.Id == Id).FirstOrDefault();
            return View(u);
        }
        public ActionResult Edit(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser user = userManager.FindById(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            var appDbContext = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);



            ApplicationUser user2 = userManager.FindById(user.Id);
            if (user2 != null)
            {
                if (!string.IsNullOrEmpty(user.name))
                    user2.name = user.name;
                else
                    ModelState.AddModelError("", "Emri nuk duhet te jete bosh");
                if (!string.IsNullOrEmpty(user.Email))
                    user2.Email = user.Email;
                else
                    ModelState.AddModelError("", "Emaili nuk duhet te jete bosh");

                if (!string.IsNullOrEmpty(user.PasswordHash))
                    user2.PasswordHash = user.PasswordHash;
                else
                    ModelState.AddModelError("", "Passwordi nuk duhet te jete bosh");
                if (!string.IsNullOrEmpty(user.UserName))
                    user2.UserName = user.UserName;
                else
                    ModelState.AddModelError("", "UserName nuk duhet te jete bosh");
                if (!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.name) && !string.IsNullOrEmpty(user.PasswordHash))
                {


                    IdentityResult result = userManager.Update(user2);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "User");
                    else
                        return View();
                }
            }
            else

                ModelState.AddModelError("", "Useri nuk u gjet");
                return View(user2);

            }
        public ActionResult Delete(string Id)
        {
            var appDbContext = new ApplicationDbContext();
            ApplicationUser appUser = appDbContext.Users.Where(temp => temp.Id == Id).FirstOrDefault();
            return View(appUser);

        }
        [HttpPost]
        public ActionResult Delete(string Id,ApplicationUser application)
        {

            var appDbContext = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser user =  userManager.FindById(Id);
            if (user != null)
            {
                IdentityResult result =  userManager.Delete(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
          
            }
            else
                ModelState.AddModelError("", "Useri nuk u gjet");
            return View("Index", userManager.Users);
        }
    }
    }



    

        
    



            
        
        


    
