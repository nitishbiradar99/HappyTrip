using HappyTrip.Data.Repository;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business
{
    internal class RouteManager : IRouteManager
    {
        private IRouteRepo repoRoute = null;
        private ICityRepo repoCity = null;

        public RouteManager(IUnitOfWork uow)
        {
            repoRoute = uow.GetRouteRepository();
            repoCity = uow.GetCityRepository();
        }

        public void AddRoute(Models.Route route)
        {
            repoRoute.Create(route);
        }

        public IList<Models.Route> GetRoute()
        {
            return repoRoute.All().ToList<Route>();
        }

        public void EditRoute(Models.Route route)
        {
            repoRoute.Update(route);
        }

        public void DeleteRoute(Models.Route route)
        {
            repoRoute.Delete(route);
        }


        public Route FindRoute(int id)
        {
            Route route = repoRoute.Find(id);
            return route;
        }


        public List<City> GetAllCities()
        {
            return repoCity.All().ToList<City>();
        }
    }
}
