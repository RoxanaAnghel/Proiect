using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Entities
{
    public class Pet:IEntity
    {
        public Guid ID { get; set; }

        //[ForeignKey]
        //For the user that owns the pet post
        public Guid OwnerID { get; set; }

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

    public enum Species :byte {DOG=1,CAT=2,RODENT=3,FISH=4,REPTILE=5,INSECTS=6,HORSE=7,OTHER=9 }

    public enum Color :byte { WHITE=1,BLACK=2,BROWN=3,RED=4,GRAY=5,GOLD=6,CREAM=7,FAWN=8,BLUE=9}

    public enum FurType:byte {SMOOTH=1,WHIRE=2,LONG=3,CURLY=4,NONE=0 }

    public enum Size:byte { NORMAL=1,SMALL=2,MEDIUM=3,LARGE=4,EXTRALARGE=5,TOY=6}
}
