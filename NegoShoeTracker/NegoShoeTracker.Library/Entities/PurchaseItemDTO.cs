using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class PurchaseItemDTO
    {
        public int PurchaseItemID { get; set; }
        public int PurchaseID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double BoughtPrice { get; set; }
        public double TargetPrice { get; set; }
        public double SoldPrice { get; set; }
        public int StatusID { get; set; }
        public string Remarks { get; set; }
    }
}
