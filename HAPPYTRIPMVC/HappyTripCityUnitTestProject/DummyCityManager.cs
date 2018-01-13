using HappyTrip.Business.Contracts;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTripCityUnitTestProject
{
    class DummyCityManager:ICityManager
    {
        List<City> cities = null;
        public DummyCityManager(List<City> cities)
        {

            this.cities = cities;
        }
        public void AddCity(HappyTrip.Models.City city)
        {
            throw new NotImplementedException();
        }

        public IList<HappyTrip.Models.City> GetCity()
        {
            return cities;
        }

        public void EditCity(HappyTrip.Models.City city)
        {
            throw new NotImplementedException();
        }

        public void DeleteCity(int id)
        {
            throw new NotImplementedException();
        }

        public HappyTrip.Models.City FindCity(int id)
        {
            throw new NotImplementedException();
        }

        public List<HappyTrip.Models.State> GetAllState()
        {
            throw new NotImplementedException();
        }
    }
}
