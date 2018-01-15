using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using OpticSolutions.Models;
using OpticSolutions.Repositories.Entitys;
using OpticSolutions.Services;
using OpticSolutions.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
   
    public class AuthController : Controller
    {

        private readonly UserManager<AppUser> userManager;
        private UserService repo;


        public AuthController()
            : this(Startup.UserManagerFactory.Invoke())
        {
            repo = new UserService();
        }

      
        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }

        public string ReturnUrl { get; private set; }

        [AllowAnonymous]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel();
            {
                ReturnUrl = returnUrl;
           };

            return View(model);
        }

        [MyAuthorize(Roles = "Administrador")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [MyAuthorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult> Register([Bind(Exclude = "UserPhoto")]RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // To convert the user uploaded Photo as Byte Array before save to DB
            byte[] imageData = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);
                }
            }
            

            var user = new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Phone = model.Phone,
                CreatedDate = DateTime.Now,
                UserPhoto = imageData
        };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                AddUserToRole(model.Email, model.UserRole);
                await SignIn(user);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                AppUser data = repo.GetUserInfoById(model.Email);
                var identity = await userManager.CreateIdentityAsync(
                    user, DefaultAuthenticationTypes.ApplicationCookie);
                identity.AddClaims(new[] {
                new Claim("FullName",data.FirstName+" "+data.LastName),
               new Claim("UserCreatedDate",data.CreatedDate.ToShortDateString())
                   });


                GetAuthenticationManager().SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        [AllowAnonymous]
        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        [AllowAnonymous]
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        [AllowAnonymous]
        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            //AppUser data = repo.GetUserInfoById(user.Email);

            //identity.AddClaims(new[] {
            //    new Claim("FullName",data.FirstName+" "+data.LastName),
            //   new Claim("UserCreatedDate",data.CreatedDate.ToShortDateString())
            //       });

            GetAuthenticationManager().SignIn(identity);
         
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        public ActionResult ProfileMenu()
        {

            var data = repo.GetUserInfoById(HttpContext.User.Identity.Name);

            return View(data);
        }

        [HttpPost]
        public ActionResult ProfileMenu([Bind(Exclude = "UserPhoto")]AppUser pro)
        {
            // To convert the user uploaded Photo as Byte Array before save to DB
            byte[] imageData = null;
            HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

            using (var binary = new BinaryReader(poImgFile.InputStream))
            {
                imageData = binary.ReadBytes(poImgFile.ContentLength);
            }


            if (imageData.Length > 0)
            {
                pro.UserPhoto = imageData;
            }
            else
            {
                pro.UserPhoto = null;
            }

          
            pro.UserName = User.Identity.Name;
            repo.EditProfile(pro);
            //AddUserToRole(pro.UserName, "Administrador");

           var data = repo.GetUserInfoById(HttpContext.User.Identity.Name);
            return View(data);
        }


        public JsonResult GetDoctors()
        {

            var list = repo.GetDoctors();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        internal void AddUserToRole(string userName, string roleName)
        {
            AppDbContext context = new AppDbContext();
            var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));

            try
            {
                var user = UserManager.FindByName(userName);
                UserManager.AddToRole(user.Id, roleName);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public static string GetUserRole(string username)
        {
            AppDbContext context = new AppDbContext();
            List<string> ListOfRoleNames = new List<string>();
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

          
            var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var ListOfRoleIds = UserManager.FindByName(username).Roles.Select(x => x.RoleId).ToList();

            foreach (string id in ListOfRoleIds)
            {
                string rolename = RoleManager.FindById(id).Name;
                ListOfRoleNames.Add(rolename);
            }

            return ListOfRoleNames.FirstOrDefault();
        }
        [MyAuthorize(Roles = "Administrador")]
        public ActionResult ViewUsers()
        {
            var data = repo.GetUsers();

            return View(data);
        }

    }
}