using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data.DataAccess
{
    public class ShipmentItemDA : DbContextBase
    {
        public List<ShipmentItem> GetAllShipmentItem(int parentId)
        {
            return this.context.ShipmentItems.Where(c => c.SID == parentId).ToList();
        }

        public ShipmentItem GetOne(int id)
        {
            return context.ShipmentItems.Where(c => c.RecordID == id).FirstOrDefault();
        }

        public bool SaveShipmentItem(ShipmentItem _item)
        {
            this.context.ShipmentItems.InsertOnSubmit(_item);
            var result = this.context.GetChangeSet().Inserts.Count;
            this.context.SubmitChanges();
            return result > 0;
        }

        public bool UpdateShipmentItem(ShipmentItem _item, int id)
        {
            ShipmentItem item = this.context.ShipmentItems.Where(c => c.RecordID == id).FirstOrDefault();
            if (item != null)
            {
                item = _item;
            }

            var result = this.context.GetChangeSet().Updates.Count;
            this.context.SubmitChanges();
            return result > 0;
        }

        public bool DeleteShipmentItem(int recordId)
        {
            var result = 0;
            ShipmentItem shipmentItem = this.context.ShipmentItems.Where(c => c.RecordID == recordId).FirstOrDefault();
            if (shipmentItem != null)
            {
                this.context.ShipmentItems.DeleteOnSubmit(shipmentItem);
                result = this.context.GetChangeSet().Deletes.Count;
                this.context.SubmitChanges();
            }
            return result > 0;
        }


    }
}
