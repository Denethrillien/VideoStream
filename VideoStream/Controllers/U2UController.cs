using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoStream.Controllers
{
    public class U2UController : Controller
    {
        //
        // GET: /U2U/

        public ActionResult _Messenger()
        {
            return View();
        }

        public ActionResult _Inbox()
        {
            return View();
        }

        public ActionResult _Compose()
        {
            return View();
        }

        public ActionResult _Sent()
        {
            return View();
        }
    }
}
