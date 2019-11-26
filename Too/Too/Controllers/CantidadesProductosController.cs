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
    public class CantidadesProductosController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        // GET: CantidadesProductos
        public ActionResult Index()
        {
            var cANTIDADPRODUCTO = db.CANTIDADPRODUCTO.Include(c => c.PRODUCTO);
            return View(cANTIDADPRODUCTO.ToList());
        }

        // GET: CantidadesProductos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANTIDADPRODUCTO cANTIDADPRODUCTO = db.CANTIDADPRODUCTO.Find(id);
            if (cANTIDADPRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cANTIDADPRODUCTO);
        }

        // GET: CantidadesProductos/Create
        public ActionResult Create()
        {
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD");
            return View();
        }

        // POST: CantidadesProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCANTIDADPROD,IDPRODUCTO,STOCKPROD")] CANTIDADPRODUCTO cANTIDADPRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.CANTIDADPRODUCTO.Add(cANTIDADPRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD", cANTIDADPRODUCTO.IDPRODUCTO);
            return View(cANTIDADPRODUCTO);
        }

        // GET: CantidadesProductos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANTIDADPRODUCTO cANTIDADPRODUCTO = db.CANTIDADPRODUCTO.Find(id);
            if (cANTIDADPRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD", cANTIDADPRODUCTO.IDPRODUCTO);
            return View(cANTIDADPRODUCTO);
        }

        // POST: CantidadesProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCANTIDADPROD,IDPRODUCTO,STOCKPROD")] CANTIDADPRODUCTO cANTIDADPRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANTIDADPRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD", cANTIDADPRODUCTO.IDPRODUCTO);
            return View(cANTIDADPRODUCTO);
        }

        // GET: CantidadesProductos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANTIDADPRODUCTO cANTIDADPRODUCTO = db.CANTIDADPRODUCTO.Find(id);
            if (cANTIDADPRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cANTIDADPRODUCTO);
        }

        // POST: CantidadesProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CANTIDADPRODUCTO cANTIDADPRODUCTO = db.CANTIDADPRODUCTO.Find(id);
            db.CANTIDADPRODUCTO.Remove(cANTIDADPRODUCTO);
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
