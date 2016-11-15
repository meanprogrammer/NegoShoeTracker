using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class PurchaseItemDA : DbContextBase
    {
        public List<PurchaseItemDTO> GetAllPurchaseItem(int parentId)
        {
            List<PurchaseItemDTO> list = new List<PurchaseItemDTO>();
            var data = dataContext.PurchaseItems.Where(c => c.PurchaseID == parentId);
            foreach (PurchaseItem p in data)
            {
                list.Add(DTOConverter.ConvertPurchaseItem(p));
            }
            return list;
        }

        public bool SavePurchaseItem(PurchaseItemDTO _item)
        {
            var result = 0;
            try
            {
                for (int i = 0; i < _item.Quantity; i++)
                {

                    result = dataContext.ExecuteCommand(string.Format(DataResource.SQL_SavePurchaseItem, _item.PurchaseID, _item.ItemName, _item.Quantity, 1, _item.BoughtPrice, _item.TargetPrice,
                    _item.SoldPrice, _item.StatusID, _item.StatusID, _item.Remarks));

                    if (result > 0)
                    {
                        //no codes yet
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
            return result > 0;
        }
    }
}