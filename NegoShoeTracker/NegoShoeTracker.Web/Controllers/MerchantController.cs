using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NegoShoeTracker.Web.Controllers
{
    public class MerchantController : ApiController
    {
        // GET: api/Merchant
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Merchant/5
        public string Get(int id)
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
