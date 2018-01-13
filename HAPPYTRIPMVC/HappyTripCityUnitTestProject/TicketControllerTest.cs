using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyTrip.Models;
using System.Collections.Generic;
using HappyTrip.UI.MVC.Controllers;
using System.Web.Mvc;

namespace HappyTripCityUnitTestProject
{
    [TestClass]
    public class TicketControllerTest
    {
        Ticket ticket1 = null;
        List<Ticket> ticketList = null;
        DummyTicketManager dummyTicketMgr = null;
        TicketController controller = null;
        public TicketControllerTest()
        {
            ticket1 = new Ticket
            {
                TicketID = 1,
                TicketNo = "123",
                FlightNo = "K123",
                BookingDate = new DateTime(2014, 11, 04),
                JourneyDate = new DateTime(2014, 11, 05),
                Source = "Delhi",
                Destination = "Bangalore",
                Fare = "6500"

            };
            ticketList = new List<Ticket> { ticket1 };
            dummyTicketMgr = new DummyTicketManager(ticketList);
            controller = new TicketController(dummyTicketMgr);


        }



        [TestMethod]
        public void Index()
        {

            ViewResult result = controller.Index() as ViewResult;
            var model = (List<Ticket>)result.ViewData.Model;
            CollectionAssert.Contains(model, ticket1);
        }
    }
}
