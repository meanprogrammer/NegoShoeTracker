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

        public PurchaseDTO GetOnePurchase(int id)
        {
            PurchaseDTO result = null;
            Purchase data = dataContext.Purchases.Where(x => x.PurchaseID == id).FirstOrDefault();
            if (data != null)
            {
                result = PurchaseDTOConverter.ConvertPurchase(data);
            }
            return result;
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
            int result = 0;
            //int result = dataContext.ExecuteCommand(string.Format(DataResource.SQL_UpdatePurchase, dto.MerchantID, dto.TotalInUSD, dto.TotalInPeso, dto.ExchangeRate, dto.PurchaseDate, dto.Remarks, id));
            Purchase p = dataContext.Purchases.Where(x=>x.PurchaseID == id).FirstOrDefault();
            if(p != null)
            {
                p.MerchantID = dto.MerchantID;
                p.PurchaseDate = dto.PurchaseDate;
                p.Remarks = dto.Remarks;
                p.TotalInPeso = dto.TotalInPeso;
                p.TotalInUSD = dto.TotalInUSD;
                p.ExchangeRate = dto.ExchangeRate;
            }
            result = dataContext.GetChangeSet().Updates.Count;
            dataContext.SubmitChanges();
            return result > 0;
        }

        public bool Delete(int id)
        {
            int result = 0;
            Purchase p = dataContext.Purchases.Where(x => x.PurchaseID == id).FirstOrDefault();
            if (p != null)
            {
                dataContext.Purchases.DeleteOnSubmit(p);
                result = dataContext.GetChangeSet().Deletes.Count;
                dataContext.SubmitChanges();
            }
            return result > 0;
        }
    }
}
