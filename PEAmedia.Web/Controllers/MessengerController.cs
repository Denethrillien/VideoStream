using PEAmedia.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEAmedia.Web.Controllers
{
    public class MessengerController : Controller
    {
        //
        // GET: /Messenger/
        public ActionResult Messenger()
        {
            return PartialView();
        }

        //
        // GET: /Inbox/
        public ActionResult Inbox()
        {
            return PartialView(collectMessages(true));
        }

        //
        // GET: /Sent/
        public ActionResult Sent()
        {
            return PartialView(collectMessages(false));
        }

        //
        // GET: /Compose/
        [HttpGet]
        public ActionResult Compose()
        {
            return PartialView();
        }

        //
        // POST: /Compose/
        [HttpPost]
        public ActionResult Compose(Models.Message message)
        {
            message.Sender = User.Identity.Name;
            message.Date = System.DateTime.UtcNow;

            using (var db = new DataEntities())
            {
                if (ModelState.IsValid) 
                { 
                    var senderID = db.Users.FirstOrDefault(u => u.User_Name == message.Sender).User_ID;
                    var recipient = db.Users.FirstOrDefault(u => u.User_Name == message.Recipient);

                    if (recipient != null)
                    {
                        var newMessage = db.Messages.Create();
                        var recipientID = recipient.User_ID;

                        newMessage.Sender_ID = senderID;
                        newMessage.Recipient_ID = recipientID;
                        newMessage.Title = message.Title;
                        newMessage.Message = message.Entry;
                        newMessage.Date_Time = message.Date;

                        db.Messages.Add(newMessage);
                        db.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }
                    //Recipient doesn't exist.
                    //TODO: Handle with an error message.
                    db.Database.Connection.Close();
                }
                return PartialView(message);
            }
        }

        /// <summary>
        /// Gets the appropriate messages from database
        /// </summary>
        /// <param name="isInbox">true if Inbox, false if Sent</param>
        /// <returns>A list of Message model objects</returns>
        private List<Models.Message> collectMessages(bool isInbox)
        {
            var messages = new List<PEAmedia.Web.Models.Message>();
            using (var db = new DataEntities())
            {
                var userID = db.Users.FirstOrDefault(u => u.User_Name == User.Identity.Name).User_ID;

                //Populate message bag for Inbox. Newest entries first.
                var messageBag = (isInbox) ?
                    db.Messages.Where(m => m.Recipient_ID == userID).OrderByDescending(m => m.Message_ID).ToList() :
                    db.Messages.Where(m => m.Sender_ID == userID).OrderByDescending(m => m.Message_ID).ToList();

                foreach (var item in messageBag)
                {
                    var model = new PEAmedia.Web.Models.Message();

                    model.Date = item.Date_Time;
                    model.Sender = db.Users.FirstOrDefault(u => u.User_ID == item.Sender_ID).User_Name;
                    model.Recipient = db.Users.FirstOrDefault(u => u.User_ID == item.Recipient_ID).User_Name;
                    model.Title = item.Title;
                    model.Entry = item.Message;

                    messages.Add(model);
                }
            }
            return messages;
        }
    }
}
