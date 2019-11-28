using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Too.Models;

namespace Too.Controllers
{
    public class DetalleController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();
        // GET: Detalle
        public ActionResult Index()
        {
            return View();
        }

        // GET: Detalle/Details/5
        public ActionResult Producto(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: Detalle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Detalle/Create
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

        // GET: Detalle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Detalle/Edit/5
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

        // GET: Detalle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Detalle/Delete/5
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
