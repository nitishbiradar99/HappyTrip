using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HappyTrip.Business.Contracts
{
    public interface IAirlineManager
    {
        void AddAirline(Airline airline, HttpPostedFileBase file);
        IList<Airline> GetAirline();
        void EditAirline(Airline airline, HttpPostedFileBase file);
        void EditAirline(Airline airline);
        void DeleteAirline(int id);

        Airline FindAirline(int id);
    }
}
