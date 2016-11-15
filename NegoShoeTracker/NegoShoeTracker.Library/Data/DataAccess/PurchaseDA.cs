using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public bool Save(PurchaseDTO dto)
        {
            //int result = dataContext.ExecuteCommand(string.Format(DataResource.SQL_SavePurchase, dto.MerchantID, dto.TotalInUSD, dto.TotalInPeso, dto.ExchangeRate, null , dto.Remarks));
            Purchase p = PurchaseDTOConverter.ConvertPurchaseDTO(dto);
            dataContext.Purchases.InsertOnSubmit(p);
            int result = dataContext.GetChangeSet().Inserts.Count;
            dataContext.SubmitChanges();
            return result > 0;
        }

        public bool Update(int id,PurchaseDTO dto)
        {
            int result = dataContext.ExecuteCommand(string.Format(DataResource.SQL_UpdatePurchase, dto.MerchantID, dto.TotalInUSD, dto.TotalInPeso, dto.ExchangeRate, dto.PurchaseDate, dto.Remarks, id));
            return result > 0;
        }
    }
}
