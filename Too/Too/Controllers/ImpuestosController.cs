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
    public class ImpuestosController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        // GET: Impuestos
        public ActionResult Index()
        {
            return View(db.IMPUESTO.ToList());
        }

        // GET: Impuestos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMPUESTO iMPUESTO = db.IMPUESTO.Find(id);
            if (iMPUESTO == null)
            {
                return HttpNotFound();
            }
            return View(iMPUESTO);
        }

        // GET: Impuestos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Impuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDIMPUESTO,NOMIMPUESTO,VALORIMPUESTO")] IMPUESTO iMPUESTO)
        {
            if (ModelState.IsValid)
            {
                db.IMPUESTO.Add(iMPUESTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iMPUESTO);
        }

        // GET: Impuestos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMPUESTO iMPUESTO = db.IMPUESTO.Find(id);
            if (iMPUESTO == null)
            {
                return HttpNotFound();
            }
            return View(iMPUESTO);
        }

        // POST: Impuestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDIMPUESTO,NOMIMPUESTO,VALORIMPUESTO")] IMPUESTO iMPUESTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMPUESTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iMPUESTO);
        }

        // GET: Impuestos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMPUESTO iMPUESTO = db.IMPUESTO.Find(id);
            if (iMPUESTO == null)
            {
                return HttpNotFound();
            }
            return View(iMPUESTO);
        }

        // POST: Impuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            IMPUESTO iMPUESTO = db.IMPUESTO.Find(id);
            db.IMPUESTO.Remove(iMPUESTO);
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
