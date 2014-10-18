using PEAmedia.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PEAmedia.Web.Controllers
{
    public class UserController : Controller
    {
        //
        //GET: /UserProfile/
        [HttpGet]
        public ActionResult UserProfile(string uID) 
        {
            try
            {
                var temp = Int32.Parse(uID);
                using (var db = new DataEntities())
                {
                    var user = db.Users.FirstOrDefault(u => u.User_ID == temp);
                    //If the user exists,
                    if (user != null)
                    {
                        //Return user profile
                        var model = new Models.UserProfile(user.User_Name);
                        return View(model);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception)
            { 

            }
            return View();
        }
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Login/
        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            //User validation
            if (ModelState.IsValid)
            {
                if (isValid(user.userName, user.password))
                {
                    FormsAuthentication.SetAuthCookie(user.userName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login data");
                }
            }
            return View(user);
        }

        //
        // /Logout/
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Register/
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Register/
        [HttpPost]
        public ActionResult Register(Models.User user)
        {
            //User registration
            if (ModelState.IsValid)
            {
                using (var db = new DataEntities())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encryptedPassword = crypto.Compute(user.password);
                    var newUser = db.Users.Create();

                    newUser.User_Name = user.userName;
                    newUser.User_Email = user.eMail;
                    newUser.Password = encryptedPassword;
                    newUser.Password_Salt = crypto.Salt;

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(user);
        }

        //
        // Validate user
        private bool isValid(string userName, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool isValid = false;

            using (var db = new DataEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.User_Name == userName);
                //If the user exists in database,
                if (user != null)
                {
                    //continue validating.
                    if (user.Password == crypto.Compute(password, user.Password_Salt))
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
