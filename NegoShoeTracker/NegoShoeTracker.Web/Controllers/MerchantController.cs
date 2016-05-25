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
        public ActionResult Index()
        {
            var data = merchantDa.GetAllMerchant();
            return View(data);
        }

        // GET: api/Merchant/5
        public ActionResult Edit(int id)
        {
            var data = merchantDa.GetOne(id);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: api/Merchant
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(Merchant merchant)
        {
            bool result = merchantDa.SaveMerchant(merchant);
            string msg = result ? "Saved Successfully." : "Saving Failed.";
            ViewBag.Message = msg;
            ModelState.Clear();
            return View();
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
