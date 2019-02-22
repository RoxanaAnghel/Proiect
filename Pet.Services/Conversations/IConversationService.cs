using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Services.Conversations
{
    public interface IConversationService
    {
        Database.Entities.Conversation GetConversationBeetwen(Guid userId, Guid petId);
        Database.Entities.Conversation GetById(Guid id);

        Conversation[] GetAllForUser(Guid userId);
        Conversation GetById_(Guid conversationId,Guid current);
        Conversation[] GetAllForPet(Guid petId,Guid ownerId);
    }


    public class Conversation
    {
        public Guid ID { get; set; }

        public Guid YourId { get; set; }

        public string YourImagineUrl { get; set; }

        public Guid WithID { get; set; }

        public string WithImagineUrl { get; set; }

        public Guid PetID { get; set; }

        public string PetImagineUrl { get; set; }

        public bool Active { get; set; }

        public string WithName { get; set; }
    }
}
