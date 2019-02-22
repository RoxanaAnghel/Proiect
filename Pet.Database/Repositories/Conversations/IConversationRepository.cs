using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Repositories.Conversations
{
    public interface IConversationRepository:IBaseRepository<Conversation>
    {
        Conversation[] GetAllFor(Guid userId);

        Conversation GetConversationBetween(Guid userId, Guid petId);

        Conversation[] GettAllForOwner(Guid ownerId);

        bool ExistsBetween(Guid userId, Guid petId);
    }
}
