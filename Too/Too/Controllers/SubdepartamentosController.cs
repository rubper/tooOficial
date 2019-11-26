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
    public class SubdepartamentosController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        // GET: Subdepartamentos
        public ActionResult Index()
        {
            var sUBDEPARTAMENTO = db.SUBDEPARTAMENTO.Include(s => s.DEPARTAMENTO);
            return View(sUBDEPARTAMENTO.ToList());
        }

        // GET: Subdepartamentos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBDEPARTAMENTO sUBDEPARTAMENTO = db.SUBDEPARTAMENTO.Find(id);
            if (sUBDEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(sUBDEPARTAMENTO);
        }

        // GET: Subdepartamentos/Create
        public ActionResult Create()
        {
            ViewBag.IDCATEGORIAPROD = new SelectList(db.DEPARTAMENTO, "IDCATEGORIAPROD", "NOMBRECATEGORIA");
            return View();
        }

        // POST: Subdepartamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSUBCATEGORIA,IDCATEGORIAPROD,NOMSUBCATEGORIA")] SUBDEPARTAMENTO sUBDEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.SUBDEPARTAMENTO.Add(sUBDEPARTAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCATEGORIAPROD = new SelectList(db.DEPARTAMENTO, "IDCATEGORIAPROD", "NOMBRECATEGORIA", sUBDEPARTAMENTO.IDCATEGORIAPROD);
            return View(sUBDEPARTAMENTO);
        }

        // GET: Subdepartamentos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBDEPARTAMENTO sUBDEPARTAMENTO = db.SUBDEPARTAMENTO.Find(id);
            if (sUBDEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCATEGORIAPROD = new SelectList(db.DEPARTAMENTO, "IDCATEGORIAPROD", "NOMBRECATEGORIA", sUBDEPARTAMENTO.IDCATEGORIAPROD);
            return View(sUBDEPARTAMENTO);
        }

        // POST: Subdepartamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSUBCATEGORIA,IDCATEGORIAPROD,NOMSUBCATEGORIA")] SUBDEPARTAMENTO sUBDEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUBDEPARTAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCATEGORIAPROD = new SelectList(db.DEPARTAMENTO, "IDCATEGORIAPROD", "NOMBRECATEGORIA", sUBDEPARTAMENTO.IDCATEGORIAPROD);
            return View(sUBDEPARTAMENTO);
        }

        // GET: Subdepartamentos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBDEPARTAMENTO sUBDEPARTAMENTO = db.SUBDEPARTAMENTO.Find(id);
            if (sUBDEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(sUBDEPARTAMENTO);
        }

        // POST: Subdepartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            SUBDEPARTAMENTO sUBDEPARTAMENTO = db.SUBDEPARTAMENTO.Find(id);
            db.SUBDEPARTAMENTO.Remove(sUBDEPARTAMENTO);
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
