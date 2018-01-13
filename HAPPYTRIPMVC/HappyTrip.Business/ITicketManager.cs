using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business
{
    public interface ITicketManager
    {
        Ticket GetTicket(int id);
        IList<Ticket> AllTickets();
    }
}
