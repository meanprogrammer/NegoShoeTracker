using NegoShoeTracker.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace NegoShoeTracker.Web.Controllers
{
    public class MerchantController : Controller
    {
        MerchantDA merchantDa = new MerchantDA();
        // GET: api/Merchant
        public IEnumerable<Merchant> Get()
        {
            return merchantDa.GetAllMerchant();
        }

        // GET: api/Merchant/5
        public string GetOne(int id)
        {
            return "value";
        }

        // POST: api/Merchant
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Merchant/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Merchant/5
        public void Delete(int id)
        {
        }
    }
}
