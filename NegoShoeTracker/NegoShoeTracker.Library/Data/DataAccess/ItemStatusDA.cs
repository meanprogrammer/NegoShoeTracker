using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class ItemStatusDA : DbContextBase
    {
        private NegoshoeDataContext dataContext = null;

        public ItemStatusDA() 
        {
            dataContext = new NegoshoeDataContext();
        }

        public List<ItemStatusDTO> GetAllItemStatus()
        {
            List<ItemStatusDTO> statuses = new List<ItemStatusDTO>();

            var data = dataContext.ItemStatus.ToList();

            foreach (ItemStatus item in data)
            {
                statuses.Add(DTOConverter.ConvertItemStatus(item));
            }

            /*
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
            */




            return statuses;
        }
    }
}
