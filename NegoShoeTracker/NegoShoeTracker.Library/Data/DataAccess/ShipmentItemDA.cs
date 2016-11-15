using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class ShipmentItemDA : DbContextBase
    {/*
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
                        item.RecordID = reader.GetInt32(0);
                        item.SID = reader.GetInt32(1);
                        item.ItemName = reader.GetString(2);
                        item.MerchantID = reader.GetInt32(3);
                        item.Quantity = reader.GetInt32(4);
                        item.BoughtPrice = reader.GetDouble(5);
                        item.TargetPrice = reader.GetDouble(6);
                        item.SoldPrice = reader.GetDouble(7);
                        item.StatusID = reader.GetInt32(8);
                        item.CurrentExchangeRate = reader.GetDouble(9);
                        item.Notes = reader.GetString(10);
                        item.MerchantName = reader.GetString(11);
                        item.Status = reader.GetString(12);

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
                        shipment.RecordID = reader.GetInt32(0);
                        shipment.SID = reader.GetInt32(1);
                        shipment.ItemName = reader.GetString(2);
                        shipment.MerchantID = reader.GetInt32(3);
                        shipment.Quantity = reader.GetInt32(4);
                        shipment.BoughtPrice = reader.GetDouble(5);
                        shipment.TargetPrice = reader.GetDouble(6);
                        shipment.SoldPrice = reader.GetDouble(7);
                        shipment.StatusID = reader.GetInt32(8);
                        shipment.CurrentExchangeRate = reader.GetDouble(9);
                        shipment.Notes = reader.GetString(10);
                        shipment.MerchantName = reader.GetString(11);
                        shipment.Status = reader.GetString(12);
                    }
                }
            }

            return shipment;
        }

        public bool SaveShipmentItem(ShipmentItem _item)
        {
            var result = 0;
            try
            {
                for (int i = 0; i < _item.Quantity; i++)
                {
                    using (DbCommand cmd = db.GetSqlStringCommand(
                    string.Format(DataResource.SQL_SaveShipmentItem, _item.SID, _item.ItemName, _item.MerchantID, 1, _item.BoughtPrice, _item.TargetPrice,
                    _item.SoldPrice, _item.StatusID, _item.CurrentExchangeRate, _item.Notes)))
                    {
                        result = db.ExecuteNonQuery(cmd);

                        //recalc
                        if (result > 0)
                        {
                            ShipmentDA parentDA = new ShipmentDA();
                            Shipment parent = parentDA.GetOne(_item.SID);
                            if (parent != null)
                            {
                                ReCalculate(parent);
                                parentDA.UpdateShipment(parent, parent.ID);
                            }
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

        private void ReCalculate(Shipment shipment)
        {
            shipment.TotalProjectedSales = shipment.ShipmentItems.Sum(c => c.TargetPrice);
            shipment.TotalSales = shipment.ShipmentItems.Where(r => r.StatusID == 2).Sum(x => x.SoldPrice);
            shipment.TotalCost = shipment.ShipmentItems.Sum(i => i.BoughtPrice) + shipment.ShippingCost + shipment.ShoppingCharge + shipment.SalexTax;
            shipment.Profit = shipment.TotalSales - shipment.TotalCost;
        }

        public bool UpdateShipmentItem(ShipmentItem _item, int id)
        {
            var updateResult = false;
            var result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(
                string.Format(DataResource.SQL_UpdateShipmentItem, _item.ItemName, _item.MerchantID, _item.Quantity, _item.BoughtPrice, _item.TargetPrice,
                _item.SoldPrice, _item.StatusID, _item.CurrentExchangeRate, _item.Notes, id)))
            {
                ShipmentItem item = GetOne(id);
                result = db.ExecuteNonQuery(cmd);

                if (result > 0)
                {
                    if (item != null)
                    {
                        ShipmentDA parentDA = new ShipmentDA();
                        Shipment sh = parentDA.GetOne(item.SID);
                        ReCalculate(sh);
                        updateResult = parentDA.UpdateShipment(sh, item.SID);
                    }
                }
            }

            return result > 0 && updateResult;
        }

        public bool DeleteShipmentItem(int recordId)
        {
            var result = 0;
            var updateResult = false;
            using (DbCommand cmd = db.GetSqlStringCommand(
                string.Format(DataResource.SQL_DeleteShipmentItem, recordId)))
            {

                ShipmentItem item = GetOne(recordId);
                result = db.ExecuteNonQuery(cmd);

                if (result > 0)
                {
                    if (item != null)
                    {
                        ShipmentDA parentDA = new ShipmentDA();
                        Shipment sh = parentDA.GetOne(item.SID);
                        ReCalculate(sh);
                        updateResult = parentDA.UpdateShipment(sh, item.SID);
                    }
                }
            }

            return result > 0 && updateResult;
        }

*/
    }
}
