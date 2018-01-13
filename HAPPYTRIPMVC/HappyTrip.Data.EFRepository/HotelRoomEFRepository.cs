using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Data.Repository;
using HappyTrip.Models;

namespace HappyTrip.Data.EFRepository
{
    internal class HotelRoomEFRepository : GenericEFRepository<HotelRoom>, IHotelRoomRepository
    {
    }
}
