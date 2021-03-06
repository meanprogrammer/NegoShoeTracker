﻿using NegoShoeTracker.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegoShoeTracker.Web.Controllers
{
    public class ShipmentController : Controller
    {
        ShipmentDA shipmentDA = new ShipmentDA();

        // GET: Shipment
        public ActionResult Index()
        {
            //var result = shipmentDA.GetAllShipments();
            return View(0);
        }

        // GET: Shipment/Details/5
        public ActionResult Details(int id)
        {
            //var result = shipmentDA.GetOne(id);
            return View(0);
        }

        // GET: Shipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipment/Create
        [HttpPost]
        public ActionResult Create(Shipment shipment)
        {
            try
            {
                // TODO: Add insert logic here
                //shipmentDA.SaveShipment(shipment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shipment/Edit/5
        public ActionResult Edit(int id)
        {
            //var result = shipmentDA.GetOne(id);
            return View(0);
        }

        // POST: Shipment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Shipment shipment)
        {
            try
            {
                //var result = shipmentDA.UpdateShipment(shipment, id);
                TempData.Add("updateMessage", "test");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shipment/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                //shipmentDA.DeleteShipment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Shipment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection s)
        {
            try
            {
                //shipmentDA.DeleteShipment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
