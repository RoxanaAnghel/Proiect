using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pet.Web.Models
{
    public class Message
    {
        public Guid? ID { get; set; }

        public Guid ConversationId { get; set; }

        public Guid? SentBy { get; set; }

        public string Text { get; set; }

        public DateTime SentDate { get; set; }

        public bool Read { get; set; }
    }
}