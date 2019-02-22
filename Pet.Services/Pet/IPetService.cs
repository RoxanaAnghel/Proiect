using System;
using System.Collections.Generic;

namespace Pet.Services.Pet
{
    public interface IPetService
    {
        IEnumerable<Database.Entities.Pet> GetAllPets(Guid? ownerId);

        void Delete(Guid id);

        void Update(Database.Entities.Pet pet);

        Database.Entities.Pet GetPet(Guid id);

        void Create(Database.Entities.Pet pet);

        void AddOrUpdate(Database.Entities.Pet pet);

        Database.Entities.Pet[] GetPetsForOwner(Guid id);
    }
}