using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
    public interface IUserAcountManager
    {
        void SaveUserDetails(Models.User user);
    }
}
