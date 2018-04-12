using GuildCars.BLL.Factories;
using GuildCars.Models.Enums;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static GuildCars.UI.Controllers.ManageController;

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

        //Used to make a veiw model with filled out select lists
        private VehicleVM CreateVehicleVM()
        {
            VehicleVM model = new VehicleVM();
            model.VehicleImage = null;
            var modelManager = CarModelManagerFactory.Create();
            var makeManager = MakeManagerFactory.Create();
            var colorManager = ColorManagerFactory.Create();
            var interiorManager = InteriorManagerFactory.Create();

            //Set Select List Items
            var modelResponse = modelManager.GetAll();
            if (modelResponse.Success == true)
            {
                model.SetModelListItems(modelResponse.CarModels);
            }

            var makeResponse = makeManager.GetAll();
            if (makeResponse.Success == true)
            {
                model.SetMakeListItems(makeResponse.Makes);
            }

            var colorResponse = colorManager.GetAll();
            if (colorResponse.Success == true)
            {
                model.SetColorListItems(colorResponse.Colors);
            }

            var interiorResponse = interiorManager.GetAll();
            if (interiorResponse.Success == true)
            {
                model.SetInteriorListItems(interiorResponse.Interiors);
            }

            model.BodyStyle = Enum.GetValues(typeof(BodyStyle)).Cast<BodyStyle>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
            model.Transmissions = Enum.GetValues(typeof(Transmission)).Cast<Transmission>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            return model;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }




        /////////////////////Specials


        [HttpGet]
        public ActionResult Specials()
        {
            var model = new SpecialVM();
            var manager = SpecialManagerFactory.Create();
            var response = manager.GetAll();
            if (response.Success)
            {
                model.Specials = response.Specials;
                return View(model);
            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult AddSpecial(SpecialVM model)
        {
            if (ModelState.IsValid)
            {
                var manager = SpecialManagerFactory.Create();
                if(model.SpecialImage != null)
                {
                    if (model.SpecialImage.ContentLength > 0)
                    {
                        try
                        {
                            model.Special.ImageFileName = Path.GetFileName(model.SpecialImage.FileName);

                            var path = Path.Combine(Server.MapPath("~/Images/Specials/"), model.Special.ImageFileName);
                            model.SpecialImage.SaveAs(path);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                }
                
                var response = manager.Add(model.Special);
                
            }
            
            return RedirectToAction("Specials",model);
        }


        //Change to a DELETE method??
        [HttpGet]
        public ActionResult DeleteSpecial(int id)
        {
            var manager = SpecialManagerFactory.Create();
            var special = new Special();

            //Find the special and get the path to delete it's image
            var findResponse = manager.Get(id);
            if (findResponse.Success == true)
            {
                special = findResponse.Special;

                var path = Path.Combine(Server.MapPath("~/Images/Specials/"), special.ImageFileName);
                //Delete the special from the database
                var response = manager.Delete(id);
                if (response.Success == true)
                {
                    FileInfo fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        try
                        {
                            fi.Delete();
                        }
                        catch (IOException e)
                        {
                            throw e;
                        }
                    }
                }
            }
            return RedirectToAction("Specials");
        }





        /////////////////////Vehicles


        [HttpGet]
        public ActionResult Vehicles()
        {
            var model = new SearchVM();

            return View(model);
        }


        [HttpGet]
        public ActionResult AddVehicle()
        {
            VehicleVM model = CreateVehicleVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleVM model)
        {
            var manager = VehicleManagerFactory.Create();

            if (ModelState.IsValid)
            {
                try
                {   if(model.VehicleImage != null)
                    {
                        if (model.VehicleImage.ContentLength > 0)
                        {
                            var path = Path.Combine(Server.MapPath("~/Images/Vehicles/"), $"inventory-{model.Vehicle.VIN}.jpg");
                            model.Vehicle.ImageFileName = $"inventory-{model.Vehicle.VIN}.jpg";

                            var vehicleResponse = manager.Add(model.Vehicle);
                            if (vehicleResponse.Success)
                            {
                                model.VehicleImage.SaveAs(path);
                                return RedirectToAction("EditVehicle", new { id = model.Vehicle.VIN });
                                //return RedirectToAction("Vehicles"); //NEED TO GO TO EDIT BUT IT IS NOT WORKING
                            }
                        }
                    }
                    
                    VehicleVM retryAdd = CreateVehicleVM();
                    retryAdd.Vehicle = model.Vehicle;
                    return View(retryAdd);
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
            VehicleVM retryVM = CreateVehicleVM();
            retryVM.Vehicle = model.Vehicle;
            retryVM.VehicleImage = model.VehicleImage;

            return View(retryVM);
        }


        [HttpGet]
        public ActionResult EditVehicle(string id)
        {
            VehicleVM model = CreateVehicleVM();

            var manager = VehicleManagerFactory.Create();
            var response = manager.GetVehicle(id);

            if (response.Success == true)
            {
                model.Vehicle = response.Vehicle;
                model.SetSingleMakeAndModelListItem(model.Vehicle.Model);
                return View(model);
            }
            else
            {
                return RedirectToAction("Vehicles");
            }
        }

        [HttpPost]
        public ActionResult EditVehicle(VehicleVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.VehicleImage != null)
                {
                    try
                    {
                        if (model.VehicleImage.ContentLength > 0)
                        {
                            var path = Path.Combine(Server.MapPath("~/Images/Vehicles/"), $"iventory-{model.Vehicle.VIN}.jpg");
                            model.VehicleImage.SaveAs(path);
                            model.Vehicle.ImageFileName = $"inventory-{model.Vehicle.VIN}.jpg";
                        }
                    }
                    catch (IOException e)
                    {
                        throw e;
                    }
                }
                var manager = VehicleManagerFactory.Create();
                var vehicleResponse = manager.Edit(model.Vehicle);
                if (vehicleResponse.Success)
                {
                    return RedirectToAction("Vehicles");
                }
            }
            VehicleVM retryVM = CreateVehicleVM();
            retryVM.Vehicle = model.Vehicle;
            retryVM.VehicleImage = model.VehicleImage;

            return View(retryVM);
        }


        [HttpGet]
        public ActionResult DeleteVehicle(string id)
        {
            var manager = VehicleManagerFactory.Create();
            var getResponse = manager.GetVehicle(id);

            if (getResponse.Success)
            {
                var path = Path.Combine(Server.MapPath("~/Images/Vehicles/"), getResponse.Vehicle.ImageFileName);
                //Delete the special from the database
                var response = manager.Delete(id);
                if (response.Success)
                {
                    FileInfo fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        try
                        {
                            fi.Delete();
                            return RedirectToAction("Vehicles");
                        }
                        catch (IOException e)
                        {
                            throw e;
                        }
                    }
                }
            }
            return RedirectToAction("EditVehicle", id);
        }




        /////////////////////Makes

        [HttpGet]
        public ActionResult Makes()
        {
            var model = new MakeVM();
            var manager = MakeManagerFactory.Create();
            var response = manager.GetAll();
            if (response.Success)
            {
                model.Makes = response.Makes;
            }
            return View(model);

        }

        [HttpPost]
        public ActionResult AddMake(MakeVM model)
        {
            if (ModelState.IsValid)
            {
                model.Make.UserId = User.Identity.GetUserId();
                model.Make.UserName = User.Identity.Name;

                var manager = MakeManagerFactory.Create();
                var addResponse = manager.Add(model.Make);
                if (addResponse.Success)
                {
                    return RedirectToAction("Makes");
                }
            }
            return RedirectToAction("Makes");
        }





        /////////////////////Models


        [HttpGet]
        public ActionResult Models()
        {
            var model = new CarModelVM();
            var carModelManager = CarModelManagerFactory.Create();
            var carModelResponse = carModelManager.GetAll();
            if (carModelResponse.Success)
            {
                model.CarModels = carModelResponse.CarModels;
            }

            var makeManager = MakeManagerFactory.Create();
            var makeResponse = makeManager.GetAll();
            if (makeResponse.Success)
            {
                model.Makes = makeResponse.Makes.Select(m => new SelectListItem
                {
                    Value = m.MakeId.ToString(),
                    Text = m.MakeName
                });
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult AddModel(CarModelVM model)
        {
            if (ModelState.IsValid)
            {
                model.CarModel.UserId = User.Identity.GetUserId();
                model.CarModel.UserName = User.Identity.Name;

                var manager = CarModelManagerFactory.Create();
                var addResponse = manager.Add(model.CarModel);
            }
            return RedirectToAction("Models");
        }




        /////////////////////Users


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

            foreach (var role in editUser.Roles)
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



        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }
    }
}