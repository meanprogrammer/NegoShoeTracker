using NegoShoeTracker.Library;
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

        public ActionResult Details(int id)
        {
            var data = merchantDa.GetOne(id);
            return View(data);
        }

        // GET: api/Merchant/5
        public ActionResult Edit(int id)
        {
            var data = merchantDa.GetOne(id);
            return View(data);
        }

         [System.Web.Mvc.HttpPost]
        public ActionResult Edit(int id, MerchantDTO merchant)
        {
            try
            {
                var result = merchantDa.UpdateMerchant(id, merchant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: api/Merchant
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(MerchantDTO merchant)
        {
            bool result = merchantDa.SaveMerchant(merchant);
            string msg = result ? "Saved Successfully." : "Saving Failed.";
            ViewBag.Message = msg;
            ModelState.Clear();
            return View();
        }

        // DELETE: api/Merchant/5
        public ActionResult Delete(int id)
        {
            bool result = merchantDa.DeleteMerchant(id);
            if (result)
            {
                var data = merchantDa.GetAllMerchant();
                return View("Index", data);
            }
            else
            {
                return View("Delete","Delete failed.");
            }

        }
    }
}
