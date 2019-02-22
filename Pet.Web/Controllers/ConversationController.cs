using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Database.Entities;
using Pet.Services.Conversations;
using Pet.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    public class ConversationController : Controller
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IConversationService conversationService;
        private static IMessageService messageService;

        public ConversationController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            conversationService = new ConversationService(unitOfWorkFactory);
            messageService = new MessageService(unitOfWorkFactory);
        }


        public ActionResult SendMessage(Guid id)
        {
            Database.Entities.Message m = new Database.Entities.Message() { ID = Guid.NewGuid(), ConversationId = id, Text = "buna" };
            messageService.SendMessage(m);
            return RedirectToAction("GetMessages", new { id = id });
        }

        // GET: Conversation
        public ActionResult Conversations()
        {
            Services.Conversations.Conversation[] conversations = conversationService.GetAllForUser(new Guid(User.Identity.GetUserId()));

            return View(conversations);
        }

        public ActionResult GetConversation(Guid ownerId, Guid petId)
        {
            Guid currentUser = new Guid(User.Identity.GetUserId());

            Database.Entities.Conversation conversation = conversationService.GetConversationBeetwen(currentUser, petId);

            Database.Entities.Message[] messages = messageService.GetMesagesForConversation2(conversation.ID);

            ViewBag.ConversationId = conversation.ID;

            return View(messages);
        }

        public ActionResult GetMessages(Guid id)
        {
            Database.Entities.Message[] messages = messageService.GetMesagesForConversation2(id);
            ViewBag.ConversationId = id;
            return View(messages);
        }

        // GET: Conversation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Conversation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conversation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Conversation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Conversation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Conversation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Conversation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
