using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class Shipment
    {
        public int ID { get; set; }
        public int ShipmentNumber { get; set; }
        public string ShipmentName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double SalexTax { get; set; }
        public double ShippingCost { get; set; }
        public double ShoppingCharge { get; set; }
        public double Profit { get; set; }
        public double CurrentExchangeRate { get; set; }
        public string Notes { get; set; }

        public double TotalCost { get; set; }
        public double TotalProjectedSales { get; set; }
        public double TotalSales { get; set; }
        public double SubTotal { get; set; }
        public List<ShipmentItem> ShipmentItems { get; set; }
    }
}
