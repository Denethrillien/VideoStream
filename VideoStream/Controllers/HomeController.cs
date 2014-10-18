using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoStream.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserProfile(string id)
        {
            try
            {
                var uID = Int32.Parse(id);
                using (var db = new DataEntities())
                {
                    var user = db.Users.FirstOrDefault(u => u.user_id == uID);
                    if (user != null) 
                    {
                        return View(user);
                    }
                    db.Database.Connection.Close();
                }
            }
            catch(System.FormatException)
            {
                return null;
            }
            return View();
        }

    }
}
