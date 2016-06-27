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

        public List<Merchant> GetAllMerchant()
        {
            List<Merchant> list = new List<Merchant>();

            using (DbCommand cmd = db.GetSqlStringCommand("SELECT [MerchantID],[Name],[URL],[Description] FROM [Merchant]"))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        Merchant m = new Merchant();

                        m.MerchantID = reader.GetInt32(0);
                        m.Name = reader.GetString(1);
                        m.URL = reader.GetString(2);
                        m.Description = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);

                        list.Add(m);
                    }
                }
            }

            return list;
        }

        public Merchant GetOne(int id)
        {
            Merchant m = null;

            using (DbCommand cmd = db.GetSqlStringCommand(string.Format("SELECT [MerchantID],[Name],[URL],[Description] FROM [Merchant] WHERE [MerchantID]={0}", id)))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        m = new Merchant();
                        m.MerchantID = reader.GetInt32(0);
                        m.Name = reader.GetString(1);
                        m.URL = reader.GetString(2);
                        m.Description = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    }
                }
            }

            return m;
        }

        public bool DeleteMerchant(int id)
        {
            int result = 0;
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format("DELETE FROM [Merchant] WHERE [MerchantID]={0}", id)))
            {
                result = db.ExecuteNonQuery(cmd);
            }
            return result > 0;
        }

        public bool SaveMerchant(Merchant merchant)
        {
            int result = 0;
            string sql = "INSERT INTO [Merchant] " +
                         "([Name],[URL],[Description]) " +
                         "VALUES ('{0}','{1}','{2}')";
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format(sql, merchant.Name, merchant.URL, merchant.Description)))
            {
                result = db.ExecuteNonQuery(cmd);
            }
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
            using (DbCommand cmd = db.GetSqlStringCommand(string.Format(sql, _merchant.Name, _merchant.URL, _merchant.Description, id)))
            {
                result = db.ExecuteNonQuery(cmd);
            }
            return result > 0;
        }

    }
}
