using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEAmedia.Web.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Post/
        public ActionResult Post()
        {
            return PartialView();
        }

        //
        // GET: /Post/
        public ActionResult ClearContainer()
        {
            return PartialView();
        }
    }
}
