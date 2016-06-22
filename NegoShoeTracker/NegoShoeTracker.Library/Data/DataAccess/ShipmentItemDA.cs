using NegoShoeTracker.Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data.DataAccess
{
    public class ShipmentItemDA : DbContextBase
    {
        public List<ShipmentItem> GetAllShipmentItem(int parentId)
        {
            List<ShipmentItem> list = new List<ShipmentItem>();

            using (DbCommand cmd = db.GetSqlStringCommand(string.Format(DataResource.SQL_GetAllShipmentItem, parentId)))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        ShipmentItem item = new ShipmentItem();

                        item.SID = reader.GetInt32(0);
                        item.ItemName = reader.GetString(1);
                        item.MerchantID = reader.GetInt32(2);
                        item.Quantity = reader.GetInt32(3);
                        item.BoughtPrice = reader.GetDouble(4);
                        item.TargetPrice = reader.GetDouble(5);
                        item.SoldPrice = reader.GetDouble(6);
                        item.StatusID = reader.GetInt32(7);
                        item.CurrentExchangeRate = reader.GetDouble(8);
                        item.Notes = reader.GetString(9);

                        list.Add(item);
                    }
                }
            }

            return list;
        }

        public ShipmentItem GetOne(int id)
        {
            ShipmentItem shipment = null;

            using (DbCommand cmd = db.GetSqlStringCommand(string.Format(DataResource.SQL_GetOneShipmentItem, id)))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        shipment = new ShipmentItem();
                        shipment.SID = reader.GetInt32(0);
                        shipment.ItemName = reader.GetString(1);
                        shipment.MerchantID = reader.GetInt32(2);
                        shipment.Quantity = reader.GetInt32(3);
                        shipment.BoughtPrice = reader.GetDouble(4);
                        shipment.TargetPrice = reader.GetDouble(5);
                        shipment.SoldPrice = reader.GetDouble(6);
                        shipment.StatusID = reader.GetInt32(7);
                        shipment.CurrentExchangeRate = reader.GetDouble(8);
                        shipment.Notes = reader.GetString(9);
                    }
                }
            }

            return shipment;
        }

        public bool SaveShipmentItem(ShipmentItem _item)
        {
            var result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(
                string.Format(DataResource.SQL_SaveShipmentItem, _item.SID, _item.ItemName, _item.MerchantID, _item.Quantity, _item.BoughtPrice, _item.TargetPrice,
                _item.SoldPrice, _item.StatusID, _item.CurrentExchangeRate, _item.Notes)))
            {
                result = db.ExecuteNonQuery(cmd);
            }

            return result > 0;
        }

        public bool UpdateShipmentItem(ShipmentItem _item, int id)
        {
            var result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(
                string.Format(DataResource.SQL_UpdateShipmentItem, _item.ItemName, _item.MerchantID, _item.Quantity, _item.BoughtPrice, _item.TargetPrice,
                _item.SoldPrice, _item.StatusID, _item.CurrentExchangeRate, _item.Notes, id)))
            {
                result = db.ExecuteNonQuery(cmd);
            }

            return result > 0;
        }

        public bool DeleteShipmentItem(int recordId)
        {
            var result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(
                string.Format(DataResource.SQL_DeleteShipmentItem, recordId)))
            {
                result = db.ExecuteNonQuery(cmd);
            }

            return result > 0;
        }


    }
}
