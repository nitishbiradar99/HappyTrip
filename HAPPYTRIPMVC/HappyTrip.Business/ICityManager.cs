using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
    public interface ICityManager  
    {
        void AddCity(City city);
        IList<City> GetCity();
        void EditCity(City city);
        void DeleteCity(int id);

        City FindCity(int id);

        List<State> GetAllState();
    }
}
