using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Entities
{
    public class Message:IEntity
    {
        public Guid ID { get; set; }

        public Guid ConversationId { get; set; }

        public Guid SentBy { get; set; }

        public string Text { get; set; }

        public DateTime SentDate { get; set; }

        public bool Read { get; set; }
    }
}


