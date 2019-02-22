using Pet.Database.Repositories;
using Pet.Database.Repositories.Conversations;
using Pet.Database.Repositories.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database
{
    public interface IUnitOfWork:IDisposable
    {
        IPetRepository PetRepository { get;}
        IUserDetailsRepository UserDetailsRepository { get; }
        IMessageRepository MessageRepository { get;}
        IConversationRepository ConversationRepository { get; }
        void Save();
    }
}
