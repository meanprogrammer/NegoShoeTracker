using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class ReservationDA : DbContextBase
    {
        public List<ReservationItemDTO> GetAllReservation()
        {
            List<ReservationItemDTO> items = new List<ReservationItemDTO>();
            var data = dataContext.ReservationItems;
            foreach (ReservationItem item in data)
            {
                items.Add(DTOConverter.ConvertReservationItem(item));
            }
            return items;
        }

        public ReservationItemDTO GetOneReservation(int id)
        {
            ReservationItemDTO item = null;

            var data = dataContext.ReservationItems.Where(c => c.ID == id);

            foreach (ReservationItem d in data)
            {
                item = DTOConverter.ConvertReservationItem(d);
                var rData = dataContext.Reservers.Where(x => x.ItemID == item.ID);
                List<ReserverDTO> reservers = new List<ReserverDTO>();
                foreach (Reserver r in rData)
                {
                    reservers.Add(DTOConverter.ConvertReserver(r));
                }
                item.Reservers = reservers;
                break;
            }
            return item;
        }


        public bool AddReservationItem(ReservationItemDTO item)
        {
            int result = 0;
            result = dataContext.ExecuteCommand(string.Format(DataResource.SQL_AddReservationItem, item.ItemName, item.QuantityOrdered, item.RemainingUnreserved));
            return result > 0;
        }
        /*
        public bool AddReserver(Reserver reserver, int itemID)
        {
            int result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format(DataResource.SQL_AddReserver, reserver.Name, reserver.QuantityReserved, itemID)))
            {
                result = db.ExecuteNonQuery(cmd);
                if (result > 0)
                {
                    ReservationItem ri = GetOneReservation(itemID);
                    if (ri != null)
                    {
                        //TODO
                    }
                }
            }
            return result > 0;
        }

        public bool UpdateReservationCount(int newCount, int itemID)
        {
            int result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format(DataResource.SQL_UpdateReservationCount, newCount, itemID)))
            {
                result = db.ExecuteNonQuery(cmd);
            }
            return result > 0;
        }*/
    }
}
