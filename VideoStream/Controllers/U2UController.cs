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
        [HttpGet]
        public ActionResult _Messenger()
        {
            if (Request.IsAuthenticated)
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult _Inbox()
        {
            if (Request.IsAuthenticated)
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult _Compose()
        {
            if (Request.IsAuthenticated)
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult _Sent()
        {
            if (Request.IsAuthenticated)
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult _Guestbook()
        {
            return PartialView();
        }
        public ActionResult _ClearGuestBookComposer()
        {
            return PartialView();
        }
    }
}
