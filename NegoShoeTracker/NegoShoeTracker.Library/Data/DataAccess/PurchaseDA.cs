using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class PurchaseDA : DbContextBase
    {
        public PurchaseDA()
            : base()
        {
            
        }

        public List<PurchaseDTO> GetAllPurchases()
        {
            List<PurchaseDTO> list = new List<PurchaseDTO>();

            foreach (Purchase p in dataContext.Purchases)
            {
                list.Add(PurchaseDTOConverter.ConvertPurchase(p));
            }
            return list;
        }
    }
}
