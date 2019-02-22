using Pet.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Repositories.Messages;
using Pet.Database.Repositories.Conversations;

namespace Pet.Database
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private readonly PetDataContext dbContext;

        private IPetRepository petRepository;
        private IUserDetailsRepository userDetailsRepository;
        private IMessageRepository messageRepository;
        private IConversationRepository conversationRepository;

        public IUserDetailsRepository UserDetailsRepository
        {
            get
            {
                if (userDetailsRepository == null)
                {
                    userDetailsRepository = new UserDetailsRepository(dbContext, this);
                }
                return userDetailsRepository;
            }
        }

        public IPetRepository PetRepository
        {
            get
            {
                if (petRepository == null)
                {
                    petRepository = new PetRepository(dbContext, this);
                }
                return petRepository;
            }
        }

        public IMessageRepository MessageRepository
        {
            get
            {
                if (messageRepository == null)
                {
                    messageRepository = new MessageRepository(dbContext, this);
                }
                return messageRepository;
            }
        }

        public IConversationRepository ConversationRepository
        {
            get
            {
                if (conversationRepository==null)
                {
                    conversationRepository = new ConversationRepository(dbContext, this);
                }
                return conversationRepository;
            }
        }

        public UnitOfWork(IConfig config)
        {
            dbContext = new PetDataContext();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }

        
    }
}
