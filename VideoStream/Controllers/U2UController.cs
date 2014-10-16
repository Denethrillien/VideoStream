using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var cm = new List<Models.CommentModel>();
            using (var db = new DataEntities())
            {
                foreach (var item in db.Comments) 
                {
                    var c = new Models.CommentModel();
                    c.author_name = item.Users.user_name;
                    c.dateTime = item.date_and_time;
                    c.entry = item.entry;
                    c.isCommentFor = item.is_comment_for;
                    c.recipient = item.user_id;

                    cm.Add(c);
                }
                db.Database.Connection.Close();
            }
            return PartialView(cm);
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

                    var newPost = db.Comments.Create();

                    newPost.author_id = comment.author;
                    newPost.user_id = comment.recipient;
                    newPost.date_and_time = comment.dateTime;
                    newPost.entry = comment.entry;

                    if (comment.isCommentFor.HasValue )
                    {
                        newPost.is_comment_for = comment.isCommentFor.Value;
                    }

                    db.Comments.Add(newPost);
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
