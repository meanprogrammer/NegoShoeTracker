using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class PurchaseDTO
    {
        public int PurchaseID { get; set; }
        public int MerchantID { get; set; }
        public double? TotalInUSD { get; set; }
        public double? TotalInPeso { get; set; }
        public double? ExchangeRate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Remarks { get; set; }

        public List<PurchaseItemDTO> Items { get; set; }

    }
}
