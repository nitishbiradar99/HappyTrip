using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using HappyTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Implementations
{
   internal class SpecialScheduleManager:ISpecialScheduleManager
    {
       private ISpecialScheduleRepo repo = null;

       public SpecialScheduleManager(IUnitOfWork uof)
       {
           repo = uof.GetSpecialScheduleRepositry();
       }
        public void AddSchedule(Models.SpecialSchedule schedule)
        {
            repo.Create(schedule);
        }

        public IList<Models.SpecialSchedule> GetSchedule()
        {
            return repo.All().ToList<SpecialSchedule>();
        }


        public void DeleteSchedule(int id)
        {
            repo.Delete(id);
        }

        public Models.SpecialSchedule FindSchedule(int id)
        {
           return repo.Find(id);
        }


        public void EditSchedule(SpecialSchedule schedule)
        {
            
            
            
            
            repo.Update(schedule);
        }
    }
}
