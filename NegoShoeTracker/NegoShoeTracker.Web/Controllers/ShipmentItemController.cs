using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegoShoeTracker.Web.Controllers
{
    public class ShipmentItemController : Controller
    {
        // GET: ShipmentItem
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShipmentItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShipmentItem/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: ShipmentItem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipmentItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShipmentItem/Edit/5
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShipmentItem/Delete/5
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
