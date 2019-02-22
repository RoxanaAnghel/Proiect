using System;

namespace Pet.Database.Repositories
{
    public interface IPetRepository : IBaseRepository<Entities.Pet>
    {
        Entities.Pet[] getAll();
        Entities.Pet[] getAllByOwner(Guid id);

        Entities.Pet[] List(Guid? ownerId);
        void Upsert(Entities.Pet pet);

        Entities.Pet[] GetByIds(Guid[] ids);
    }
}