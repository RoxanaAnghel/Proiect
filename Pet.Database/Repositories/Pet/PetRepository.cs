using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;
using System.Data.Entity.Migrations;

namespace Pet.Database.Repositories
{
    public class PetRepository : BaseRepository<Entities.Pet>, IPetRepository
    {
        public PetRepository(PetDataContext dbContext, UnitOfWork unitOfWork) :
            base(dbContext, unitOfWork)
        { }

        public Entities.Pet[] getAll()
        {
            return dbSet.ToArray();
        }

        public Entities.Pet[] getAllByOwner(Guid id)
        {
            return dbSet.Where(p => p.OwnerID == id).ToArray();
        }

        public Entities.Pet[] GetByIds(Guid[] ids)
        {
            return dbSet.Where(x => ids.Contains(x.ID)).ToArray();
        }

        public Entities.Pet[] List(Guid? ownerId)
        {
            IQueryable<Entities.Pet> petQuery = dbSet;

            if (ownerId.HasValue)
                petQuery = petQuery.Where(pet => pet.OwnerID == ownerId.Value);

            return petQuery.ToArray();
        }

        public void Upsert(Entities.Pet pet)
        {
            dbSet.AddOrUpdate(pet);
        }
    }
}