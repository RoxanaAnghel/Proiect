using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Services.Messages
{
    public interface IMessageService
    {
        Database.Entities.Message[] GetMesagesBetween(Guid user1, Guid user2);
        void SendMessage(Database.Entities.Message message);

        //
        Database.Entities.Message[] GetAll();
        Database.Entities.Message[] GetMessegesBetwenForPet(Guid to, Guid from, Guid pet);
        List<Database.Entities.Message[]> GetAllMessagesForUser(Guid userId);
        Database.Entities.Message[] GetAllMessages(Guid userId);
        Database.Entities.Message[] GetMesagesForConversation2(Guid id);

        Message[] GetMesagesForConversation(Guid id);
    }

    public class Message
    {
        public Guid ID { get; set; }

        public Guid ConversationId { get; set; }

        public Guid SendBy { get; set; }

        public string Text { get; set; }

        public DateTime SentDate { get; set; }

        public bool Read { get; set; }
    }
}
