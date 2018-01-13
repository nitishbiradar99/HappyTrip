using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
    public interface ITravelClassManager
    {
        void AddTravelClass(TravelClass travelClass);
        IList<TravelClass> GetTravelClass();
        void EditTravelClass(TravelClass travelClass);
        void DeleteTravelClass(int id);

        TravelClass FindTravelClass(int id);
    }
}
