using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class ReserverDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int QuantityReserved { get; set; }
        public int ItemID { get; set; }
    }
}
