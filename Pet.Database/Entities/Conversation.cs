using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Entities
{
    public class Conversation
    {
        public Conversation()
        {
            Status = true;
        }

        public Guid ID { get; set; }

        public Guid PetOwnerId { get; set; }

        public string PetOwnerImagineUrl { get; set; }

        public Guid FromID { get; set; }

        public string FromUserImagineUrl { get; set; }

        public Guid PetID { get; set; }

        public string PetImagineUrl { get; set; }

        public bool Status { get; set; }    
}
}
