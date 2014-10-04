using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.UserModel user)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.UserModel user)
        {
            return View();
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
