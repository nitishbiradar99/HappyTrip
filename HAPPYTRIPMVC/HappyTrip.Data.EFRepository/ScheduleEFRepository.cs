using HappyTrip.Data.Repository;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Data.EFRepository
{
    internal class ScheduleEFRepository : GenericEFRepository<Schedule> , IScheduleRepositry
    {
        //public void AddSchedule(Schedule s)
        //{
        //    //HappyTripDBEntity db = new HappyTripDBEntity();
        //    HappyTripDBCon db = new HappyTripDBCon();
        //    if (db.Entry(s).State == EntityState.Detached)
        //    {
        //        DbSet.Attach(s);
        //    }
        //    db.Schedules.Add(s);
        //    db.SaveChanges();
        //}

        //public void AddFlightCost(FlightCost F)
        //{
        //    //HappyTripDBEntity db = new HappyTripDBEntity();
        //    HappyTripDBCon db = new HappyTripDBCon();
        //    db.FlightCost.Add(F);
        //    db.SaveChanges();
        //}
    }
}
