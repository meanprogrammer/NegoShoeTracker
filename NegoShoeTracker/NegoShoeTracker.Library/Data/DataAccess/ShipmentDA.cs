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
            return this.context.Shipments.Where(c => c.RecordID == id).FirstOrDefault();
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
            Shipment shipment = this.context.Shipments.Where(c => c.RecordID == id).FirstOrDefault();
            if (shipment != null)
            {
                shipment = _shipment;
            }

            var result = this.context.GetChangeSet().Updates.Count;
            this.context.SubmitChanges();
            return result > 0;
        }
    }
}
