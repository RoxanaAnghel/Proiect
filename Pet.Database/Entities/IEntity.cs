using System;
using System.ComponentModel.DataAnnotations;

namespace Pet.Database.Entities
{
    public interface IEntity
    {
        [Key]
        Guid ID { get; set; }
    }
}
