using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class Shipment
    {
        public int RecordID { get; set; }
        public double PriceUSD { get; set; }
        public double PricePHP { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }    
    }
}
