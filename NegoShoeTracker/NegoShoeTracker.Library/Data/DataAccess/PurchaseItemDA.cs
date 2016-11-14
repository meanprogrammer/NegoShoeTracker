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
        public List<PurchaseItem> GetAllPurchaseItem(int parentId)
        {
            List<PurchaseItem> list = new List<PurchaseItem>();

            using (DbCommand cmd = db.GetSqlStringCommand(string.Format(DataResource.SQL_GetAllPurchaseItem, parentId)))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        PurchaseItem item = new PurchaseItem();
                        item.PurchaseItemID = reader.GetInt32(reader.GetOrdinal("PurchaseItemID"));
                        item.PurchaseID = reader.GetInt32(reader.GetOrdinal("PurchaseID"));
                        item.ItemName = reader.GetString(reader.GetOrdinal("ItemName"));
                        item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                        item.BoughtPrice = reader.GetFloat(reader.GetOrdinal("BoughtPrice"));
                        item.TargetPrice = reader.GetFloat(reader.GetOrdinal("TargetPrice"));
                        item.SoldPrice = reader.GetFloat(reader.GetOrdinal("SoldPrice"));
                        item.StatusID = reader.GetInt32(reader.GetOrdinal("StatusID"));
                        item.Remarks = reader.GetString(reader.GetOrdinal("Remarks"));
                        list.Add(item);
                    }
                }
            }

            return list;
        }

        public bool SavePurchaseItem(PurchaseItem _item)
        {
            var result = 0;
            try
            {
                for (int i = 0; i < _item.Quantity; i++)
                {
                    using (DbCommand cmd = db.GetSqlStringCommand(
                    string.Format(DataResource.SQL_SavePurchaseItem, _item.PurchaseID, _item.ItemName, _item.Quantity, 1, _item.BoughtPrice, _item.TargetPrice,
                    _item.SoldPrice, _item.StatusID, _item.StatusID, _item.Remarks)))
                    {
                        result = db.ExecuteNonQuery(cmd);

                        //recalc
                        if (result > 0)
                        {
                            //no codes yet
                        }
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