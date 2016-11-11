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

                        list.Add(item);
                    }
                }
            }

            return list;
        }
    }
}
