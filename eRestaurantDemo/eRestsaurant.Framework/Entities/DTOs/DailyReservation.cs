using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eRestaurant.Framework.Entities.POCOs;

namespace eRestaurant.Framework.Entity.DTOs
{
    public class DailyReservation
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public IEnumerable<Booking> Reservations { get; set; }
    }
}
