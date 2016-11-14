using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class ShipmentItemDTO
    {
        public int RecordID { get; set; }
        public int SID { get; set; }
        public string ItemName { get; set; }
        public int MerchantID { get; set; }
        public int Quantity { get; set; }
        public double BoughtPrice { get; set; }
        public double TargetPrice { get; set; }
        public double SoldPrice { get;set; }
        public int StatusID { get;set; }
        public double? CurrentExchangeRate { get;set;}
        public string Notes { get; set; }
        public string MerchantName { get; set; }
        public string Status { get; set; }
    }
}
