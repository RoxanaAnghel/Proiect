using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Services.Conversations;
using System;
using System.Web.Http;

namespace Pet.Web.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/conversations")]
    public class ConversationsController : ApiController
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IConversationService conversationService;

        public ConversationsController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            conversationService = new ConversationService(unitOfWorkFactory);
        }

        [HttpGet]
        public IHttpActionResult GetConversations(Guid? petId = null)
        {
            Guid userId = new Guid(User.Identity.GetUserId());

            if (petId.HasValue)
            {
                return Ok(conversationService.GetConversationBeetwen(userId, petId.Value));
            }
            else
            {
                return Ok(conversationService.GetAllForUser(userId));
            }
        }

        [HttpGet]
        public IHttpActionResult GetConversation(Guid id)
        {
            Guid current = new Guid(User.Identity.GetUserId());
            return Ok(conversationService.GetById_(id,current));
        }

        [Route("pet")]
        [HttpGet]
        public IHttpActionResult GetConversationForPet(Guid petId)
        {
            Guid user = new Guid(User.Identity.GetUserId());
            return Ok(conversationService.GetAllForPet(petId, user));
        }
    }
}
