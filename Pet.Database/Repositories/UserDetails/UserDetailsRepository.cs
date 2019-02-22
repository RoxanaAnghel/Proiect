using Pet.Database.Entities;
using System;
using System.Linq;

namespace Pet.Database.Repositories
{
    public class UserDetailsRepository : BaseRepository<UserDetails>, IUserDetailsRepository
    {
        public UserDetailsRepository(PetDataContext dbContext, UnitOfWork unitOfWork) :
            base(dbContext, unitOfWork)
        { }

        public UserDetails[] GetByIds(Guid[] ids)
        {
            return dbSet.Where(x => ids.Contains(x.ID)).ToArray();
        }
    }
}