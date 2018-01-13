using HappyTrip.Business;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTripCityUnitTestProject
{
    class DummyTicketManager:ITicketManager
    {
        Ticket tickets = null;
        List<Ticket> ticketList = null;
        public DummyTicketManager(List<Ticket> ticketList)
        {

            //this.tickets = tickets;
            this.ticketList = ticketList;
        }
    
public HappyTrip.Models.Ticket GetTicket(int id)
{
    return tickets;
}

public IList<HappyTrip.Models.Ticket> AllTickets()
{
    return ticketList;
}
}
}
