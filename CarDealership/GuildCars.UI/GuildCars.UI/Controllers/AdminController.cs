using GuildCars.BLL.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        



        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Specials()
        {
            var model = new SpecialsVM();
            var manager = SpecialManagerFactory.Create();
            var response = manager.GetAll();
            if (response.Success == true)
            {
                model.Specials = response.Specials;
            }
            //What to do if success is false?? 
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSpecial(Special special)
        {
            //Add a specail to the database

            //return to specials page with all the specials updated
            var model = new SpecialsVM();
            var manager = SpecialManagerFactory.Create();
            var response = manager.GetAll();
            if (response.Success == true)
            {
                model.Specials = response.Specials;
            }
            return View("Specials", model);
        }

        [HttpDelete]
        public ActionResult DeleteSpecial(int id)
        {
            //Delete the special from the database


            //Refresh page with updated specials
            var model = new SpecialsVM();
            var manager = SpecialManagerFactory.Create();
            var response = manager.GetAll();
            if (response.Success == true)
            {
                model.Specials = response.Specials;
            }
            return View("Specials", model);
        }


        [HttpGet]
        public ActionResult Makes()
        {
            var model = new MakesVM();
            var manager = MakeManagerFactory.Create();
            var response = manager.GetAll();
            if(response.Success == true)
            {
                model.Makes = response.Makes;
            }
            return View(model);

        }

        //Add Make



        [HttpGet]
        public ActionResult Models()
        {
            var model = new CarModelsVM();
            var carModelManager = CarModelManagerFactory.Create();
            var carModelResponse = carModelManager.GetAll();
            if (carModelResponse.Success == true)
            {
                model.CarModels = carModelResponse.CarModels;
            }

            var makeManager = MakeManagerFactory.Create();
            var makeResponse = makeManager.GetAll();
            if (makeResponse.Success == true)
            {
                model.Makes = makeResponse.Makes.Select(m => new SelectListItem
                {
                    Value = m.MakeId.ToString(),
                    Text = m.MakeName
                });
            }

            return View(model);
        }


        public ActionResult Users()
        {
            var context = new ApplicationDbContext();

            var adminRole = (from r in context.Roles where r.Name.Contains("Admin") select r).FirstOrDefault();
            var adminUsers = context.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(adminRole.Id));

            var adminVM = adminUsers.Select(user => new UserVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = "Admin"
            }).ToList();


            var salesRole = (from r in context.Roles where r.Name.Contains("Sales") select r).FirstOrDefault();
            var salesUsers = context.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(salesRole.Id));

            var salesVM = salesUsers.Select(user => new UserVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = "Sales"
            }).ToList();


            var disabledRole = (from r in context.Roles where r.Name.Contains("Disabled") select r).FirstOrDefault();
            var disabledUsers = context.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(disabledRole.Id));

            var disabledVM = disabledUsers.Select(user => new UserVM
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = "Disabled"
            }).ToList();

            UserGroupVM userGroups = new UserGroupVM
            {
                Admins = adminVM,
                Sales = salesVM,
                Disabled = disabledVM
            };

            return View(userGroups);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            var context = new ApplicationDbContext();
            var roles = context.Roles;

            var model = new RegisterViewModel();
            model.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Id,
                Text = r.Name
            });

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model)
        {
            var context = new ApplicationDbContext();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                    var role = roleMgr.FindById(model.Role);

                    UserManager.AddToRole(user.Id, role.Name);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Users", "Admin");
                }
                AddErrors(result);
            }
            var roles = context.Roles;

            model.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Id,
                Text = r.Name
            });

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var context = new ApplicationDbContext();

            var editUser = UserManager.FindById(id);
            var roles = context.Roles;

            var model = new RegisterViewModel();
            model.Roles = roles.Select(r => new SelectListItem
            {
                Value = r.Id,
                Text = r.Name
            });
            model.Id = editUser.Id;
            model.FirstName = editUser.FirstName;
            model.LastName = editUser.LastName;
            model.Email = editUser.Email;

            foreach(var role in editUser.Roles)
            {
                model.Role = role.RoleId;
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult EditUser(RegisterViewModel model)
        {
            var context = new ApplicationDbContext();
            var roles = context.Roles;
            var user = UserManager.FindById(model.Id);

            var oldRole = user.Roles.SingleOrDefault().RoleId;

            //Change password if not empty
            if (!string.IsNullOrEmpty(model.PasswordEdit))
            {
                user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.PasswordEdit);
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            
            //Drop and add roles if changed
            if (!user.Roles.Any(r => r.RoleId == model.Role))
            {
                var dbUser = context.Users.SingleOrDefault(u => u.Id == model.Id);
                dbUser.Roles.Clear();
                context.SaveChanges();

                var role = roles.Where(r => r.Id == model.Role).Select(r => r.Name).SingleOrDefault();
                UserManager.RemoveFromRole(user.Id, oldRole);
                UserManager.AddToRole(user.Id, role);
            }
            UserManager.Update(user);

            return RedirectToAction("Users");
        }
    }
}