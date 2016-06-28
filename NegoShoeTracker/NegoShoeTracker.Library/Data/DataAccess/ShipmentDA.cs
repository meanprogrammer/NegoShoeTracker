using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class ShipmentDA : DbContextBase
    {
        ShipmentItemDA si = new ShipmentItemDA();

        public List<Shipment> GetAllShipments()
        {
            List<Shipment> list = new List<Shipment>();

            using (DbCommand cmd = db.GetSqlStringCommand("SELECT [ID],[ShipmentNumber],[ShipmentName],[ArrivalDate],[SalexTax],[ShippingCost],[ShoppingCharge],[Profit],[CurrentExchangeRate],[Notes],[TotalCost],[TotalProjectedSales],[TotalSales] FROM [Shipment]"))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Shipment s = new Shipment();

                        s.ID = reader.GetInt32(0);
                        s.ShipmentNumber = reader.GetInt32(1);
                        s.ShipmentName = reader.GetString(2);
                        s.ArrivalDate = reader.GetDateTime(3);
                        s.SalexTax = reader.GetDouble(4);
                        s.ShippingCost = reader.GetDouble(5);
                        s.ShoppingCharge = reader.GetDouble(6);
                        s.Profit = reader.GetDouble(7);
                        s.CurrentExchangeRate = reader.GetDouble(8);
                        s.Notes = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        s.TotalCost = reader.GetDouble(10);
                        s.TotalProjectedSales = reader.GetDouble(11);
                        s.TotalSales = reader.GetDouble(12);
                        s.ShipmentItems = si.GetAllShipmentItem(s.ID); 

                        list.Add(s);
                    }
                }
            }

            return list;
        }

        public Shipment GetOne(int id)
        {
            Shipment s = null;

            using (DbCommand cmd = db.GetSqlStringCommand(string.Format("SELECT [ID],[ShipmentNumber],[ShipmentName],[ArrivalDate],[SalexTax],[ShippingCost],[ShoppingCharge],[Profit],[CurrentExchangeRate],[Notes],[TotalCost],[TotalProjectedSales],[TotalSales] FROM [Shipment] WHERE [ID]={0}", id)))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        s = new Shipment();

                        s.ID = reader.GetInt32(0);
                        s.ShipmentNumber = reader.GetInt32(1);
                        s.ShipmentName = reader.GetString(2);
                        s.ArrivalDate = reader.GetDateTime(3);
                        s.SalexTax = reader.GetDouble(4);
                        s.ShippingCost = reader.GetDouble(5);
                        s.ShoppingCharge = reader.GetDouble(6);
                        s.Profit = reader.GetDouble(7);
                        s.CurrentExchangeRate = reader.GetDouble(8);
                        s.Notes = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        s.TotalCost = reader.GetDouble(10);
                        s.TotalProjectedSales = reader.GetDouble(11);
                        s.TotalSales = reader.GetDouble(12);
                        s.ShipmentItems = si.GetAllShipmentItem(s.ID); 
                    }
                }
            }

            return s;
        }

        public bool SaveShipment(Shipment shipment)
        {
            var result = 0;
            string sql = "INSERT INTO [Shipment] " +
                        "([ShipmentNumber],[ShipmentName],[ArrivalDate],[SalexTax],[ShippingCost],[ShoppingCharge],[Profit],[CurrentExchangeRate],[Notes],[TotalCost],[TotalProjectedSales],[TotalSales]) " +
                        "VALUES ({0},'{1}','{2}',{3},{4},{5},{6},{7},'{8}',0,0,0)";

            using (DbCommand cmd = db.GetSqlStringCommand(
                string.Format(sql, shipment.ShipmentNumber, shipment.ShipmentName, shipment.ArrivalDate, shipment.SalexTax,shipment.ShippingCost,shipment.ShoppingCharge,
                shipment.Profit, shipment.CurrentExchangeRate, shipment.Notes)))
            {
                result = db.ExecuteNonQuery(cmd);
            }

            return result > 0;
        }

        public bool UpdateShipment(Shipment _shipment, int id)
        {
            var result = 0;
            string sql = "UPDATE [Shipment] " +
                        "SET [ShipmentNumber] = {0} " +
                          ",[ShipmentName] = '{1}' " +
                          ",[ArrivalDate] = '{2}' " +
                          ",[SalexTax] = {3} " +
                          ",[ShippingCost] = {4} " +
                          ",[ShoppingCharge] = {5} " +
                          ",[Profit] = {6} " +
                          ",[CurrentExchangeRate] = {7} " +
                          ",[Notes] = '{8}' " +
                          ",[TotalCost] = {9} " +
                          ",[TotalProjectedSales] = {10} " +
                          ",[TotalSales] = {11} " +
                          "WHERE [ID] = {12} ";

            using (DbCommand cmd = db.GetSqlStringCommand(
                string.Format(sql, _shipment.ShipmentNumber, _shipment.ShipmentName, _shipment.ArrivalDate, _shipment.SalexTax, _shipment.ShippingCost, _shipment.ShoppingCharge,
                _shipment.Profit, _shipment.CurrentExchangeRate, _shipment.Notes, _shipment.TotalCost, _shipment.TotalProjectedSales, _shipment.TotalSales, id)))
            {
                result = db.ExecuteNonQuery(cmd);
            }
            return result > 0;
        }
    }
}
