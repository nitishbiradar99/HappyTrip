using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business
{
    public interface IRouteManager
    {
        void AddRoute(Route route);
        IList<Route> GetRoute();
        void EditRoute(Route route);
        void DeleteRoute(Route route);

        Route FindRoute(int id);
        List<City> GetAllCities();
    }
}
