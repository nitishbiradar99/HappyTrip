using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;

namespace HappyTrip.Business.Implementations
{
    public class UserAcountManager : IUserAcountManager
    {
        private IUserAcountRepository repository = null;
        public UserAcountManager(IUnitOfWork uow)
        {
            repository = uow.GetUserAcountRepository();
        }
        /// <summary>
        /// Method To Save Details Of User
        /// </summary>
        /// <param name="user"></param>
        public void SaveUserDetails(Models.User user)
        {
            repository.Create(user);
        }
    }
}
