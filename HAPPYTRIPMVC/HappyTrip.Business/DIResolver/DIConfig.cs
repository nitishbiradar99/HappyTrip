using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using HappyTrip.Business;
using Ninject.Parameters;
using HappyTrip.Data.Repository;
using HappyTrip.Data.EFRepository;
using HappyTrip.Business.Implementations;
using HappyTrip.Business.Contracts;


namespace HappyTrip.UI.MVC.App_Start
{    
    public class NInjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        IKernel Kernal = null;

        public NInjectDependencyResolver(IKernel kernal)
        {
            this.Kernal = kernal;
            Kernal.Bind<IUnitOfWork>().To<EFUnitOfWork>();
            BindDependencies();
        }

        public object GetService(Type serviceType)
        {
            return Kernal.TryGet(serviceType, new IParameter[0]);
            //throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernal.GetAll(serviceType, new IParameter[0]);
            //throw new NotImplementedException();
        }

        public void BindDependencies()
        {
            Kernal.Bind<IRouteManager>().To<RouteManager>();
            Kernal.Bind<IStateManager>().To<StateManager>();
            Kernal.Bind<ICityManager>().To<CityManager>();
            Kernal.Bind<ITravelClassManager>().To<TravelClassManager>();
            Kernal.Bind<IAirlineManager>().To<AirlineManager>();
            Kernal.Bind<IFlightManager>().To<FlightManager>();
            Kernal.Bind<IFlightClassManager>().To<FlightClassManager>();
            //Kernal.Bind<IScheduleManager>().To<ScheduleManager>();
            Kernal.Bind<IBookingManager>().To<BookingManager>();
            Kernal.Bind<IPaymentManager>().To<PaymentManager>();
            Kernal.Bind<ITicketManager>().To<TicketManager>();
            Kernal.Bind<IHotelBookingManager>().To<HotelBookingManager>();
            Kernal.Bind<IHotelManager>().To<HotelManager>();
            Kernal.Bind<IUserAcountManager>().To<UserAcountManager>();
            Kernal.Bind<ISpecialScheduleManager>().To<SpecialScheduleManager>();
            Kernal.Bind<IScheduleManager>().To<ScheduleManager>();
            Kernal.Bind<IFlightCostManager>().To<FlightCostManager>();
        }
    }

}