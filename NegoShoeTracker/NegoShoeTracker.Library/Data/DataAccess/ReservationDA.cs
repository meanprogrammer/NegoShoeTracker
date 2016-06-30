﻿using System;
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
        public List<ReservationItem> GetAllReservation()
        {
            List<ReservationItem> items = new List<ReservationItem>();
            using (DbCommand cmd = db.GetSqlStringCommand("SELECT [ID],[ItemName],[QuantityOrdered],[RemainingUnreserved] FROM ReservationItem"))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        ReservationItem item = new ReservationItem();
                        item.ID = reader.GetInt32(0);
                        item.ItemName = reader.GetString(1);
                        item.QuantityOrdered = reader.GetInt32(2);
                        item.RemainingUnreserved = reader.GetInt32(3);
                        item.Reservers = GetReservers(item.ID);

                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public ReservationItem GetOneReservation(int id)
        {
            ReservationItem item = null;
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format("SELECT [ID],[ItemName],[QuantityOrdered],[RemainingUnreserved] FROM ReservationItem WHERE ID = {0}", id)))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        item = new ReservationItem();
                        item.ID = reader.GetInt32(0);
                        item.ItemName = reader.GetString(1);
                        item.QuantityOrdered = reader.GetInt32(2);
                        item.RemainingUnreserved = reader.GetInt32(3);
                        item.Reservers = GetReservers(item.ID);

                        break;
                    }
                }
            }
            return item;
        }

        private List<Reserver> GetReservers(int itemId)
        {
            List<Reserver> items = new List<Reserver>();
            using (DbCommand cmd = db.GetSqlStringCommand("SELECT [ID],[Name],[QuantityReserved],[ItemID] FROM Reserver"))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Reserver item = new Reserver();
                        item.ID = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.QuantityReserved = reader.GetInt32(2);
                        item.ItemID = reader.GetInt32(3);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public bool AddReservationItem(ReservationItem item)
        {
            int result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format(DataResource.SQL_AddReservationItem, item.ItemName, item.QuantityOrdered, item.RemainingUnreserved)))
            {
                result = db.ExecuteNonQuery(cmd);
            }
            return result > 0;
        }

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
        }
    }
}