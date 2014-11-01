using PEAmedia.Web.Models;
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
        [HttpGet]
        public ActionResult Post()
        {
            return PartialView();
        }

        //
        // POST: /Post/
        [HttpPost]
        public ActionResult Post(Models.Profile_Comment model)
        {
            model.Date = System.DateTime.Now;
            model.Sender = User.Identity.Name;
            //TODO: Softcode
            model.Recipient = 1;
            if (ModelState.IsValid)
            {
                using (var db = new PEAmedia.Web.Models.DataEntities())
                {
                    var newPost = db.Profile_Comments.Create();

                    newPost.Author_ID = db.Users.FirstOrDefault(u => u.User_Name == model.Sender).User_ID;
                    newPost.Recipient_ID = model.Recipient;
                    newPost.Date_Time = model.Date;
                    newPost.Comment = model.Entry;
                    newPost.Title = model.Title;

                    if (model.ReplyTo.HasValue) 
                    {
                        newPost.Is_Reply_To = model.ReplyTo;
                    }

                    db.Profile_Comments.Add(newPost);
                    db.SaveChanges();

                    return RedirectToAction("UserProfile", "User", new { uID = model.Recipient });
                }
            }
            return PartialView();
        }

        //
        // GET: /Reply/
        [HttpGet]
        public ActionResult Reply()
        {
            return PartialView();
        }

        //
        // POST: /Reply/
        [HttpPost]
        public ActionResult Reply(Models.Profile_Comment model, string cID)
        {
            int commentID = Int32.Parse(cID);
            model.Date = System.DateTime.Now;
            model.Sender = User.Identity.Name;
            //TODO: Softcode
            model.Recipient = 1;
            if (ModelState.IsValid)
            {
                using (var db = new PEAmedia.Web.Models.DataEntities())
                {
                    var newPost = db.Profile_Comments.Create();

                    newPost.Author_ID = db.Users.FirstOrDefault(u => u.User_Name == model.Sender).User_ID;
                    newPost.Recipient_ID = model.Recipient;
                    newPost.Date_Time = model.Date;
                    newPost.Comment = model.Entry;
                    newPost.Title = model.Title;
                    newPost.Is_Reply_To = commentID;

                    db.Profile_Comments.Add(newPost);
                    db.SaveChanges();

                    return RedirectToAction("UserProfile", "User", new { uID = model.Recipient });
                }
            }
            return PartialView();
        }

        //
        // GET: /Clear container/
        public ActionResult ClearContainer()
        {
            return PartialView();
        }

        //
        // GET: /ProfileComment/
        public ActionResult ProfileComment()
        {
            return PartialView(collectComments());
        }

        //
        // GET: /ProfileReply/
        public ActionResult ProfileReply(string cID)
        {
            var commentID = Int32.Parse(cID);
            return PartialView(collectReplies(commentID));
        }

        /// <summary>
        /// Gets the appropriate comments from database
        /// </summary>
        /// <returns>A list of Profile_Comment model objects</returns>
        private List<Models.Profile_Comment> collectComments()
        {
            var comments = new List<PEAmedia.Web.Models.Profile_Comment>();
            using (var db = new DataEntities())
            {
                var profileID = Int32.Parse(Request.QueryString["uID"]);

                //Populate comment bag from DB. Newest entries first.
                var commentBag = db.Profile_Comments.Where(m => m.Recipient_ID == profileID && m.Is_Reply_To == null).OrderByDescending(m => m.Comment_ID).ToList();

                foreach (var item in commentBag)
                {
                    var model = new PEAmedia.Web.Models.Profile_Comment();

                    model.entryID = item.Comment_ID;
                    model.Date = item.Date_Time;
                    model.Sender = db.Users.FirstOrDefault(u => u.User_ID == item.Author_ID).User_Name;
                    model.Title = item.Title;
                    model.Entry = item.Comment;

                    comments.Add(model);
                }
            }
            return comments;
        }

        /// <summary>
        /// Gets the appropriate replies from database
        /// </summary>
        /// <returns>A list of Profile_Comment model objects</returns>
        private List<Models.Profile_Comment> collectReplies(int cID)
        {
            var replies = new List<PEAmedia.Web.Models.Profile_Comment>();
            using (var db = new DataEntities())
            {
                //Populate comment bag from DB. Newest entries first.
                var replyBag = db.Profile_Comments.Where(m => m.Is_Reply_To == cID).OrderByDescending(m => m.Comment_ID).ToList();

                foreach (var item in replyBag)
                {
                    var model = new PEAmedia.Web.Models.Profile_Comment();

                    model.entryID = item.Comment_ID;
                    model.Date = item.Date_Time;
                    model.Sender = db.Users.FirstOrDefault(u => u.User_ID == item.Author_ID).User_Name;
                    model.Title = item.Title;
                    model.Entry = item.Comment;

                    replies.Add(model);
                }
            }
            return replies;
        }

        //
        // GET: /Uploads/
        public ActionResult Uploads()
        {
            return PartialView();
        }

        //
        // GET: /Info/
        public ActionResult Info()
        {
            return PartialView();
        }
    }
}
