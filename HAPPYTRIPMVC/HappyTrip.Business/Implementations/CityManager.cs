using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Implementations
{
    internal class CityManager : ICityManager
    {
        private ICityRepo cityRepo = null;
        private IStateRepo stateRepo = null;

        public CityManager(IUnitOfWork uow)
        {
            this.cityRepo = uow.GetCityRepository();
            this.stateRepo = uow.GetStateRepository();
        }

        public void AddCity(Models.City city)
        {
            cityRepo.Create(city);
        }

        public IList<Models.City> GetCity()
        {
            return cityRepo.All().ToList<Models.City>();
        }

        public void EditCity(Models.City city)
        {
            cityRepo.Update(city);
        }

        public void DeleteCity(int id)
        {
            cityRepo.Delete(id);
        }

        public Models.City FindCity(int id)
        {
            Models.City city = cityRepo.Find(id);
            return city;
        }


        public List<Models.State> GetAllState()
        {
            return stateRepo.All().ToList<Models.State>();
        }
    }
}
