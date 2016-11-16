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
        PurchaseItemDA purchaseItemDa = new PurchaseItemDA();
        // GET: Purchase
        public ActionResult Index()
        {
            var data = purchaseDa.GetAllPurchases();
            return View(data);
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int id)
        {
            var data = purchaseDa.GetOnePurchase(id);
            data.Items = purchaseItemDa.GetAll(id);
            return View(data);
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
            PurchaseDTO data = purchaseDa.GetOnePurchase(id);
            return View(data);
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PurchaseDTO dto)
        {
            try
            {
                // TODO: Add update logic here
                bool result = purchaseDa.Update(id, dto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Purchase/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                bool result = purchaseDa.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
