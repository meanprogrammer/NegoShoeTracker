using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class DTOConverter
    {
        public static ItemStatusDTO ConvertItemStatus(ItemStatus item)
        {
            return new ItemStatusDTO() { 
                RecordID = item.RecordID,
                Status = item.Status
            };
        }

        public static MerchantDTO ConvertMerchant(Merchant item)
        {
            

            return new MerchantDTO() { 
                MerchantID = item.MerchantID,
                Description = !string.IsNullOrEmpty(item.Description) ? item.Description : string.Empty,
                Name = item.Name,
                URL = item.URL
            };
        }

        public static Merchant ConvertMerchantDTO(MerchantDTO merchant)
        {
            return new Merchant() { 
                Name = merchant.Name,
                URL = merchant.URL,
                Description = merchant.Description
            };
        }

        public static ReservationItemDTO ConvertReservationItem(ReservationItem item)
        {
            return new ReservationItemDTO() { 
                ID = item.ID,
                ItemName = item.ItemName,
                QuantityOrdered = item.QuantityOrdered,
                RemainingUnreserved = item.RemainingUnreserved
            };
        }

        public static ReservationItem ConvertReservationItem(ReservationItemDTO item)
        {
            return new ReservationItem()
            {
                ID = item.ID,
                ItemName = item.ItemName,
                QuantityOrdered = item.QuantityOrdered,
                RemainingUnreserved = item.RemainingUnreserved
            };
        }

        public static ReserverDTO ConvertReserver(Reserver item)
        {
            return new ReserverDTO() { 
                ID = item.ID,
                ItemID = item.ItemID,
                Name = item.Name,
                QuantityReserved = item.QuantityReserved
            };
        }

        public static PurchaseItemDTO ConvertPurchaseItem(PurchaseItem item)
        {
            return new PurchaseItemDTO() { 
                BoughtPrice = item.BoughtPrice,
                ItemName = item.ItemName,
                PurchaseID = item.PurchaseID,
                PurchaseItemID = item.PurchaseItemID,
                Quantity = item.Quantity,
                Remarks = item.Remarks,
                SoldPrice = item.SoldPrice,
                StatusID = item.StatusID,
                TargetPrice = item.TargetPrice
            };
        }
    }

    public class PurchaseDTOConverter
    {
        public static PurchaseDTO ConvertPurchase(Purchase p)
        {
            return new PurchaseDTO() { 
                ExchangeRate = p.ExchangeRate,
                MerchantID = p.MerchantID,
                PurchaseDate = p.PurchaseDate,
                PurchaseID = p.PurchaseID,
                Remarks = p.Remarks,
                TotalInPeso = p.TotalInPeso,
                TotalInUSD = p.TotalInUSD
            };
        }

        public static Purchase ConvertPurchaseDTO(PurchaseDTO p)
        {
            return new Purchase()
            {
                ExchangeRate = p.ExchangeRate,
                MerchantID = p.MerchantID,
                PurchaseDate = p.PurchaseDate,
                PurchaseID = p.PurchaseID,
                Remarks = p.Remarks,
                TotalInPeso = p.TotalInPeso,
                TotalInUSD = p.TotalInUSD
            };
        }
    }
}
