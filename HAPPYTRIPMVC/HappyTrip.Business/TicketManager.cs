using HappyTrip.Data.Repository;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business
{
   public class TicketManager:ITicketManager
    {
       private ITicketRepository repository = null;
       public TicketManager(IUnitOfWork uow)
       {
           repository = uow.GetTicketRepository();
       }
       
        public Models.Ticket GetTicket(int id)
        {
            return repository.Find(id);  
        }


        public IList<Models.Ticket> AllTickets()
        {
           return repository.All().ToList<Ticket>();
        }
    }
}
