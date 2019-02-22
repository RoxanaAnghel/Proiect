using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;
using Pet.Database;

namespace Pet.Services.User
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public UserDetailsService(UnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(UserDetails userDetails)
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.UserDetailsRepository.Create(userDetails);
                unitOfWork.Save();
            }
        }

        public UserDetails GetUserDetails(Guid id)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.UserDetailsRepository.GetByID(id);
            }
        }

        public void Update(UserDetails userDetails)
        {
            using(IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.UserDetailsRepository.Update(userDetails);
                unitOfWork.Save();
            }
        }
    }
}
