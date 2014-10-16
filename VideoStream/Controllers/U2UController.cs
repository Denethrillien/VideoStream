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
        public ActionResult _Comment()
        {
            return PartialView();
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
        [HttpPost]
        public ActionResult _Compose(Models.CommentModel comment)
        {
            using (var db = new DataEntities())
            {
                comment.dateTime = System.DateTime.UtcNow;
                comment.author = db.Users.FirstOrDefault(u => u.user_email == "just-alex@live.no").user_id;
                comment.recipient = db.Users.FirstOrDefault(u => u.user_email == "just-alex@live.no").user_id;

                if ( ModelState.IsValid )
                {

                    var newPost = db.Guestbook.Create();

                    newPost.author_id = comment.author;
                    newPost.user_id = comment.recipient;
                    newPost.date_and_time = comment.dateTime;
                    newPost.entry = comment.entry;

                    if (comment.isCommentFor.HasValue )
                    {
                        newPost.is_comment_for = comment.isCommentFor.Value;
                    }

                    db.Guestbook.Add(newPost);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                return View(comment);
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
