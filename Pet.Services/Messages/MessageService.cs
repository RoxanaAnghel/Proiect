using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;
using Pet.Database;

namespace Pet.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public MessageService(UnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public Database.Entities.Message[] GetAll()
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetAll();
            }
        }

        public Database.Entities.Message[] GetAllMessages(Guid userId)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetAllMessagesForUser(userId);
            }
        }

        public List<Database.Entities.Message[]> GetAllMessagesForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Database.Entities.Message[] GetMesagesBetween(Guid user1, Guid user2)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetMessagesBetweenUsers(user1, user2);
            }
        }

        public Message[] GetMesagesForConversation(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                Database.Entities.Message[] dbMessages= unitOfWork.MessageRepository.GetAllForConversation(id);
                List<Message> messages = new List<Message>();

                foreach (var message in dbMessages)
                {
                    Message m = new Message
                    {
                        ConversationId = message.ConversationId,
                        ID = message.ID,
                        Read = message.Read,
                        SentDate = message.SentDate,
                        Text = message.Text,
                        SendBy = message.SentBy
                    };
                    messages.Add(m);
                }

                return messages.ToArray();
            }
        }

        /////////
        public Database.Entities.Message[] GetMesagesForConversation2(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.MessageRepository.GetAllForConversation(id);
            }
        }
        /////////
        public Database.Entities.Message[] GetMessegesBetwenForPet(Guid to, Guid from, Guid pet)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                Database.Entities.Message[] m1 =unitOfWork.MessageRepository.GetMessegesBetweenUsersForPet(to, from, pet);
                Database.Entities.Message[] m2 = unitOfWork.MessageRepository.GetMessegesBetweenUsersForPet(from, to, pet);
                Database.Entities.Message[] r = m1.Concat(m2).OrderBy(m => m.SentDate).ToArray();
                return r;
            }
        }

        public void SendMessage(Database.Entities.Message message)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                message.SentDate = DateTime.Now;
                unitOfWork.MessageRepository.Create(message);
                unitOfWork.Save();
            }
        }
    }
}
