using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
    public interface IStateManager
    {
        void AddState(State state);
        IList<State> GetState();
        void EditState(State state);
        void DeleteState(State state);

        State FindState(int id);
    }
}
