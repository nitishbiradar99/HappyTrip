using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Implementations
{
    internal class StateManager : IStateManager
    {
        private IStateRepo repoState = null;

        public StateManager(IUnitOfWork uow)
        {
            repoState = uow.GetStateRepository();
        }

        public void AddState(Models.State state)
        {
            repoState.Create(state);
        }

        public IList<Models.State> GetState()
        {
            return repoState.All().ToList<State>();
        }

        public void EditState(Models.State state)
        {
            repoState.Update(state);
        }

        public void DeleteState(Models.State state)
        {
            repoState.Delete(state);
        }

        public Models.State FindState(int id)
        {
            State s = repoState.Find(id);
            return s;
        }
    }
}
