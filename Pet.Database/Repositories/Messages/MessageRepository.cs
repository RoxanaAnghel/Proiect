using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pet.Database.Repositories.Messages
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(PetDataContext context, UnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        public Message[] GetAllForConversation(Guid conversationId)
        {
            return dbSet.Where(m => m.ConversationId == conversationId).OrderByDescending(m => m.SentDate).ToArray();
        }

        public Message[] GetAllMessagesForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Message[] GetMessagesBetweenUsers(Guid user1, Guid user2)
        {
            throw new NotImplementedException();
        }

        public Message[] GetMessegesBetweenUsersForPet(Guid to, Guid from, Guid pet)
        {
            throw new NotImplementedException();
        }

        //public Message[] GetAllMessagesForUser(Guid userId)
        //{
        //    return dbSet.Where(m => m.FromId == userId || m.ToId == userId).OrderBy(m => m.SentDate).ToArray();
        //}

        //public Message[] GetMessagesBetweenUsers(Guid user1, Guid user2)
        //{
        //    return dbSet.Where(m => (m.FromId == user1 && m.ToId == user2)).OrderBy(m => m.SentDate).ToArray();
        //}

        //public Message[] GetMessagesForUser(Guid ForUser)
        //{
        //    return dbSet.Where(m => m.ToId == ForUser).OrderBy(m => m.SentDate).ToArray();
        //}

        //public Message[] GetMessegesBetweenUsersForPet(Guid to, Guid from, Guid pet)
        //{
        //    return dbSet.Where(m => (m.FromId == from && m.ToId == to && m.PetId == pet)).OrderBy(m => m.SentDate).ToArray();
        //}
    }
}