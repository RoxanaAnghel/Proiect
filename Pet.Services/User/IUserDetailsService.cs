using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Services.User
{
    public interface IUserDetailsService
    {
        UserDetails GetUserDetails(Guid id);
        void Create(UserDetails userDetails);
        void Update(UserDetails userDetails);
    }
}
