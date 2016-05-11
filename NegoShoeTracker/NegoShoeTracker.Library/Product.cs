using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class Product
    {
        public int RecordId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int MerchantId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double SellingPrice { get; set; }
        public double SoldPrice { get; set; }
        public int Status { get; set; }
        public DateTime DateBought { get; set; }
        public string Remarks { get; set; }
    }
}
