using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;
using Pet.Database;

namespace Pet.Services.Pet
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public PetService(UnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void AddOrUpdate(Database.Entities.Pet pet)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.PetRepository.Upsert(pet);
                unitOfWork.Save();
            }
        }

        public void Create(Database.Entities.Pet pet)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.PetRepository.Create(pet);
                unitOfWork.Save();
            }
        }

        public void Delete(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                Database.Entities.Pet pet = GetPet(id);
                unitOfWork.PetRepository.Delete(pet);
                unitOfWork.Save();
            }
        }

        public IEnumerable<Database.Entities.Pet> GetAllPets(Guid? ownerId)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.PetRepository.List(ownerId);
            }
        }

        public Database.Entities.Pet GetPet(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.PetRepository.GetByID(id);
            }
        }

        public Database.Entities.Pet[] GetPetsForOwner(Guid id)
        {
            using(IUnitOfWork unitOfwork = unitOfWorkFactory.Create())
            {
                return unitOfwork.PetRepository.getAllByOwner(id);
            }
        }

        public void Update(Database.Entities.Pet pet)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.PetRepository.Update(pet);
                unitOfWork.Save();
            }
        }

        Database.Entities.Pet IPetService.GetPet(Guid id)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.PetRepository.GetByID(id);
            }
        }
    }
}
