﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoShoeTracker.Library.Data
{
    public class MerchantDA
    {
        NegoShoeDbDataContext context = null;
        public MerchantDA()
        {
            context = new NegoShoeDbDataContext();
        }

        public List<Merchant> GetAllMerchant()
        {
            return context.Merchants.ToList();
        }

        public Merchant GetOne(int id)
        {
            return context.Merchants.Where(c => c.MerchantID == id).FirstOrDefault();
        }

        public bool SaveMerchant(Merchant merchant)
        {
            this.context.Merchants.InsertOnSubmit(merchant);
            var result = this.context.GetChangeSet().Inserts.Count;
            this.context.SubmitChanges();
            return result > 0;
        }
    }
}
