using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Repositories.Messages
{
    public interface IMessageRepository:IBaseRepository<Message>
    {
        Message[] GetMessagesBetweenUsers(Guid user1,Guid user2);
        Message[] GetMessegesBetweenUsersForPet(Guid to, Guid from, Guid pet);
        Message[] GetAllMessagesForUser(Guid userId);

        Message[] GetAllForConversation(Guid conversationId);
    }
}
