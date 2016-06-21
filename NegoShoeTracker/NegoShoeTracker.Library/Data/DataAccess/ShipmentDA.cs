using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data.DataAccess
{
    public class ShipmentDA : DbContextBase
    {
        public List<Shipment> GetAllShipments()
        {
            return this.context.Shipments.ToList();
        }

        public Shipment GetOne(int id)
        {
            return this.context.Shipments.Where(c => c.ID == id).FirstOrDefault();
        }

        public bool SaveShipment(Shipment shipment)
        {
            var result = 0;
            this.context.Shipments.InsertOnSubmit(shipment);
            result = this.context.GetChangeSet().Inserts.Count;
            this.context.SubmitChanges();
            return result > 0;
        }

        public bool UpdateShipment(Shipment _shipment, int id)
        {
            Shipment shipment = this.context.Shipments.Single(c => c.ID == id);
            if (shipment != null)
            {
                shipment.ArrivalDate = _shipment.ArrivalDate;
                shipment.Notes = _shipment.Notes;
                shipment.Profit = _shipment.Profit;
                shipment.SalexTax = _shipment.SalexTax;
                shipment.ShipmentName = _shipment.ShipmentName;
                shipment.ShipmentNumber = _shipment.ShipmentNumber;
                shipment.ShippingCost = _shipment.ShippingCost;
                shipment.ShoppingCharge = _shipment.ShoppingCharge;
                shipment.CurrentExchangeRate = _shipment.CurrentExchangeRate;
                //this.context.Shipments.u
            }
            var result = this.context.GetChangeSet();
            this.context.SubmitChanges();


            return result.Updates.Count() > 0;
        }
    }
}
