using HappyTrip.Business.Contracts;
using HappyTrip.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Business.Implementations
{
    internal class AirlineManager : IAirlineManager
    {
        private IAirlineRepo airlineRepo = null;

        public AirlineManager(IUnitOfWork uow)
        {
            airlineRepo = uow.GetAirlineRepository();
        }

        public void AddAirline(Models.Airline airline, System.Web.HttpPostedFileBase file)
        {
            if (file.ContentType == "image/jpeg" || file.ContentType == "image/png")
            {
                string filename = Path.GetFileName(file.FileName);
                string filepath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/images/AirlineLogo"), filename);

                file.SaveAs(filepath);

                airline.Logo = "Content/images/AirlineLogo/" + filename;
                airlineRepo.Create(airline);
            }
        }

        public IList<Models.Airline> GetAirline()
        {
            return airlineRepo.All().ToList<Models.Airline>();
        }

        public void EditAirline(Models.Airline airline, System.Web.HttpPostedFileBase file)
        {
            if (file.ContentLength > 0 && (file.ContentType == "image/jpeg" || file.ContentType == "image/png"))
            {
                string filename = Path.GetFileName(file.FileName);
                string filepath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/images/AirlineLogo"), filename);

                file.SaveAs(filepath);

                airline.Logo = "Content/images/AirlineLogo/" + filename;
                airlineRepo.Update(airline);
            }
        }

        public void DeleteAirline(int id)
        {
            airlineRepo.Delete(id);
        }

        public Models.Airline FindAirline(int id)
        {
            Models.Airline a = airlineRepo.Find(id);
            return a;
        }


        public void EditAirline(Models.Airline airline)
        {
            airlineRepo.Update(airline);
        }
    }
}
