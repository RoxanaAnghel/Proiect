using Pet.Database.Entities;
using System;

namespace Pet.Web.Models
{
    public class Pet
    {
        public Guid? ID { get; set; }

        public Guid? OwnerID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public Species Species { get; set; }

        public string Breed { get; set; }

        public bool PureBreed { get; set; }

        public Color MainColour { get; set; }

        public FurType FurType { get; set; }

        public Size Size { get; set; }

        public bool Adopted { get; set; }

        public bool BirthDate { get; set; }
    }
}