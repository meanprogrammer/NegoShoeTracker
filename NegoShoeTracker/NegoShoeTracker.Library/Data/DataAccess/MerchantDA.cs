using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library
{
    public class MerchantDA : DbContextBase
    {
        public MerchantDA() : base()
        {
            
        }

        public List<MerchantDTO> GetAllMerchant()
        {
            List<MerchantDTO> list = new List<MerchantDTO>();
            var data = dataContext.Merchants;

            foreach (Merchant item in data)
            {
                list.Add(DTOConverter.ConvertMerchant(item));
            }
            return list;
        }

        public MerchantDTO GetOne(int id)
        {
            MerchantDTO m = null;

            var result = dataContext.Merchants.Where(x => x.MerchantID == id).FirstOrDefault();

            if (result != null)
            {
                m = DTOConverter.ConvertMerchant(result);
            }
            return m;
        }

        public bool DeleteMerchant(int id)
        {
            int result = 0;
            result = dataContext.ExecuteCommand(string.Format("DELETE FROM [Merchant] WHERE [MerchantID]={0}", id));
            return result > 0;
        }

        public bool SaveMerchant(MerchantDTO merchant)
        {
            int result = 0;
            string sql = "INSERT INTO [Merchant] " +
                         "([Name],[URL],[Description]) " +
                         "VALUES ('{0}','{1}','{2}')";
            result = dataContext.ExecuteCommand(string.Format(sql, merchant.Name, merchant.URL, merchant.Description));
            return result > 0;
        }

        public bool UpdateMerchant(Merchant _merchant, int id)
        {
            int result = 0;
            string sql = "UPDATE [Merchant] " +
                        "SET [Name] = '{0}' " +
                        ",[URL] = '{1}' " +
                        ",[Description] = '{2}' " +
                        "WHERE [MerchantID] = {3} ";
            result = dataContext.ExecuteCommand(string.Format(sql, _merchant.Name, _merchant.URL, _merchant.Description, id));
            return result > 0;
        }

    }
}
