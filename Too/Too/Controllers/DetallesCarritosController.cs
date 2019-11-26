using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Too.Models;

namespace Too.Controllers
{
    public class DetallesCarritosController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        // GET: DetallesCarritos
        public ActionResult Index()
        {
            var dETALLECARRITO = db.DETALLECARRITO.Include(d => d.CARRITOCOMPRA).Include(d => d.PRODUCTO);
            return View(dETALLECARRITO.ToList());
        }

        // GET: DetallesCarritos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLECARRITO dETALLECARRITO = db.DETALLECARRITO.Find(id);
            if (dETALLECARRITO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLECARRITO);
        }

        // GET: DetallesCarritos/Create
        public ActionResult Create()
        {
            ViewBag.IDCARRITO = new SelectList(db.CARRITOCOMPRA, "IDCARRITO", "LUGARENTREGA");
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD");
            return View();
        }

        // POST: DetallesCarritos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPRODUCTO,IDCARRITO,CANTIDADPROD,PRECIO")] DETALLECARRITO dETALLECARRITO)
        {
            if (ModelState.IsValid)
            {
                db.DETALLECARRITO.Add(dETALLECARRITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCARRITO = new SelectList(db.CARRITOCOMPRA, "IDCARRITO", "LUGARENTREGA", dETALLECARRITO.IDCARRITO);
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD", dETALLECARRITO.IDPRODUCTO);
            return View(dETALLECARRITO);
        }

        // GET: DetallesCarritos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLECARRITO dETALLECARRITO = db.DETALLECARRITO.Find(id);
            if (dETALLECARRITO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCARRITO = new SelectList(db.CARRITOCOMPRA, "IDCARRITO", "LUGARENTREGA", dETALLECARRITO.IDCARRITO);
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD", dETALLECARRITO.IDPRODUCTO);
            return View(dETALLECARRITO);
        }

        // POST: DetallesCarritos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPRODUCTO,IDCARRITO,CANTIDADPROD,PRECIO")] DETALLECARRITO dETALLECARRITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLECARRITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCARRITO = new SelectList(db.CARRITOCOMPRA, "IDCARRITO", "LUGARENTREGA", dETALLECARRITO.IDCARRITO);
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD", dETALLECARRITO.IDPRODUCTO);
            return View(dETALLECARRITO);
        }

        // GET: DetallesCarritos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLECARRITO dETALLECARRITO = db.DETALLECARRITO.Find(id);
            if (dETALLECARRITO == null)
            {
                return HttpNotFound();
            }
            return View(dETALLECARRITO);
        }

        // POST: DetallesCarritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            DETALLECARRITO dETALLECARRITO = db.DETALLECARRITO.Find(id);
            db.DETALLECARRITO.Remove(dETALLECARRITO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
