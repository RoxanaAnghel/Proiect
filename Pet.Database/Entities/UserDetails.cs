using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Entities
{
    public class UserDetails : IEntity
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Description { get; set; }

        public DateTime? BirthDate { get; set; }

        public string ImagineUrl { get; set; }

        public ShelterType ShelterType { get; set; }

    }

    public enum ShelterType:byte {ONG=1,NONE=2}
}
