using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data
{
    public class MerchantDA : DbContextBase
    {
        public MerchantDA() : base()
        {
            
        }

        public List<Merchant> GetAllMerchant()
        {
            return context.Merchants.ToList();
        }

        public Merchant GetOne(int id)
        {
            return context.Merchants.Where(c => c.MerchantID == id).FirstOrDefault();
        }

        public bool DeleteMerchant(int id)
        {
            var result = 0;
            Merchant merchant = this.context.Merchants.Where(c => c.MerchantID == id).FirstOrDefault();
            if(merchant!=null)
            {
                this.context.Merchants.DeleteOnSubmit(merchant);
                result = this.context.GetChangeSet().Deletes.Count;
                this.context.SubmitChanges();
            }
            return result > 0;
        }

        public bool SaveMerchant(Merchant merchant)
        {
            this.context.Merchants.InsertOnSubmit(merchant);
            var result = this.context.GetChangeSet().Inserts.Count;
            this.context.SubmitChanges();
            return result > 0;
        }

        public bool UpdateMerchant(Merchant _merchant, int id)
        {
            Merchant merchant = this.context.Merchants.Where(c => c.MerchantID == id).FirstOrDefault();
            if (merchant != null)
            {
                merchant = _merchant;
            }

            var result = this.context.GetChangeSet().Updates.Count;
            this.context.SubmitChanges();
            return result > 0;
        }

    }
}
