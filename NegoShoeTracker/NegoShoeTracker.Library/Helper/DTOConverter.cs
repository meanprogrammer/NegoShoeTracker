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
                Description = string.IsNullOrEmpty(item.Description) ? item.Description : string.Empty,
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
    }
}
