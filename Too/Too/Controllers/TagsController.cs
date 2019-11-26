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
    public class TagsController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        // GET: Tags
        public ActionResult Index()
        {
            return View(db.TAG.ToList());
        }

        // GET: Tags/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAG tAG = db.TAG.Find(id);
            if (tAG == null)
            {
                return HttpNotFound();
            }
            return View(tAG);
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTAGPROD,NOMTAG")] TAG tAG)
        {
            if (ModelState.IsValid)
            {
                db.TAG.Add(tAG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAG);
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAG tAG = db.TAG.Find(id);
            if (tAG == null)
            {
                return HttpNotFound();
            }
            return View(tAG);
        }

        // POST: Tags/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTAGPROD,NOMTAG")] TAG tAG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAG);
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAG tAG = db.TAG.Find(id);
            if (tAG == null)
            {
                return HttpNotFound();
            }
            return View(tAG);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TAG tAG = db.TAG.Find(id);
            db.TAG.Remove(tAG);
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
