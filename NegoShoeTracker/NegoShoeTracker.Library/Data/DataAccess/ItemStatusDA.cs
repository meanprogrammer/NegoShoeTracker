using NegoShoeTracker.Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data
{
    public class ItemStatusDA : DbContextBase
    {
        public List<ItemStatus> GetAllItemStatus()
        {
            List<ItemStatus> statuses = new List<ItemStatus>();
            using (DbCommand cmd = db.GetSqlStringCommand("SELECT RecordID,Status FROM ItemStatus"))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        ItemStatus s = new ItemStatus();
                        s.RecordID = reader.GetInt32(0);
                        s.Status = reader.GetString(1);
                        statuses.Add(s);
                    }
                }
            }

            return statuses;
        }
    }
}
