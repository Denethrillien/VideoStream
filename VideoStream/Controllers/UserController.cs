using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace VideoStream.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _Login(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (isValid(user.email, user.password))
                {
                    FormsAuthentication.SetAuthCookie(user.email, false);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ModelState.AddModelError("", "Incorrect login data");
                }
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult _Register() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult _Register(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                using(var db = new DataEntities())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encryptedPassword = crypto.Compute(user.password);
                    var newUser = db.Users.Create();

                    newUser.E_mail = user.email;
                    newUser.Password = encryptedPassword;
                    newUser.PasswordSalt = crypto.Salt;
                    newUser.UserID = Guid.NewGuid();
                    newUser.Username = user.userName;

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(user);
        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool isValid(string eMail, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool isValid = false;

            using(var db = new DataEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.E_mail == eMail);
                //If the user exists,
                if (user != null) 
                { 
                    //continue validating.
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    { 
                        //Validated
                        isValid = true;
                    }
                }
            }
            return isValid;
        }
    }
}
