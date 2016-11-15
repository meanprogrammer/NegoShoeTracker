using NegoShoeTracker.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegoShoeTracker.Web.Controllers
{
    public class PurchaseController : Controller
    {
        PurchaseDA purchaseDa = new PurchaseDA();
        MerchantDA merchantDa = new MerchantDA();
        // GET: Purchase
        public ActionResult Index()
        {
            var data = purchaseDa.GetAllPurchases();
            return View(data);
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            //merchants
            var merchants = merchantDa.GetAllMerchant();
            ViewData["merchants"] = merchants;
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        public ActionResult Create(PurchaseDTO dto)
        {
            var merchants = merchantDa.GetAllMerchant();
            ViewData["merchants"] = merchants;
            try
            {
                bool result = purchaseDa.Save(dto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Purchase/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
