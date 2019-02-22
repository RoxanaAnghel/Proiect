using Pet.Database.Entities;
using System;

namespace Pet.Database.Repositories
{
    public interface IUserDetailsRepository : IBaseRepository<UserDetails>
    {
        UserDetails[] GetByIds(Guid[] ids);
    }
}