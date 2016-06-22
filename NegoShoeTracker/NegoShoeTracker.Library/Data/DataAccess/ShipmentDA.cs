using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data.DataAccess
{
    public class ShipmentDA : DbContextBase
    {
        public List<Shipment> GetAllShipments()
        {
            List<Shipment> list = new List<Shipment>();

            using (DbCommand cmd = db.GetSqlStringCommand("SELECT [ID],[ShipmentNumber],[ShipmentName],[ArrivalDate],[SalexTax],[ShippingCost],[ShoppingCharge],[Profit],[CurrentExchangeRate],[Notes] FROM [Shipment]"))
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
                        s.Notes = reader.GetString(9);

                        s.ShipmentItems = null;

                        list.Add(s);
                    }
                }
            }

            return list;
        }

        public Shipment GetOne(int id)
        {
            Shipment s = null;

            using (DbCommand cmd = db.GetSqlStringCommand(string.Format("SELECT [ID],[ShipmentNumber],[ShipmentName],[ArrivalDate],[SalexTax],[ShippingCost],[ShoppingCharge],[Profit],[CurrentExchangeRate],[Notes] FROM [Shipment] WHERE [ID]={0}", id)))
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
                        s.Notes = reader.GetString(9);

                        s.ShipmentItems = null;
                    }
                }
            }

            return s;
        }

        public bool SaveShipment(Shipment shipment)
        {
            var result = 0;
            string sql = "INSERT INTO [Shipment] " +
                        "([ShipmentNumber],[ShipmentName],[ArrivalDate],[SalexTax],[ShippingCost],[ShoppingCharge],[Profit],[CurrentExchangeRate],[Notes]) " +
                        "VALUES ({0},'{1}','{2}',{3},{4},{5},{6},{7},'{8}')";

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
                          "WHERE [ID] = {9} ";

            using (DbCommand cmd = db.GetSqlStringCommand(
                string.Format(sql, _shipment.ShipmentNumber, _shipment.ShipmentName, _shipment.ArrivalDate, _shipment.SalexTax, _shipment.ShippingCost, _shipment.ShoppingCharge,
                _shipment.Profit, _shipment.CurrentExchangeRate, _shipment.Notes, id)))
            {
                result = db.ExecuteNonQuery(cmd);
            }
            return result > 0;
        }
    }
}
