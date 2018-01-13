using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Implementations
{
    class TravelClassManager : ITravelClassManager
    {
        private ITravelClassRepo tcrepo = null;


        public TravelClassManager(IUnitOfWork uow)
        {
            tcrepo = uow.GetTravelClassRepository();
        }


        public void AddTravelClass(Models.TravelClass travelClass)
        {
            tcrepo.Create(travelClass);
        }

        public IList<Models.TravelClass> GetTravelClass()
        {
            return tcrepo.All().ToList<Models.TravelClass>();
        }

        public void EditTravelClass(Models.TravelClass travelClass)
        {
            tcrepo.Update(travelClass);
        }

        public void DeleteTravelClass(int id)
        {
            tcrepo.Delete(id);
        }

        public Models.TravelClass FindTravelClass(int id)
        {
            Models.TravelClass tc = tcrepo.Find(id);
            return tc;
        }
    }
}
