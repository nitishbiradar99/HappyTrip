using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Data.Repository
{
    public interface IScheduleRepo : IRepository<Schedule>
    {
        void AddSchedule(Schedule s);

        void AddFlightCost(FlightCost F);
    }
}
