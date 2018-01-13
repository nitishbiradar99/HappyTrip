using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyTrip.Models;
using System.Collections.Generic;
using HappyTrip.UI.MVC.Controllers;
using System.Web.Mvc;

namespace HappyTripCityUnitTestProject
{
    [TestClass]
    public class CityControllerTest
    {
        City city1 = null;
            City city2 = null;
            City city3 = null;
            City city4 = null;

            List<City> cities = null;
            DummyCityManager dummyMgr = null;
            CityController controller = null;

         public CityControllerTest()
            {

                city1=new City{CityId=1,CityName="Bangalore"};
             city2=new City{CityId=2,CityName="Mumbai"};
             city3=new City{CityId=3,CityName="Pune"};
             city4=new City{CityId=4,CityName="Lucknow"};
              cities=new List<City>
              {

city1,
city2,city3,city4

              };
             dummyMgr=new DummyCityManager(cities);
             controller=new CityController(dummyMgr);

            }

    
        [TestMethod]
        public void Index()
        {
            //Add System.Web.Mvc and System.Web namespace or dll
            ViewResult result=controller.Index(2) as ViewResult;
            var model=(List<City>)result.ViewData.Model;
            CollectionAssert.Contains(model,city1);
             CollectionAssert.Contains(model,city2);
             CollectionAssert.Contains(model,city3);
             CollectionAssert.Contains(model,city4);

        }
        [TestMethod]
        public void Create()
        {
            City newCity = new City { CityId = 30, CityName = "Bangalore", StateId = 2 };
            controller.Create(newCity);
            List<City> cities = dummyMgr.GetCity() as List<City>;
            CollectionAssert.Contains(cities, newCity);

        }
        [TestMethod]
        public void Details()
        {

        }
           
    
        
    }
}
