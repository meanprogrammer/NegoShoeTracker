using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class ReservationItemDTO
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public int QuantityOrdered { get; set; }
        public int RemainingUnreserved { get; set; }
        public List<Reserver> Reservers { get; set; }
    }
}
