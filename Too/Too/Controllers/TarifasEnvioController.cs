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
    public class TarifasEnvioController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        // GET: TarifasEnvio
        public ActionResult Index()
        {
            var tARIFAENVIO = db.TARIFAENVIO.Include(t => t.REGION);
            return View(tARIFAENVIO.ToList());
        }

        // GET: TarifasEnvio/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARIFAENVIO tARIFAENVIO = db.TARIFAENVIO.Find(id);
            if (tARIFAENVIO == null)
            {
                return HttpNotFound();
            }
            return View(tARIFAENVIO);
        }

        // GET: TarifasEnvio/Create
        public ActionResult Create()
        {
            ViewBag.IDREGION = new SelectList(db.REGION, "IDREGION", "NOMBREREGION");
            return View();
        }

        // POST: TarifasEnvio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTARIFA,IDREGION,NOMBRETARIFA,VALORTARIFA")] TARIFAENVIO tARIFAENVIO)
        {
            if (ModelState.IsValid)
            {
                db.TARIFAENVIO.Add(tARIFAENVIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDREGION = new SelectList(db.REGION, "IDREGION", "NOMBREREGION", tARIFAENVIO.IDREGION);
            return View(tARIFAENVIO);
        }

        // GET: TarifasEnvio/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARIFAENVIO tARIFAENVIO = db.TARIFAENVIO.Find(id);
            if (tARIFAENVIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDREGION = new SelectList(db.REGION, "IDREGION", "NOMBREREGION", tARIFAENVIO.IDREGION);
            return View(tARIFAENVIO);
        }

        // POST: TarifasEnvio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTARIFA,IDREGION,NOMBRETARIFA,VALORTARIFA")] TARIFAENVIO tARIFAENVIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tARIFAENVIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDREGION = new SelectList(db.REGION, "IDREGION", "NOMBREREGION", tARIFAENVIO.IDREGION);
            return View(tARIFAENVIO);
        }

        // GET: TarifasEnvio/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARIFAENVIO tARIFAENVIO = db.TARIFAENVIO.Find(id);
            if (tARIFAENVIO == null)
            {
                return HttpNotFound();
            }
            return View(tARIFAENVIO);
        }

        // POST: TarifasEnvio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TARIFAENVIO tARIFAENVIO = db.TARIFAENVIO.Find(id);
            db.TARIFAENVIO.Remove(tARIFAENVIO);
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
