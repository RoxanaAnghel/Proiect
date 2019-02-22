using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pet.Database.Repositories.Conversations
{
    public class ConversationRepository : BaseRepository<Conversation>, IConversationRepository
    {
        public ConversationRepository(PetDataContext context, UnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }

        public bool ExistsBetween(Guid userId, Guid petId)
        {
            Conversation c = GetConversationBetween(userId, petId);
            if (c==null)
            {
                return false;
            }
            return true;
        }

        public Conversation[] GetAllFor(Guid userId)
        {
            return dbSet.Where(c => c.FromID == userId || c.PetOwnerId == userId).ToArray();
        }

        public Conversation GetConversationBetween(Guid userId, Guid petId)
        {
            return dbSet.FirstOrDefault(c => c.FromID == userId && c.PetID == petId);
        }

        public Conversation[] GettAllForOwner(Guid ownerId)
        {
            return dbSet.Where(c => c.PetOwnerId == ownerId).ToArray();
        }
    }
}
