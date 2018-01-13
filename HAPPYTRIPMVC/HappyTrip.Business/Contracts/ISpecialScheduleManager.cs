using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Contracts
{
   public interface ISpecialScheduleManager
    {
        void AddSchedule(SpecialSchedule schedule);
        IList<SpecialSchedule> GetSchedule();
        void EditSchedule(SpecialSchedule schedule);
        void DeleteSchedule(int id);

       SpecialSchedule  FindSchedule(int id);
    }
}
