using NegoShoeTracker.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegoShoeTracker.Web.Controllers
{
    public class PurchaseItemController : Controller
    {
        MerchantDA merchant = new MerchantDA();
        ItemStatusDA status = new ItemStatusDA();
        PurchaseItemDA purchaseItemDa = new PurchaseItemDA(); 
        // GET: ShipmentItem
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShipmentItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
            //var si = shipment.GetOne(id);
            //return View(si);
        }

        // GET: ShipmentItem/Create
        public ActionResult Create()
        {
            var currentId = Request.UrlReferrer.Segments.LastOrDefault();
            ViewData["merchants"] = AppendBlankMerchant( merchant.GetAllMerchant() );
            ViewData["statuses"] = AppendBlankStatus( status.GetAllItemStatus() );
            ViewData["purchaseId"] = currentId;
            return PartialView("_Create");
        }

        private List<ItemStatusDTO> AppendBlankStatus(List<ItemStatusDTO> list)
        {
            ItemStatusDTO s = new ItemStatusDTO() { RecordID = 0, Status = "-- SELECT --" };
            list.Insert(0, s);
            return list;
        }

        private List<MerchantDTO> AppendBlankMerchant(List<MerchantDTO> list)
        { 
            MerchantDTO blank = new MerchantDTO() { MerchantID = 0, Name = "-- SELECT --" };
            list.Insert(0, blank);
            return list;
        }

        // POST: ShipmentItem/Create
        [HttpPost]
        public ActionResult Create(PurchaseItemDTO item)
        {
            try
            {
                // TODO: Add insert logic here
                purchaseItemDa.Save(item);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }

        // GET: ShipmentItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShipmenIttem/Edit/5
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

        
        // GET: ShipmentItem/Delete/5
        [Route("PurchaseItem/{id}/{parentId}")]
        public ActionResult Delete(int id, int parentId)
        {
            try
            {
                // TODO: Add delete logic here
                purchaseItemDa.Delete(id);
                return RedirectToAction("Details", "Purchase", new { id =parentId });
            }
            catch
            {
                return View();
            }
        }

    }
}
