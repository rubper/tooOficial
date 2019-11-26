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
    public class CarritosComprasController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        // GET: CarritosCompras
        public ActionResult Index()
        {
            var cARRITOCOMPRA = db.CARRITOCOMPRA.Include(c => c.TARIFAENVIO).Include(c => c.USUARIO);
            return View(cARRITOCOMPRA.ToList());
        }

        // GET: CarritosCompras/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITOCOMPRA cARRITOCOMPRA = db.CARRITOCOMPRA.Find(id);
            if (cARRITOCOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cARRITOCOMPRA);
        }

        // GET: CarritosCompras/Create
        public ActionResult Create()
        {
            ViewBag.IDTARIFAENVIO = new SelectList(db.TARIFAENVIO, "IDTARIFA", "NOMBRETARIFA");
            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "IDUSUARIO", "USERNAME");
            return View();
        }

        // POST: CarritosCompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCARRITO,IDTARIFAENVIO,IDUSUARIO,ENVIO,SUBTOTAL,LUGARENTREGA,METODOPAGO,TOTAL")] CARRITOCOMPRA cARRITOCOMPRA)
        {
            if (ModelState.IsValid)
            {
                db.CARRITOCOMPRA.Add(cARRITOCOMPRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDTARIFAENVIO = new SelectList(db.TARIFAENVIO, "IDTARIFA", "NOMBRETARIFA", cARRITOCOMPRA.IDTARIFAENVIO);
            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "IDUSUARIO", "USERNAME", cARRITOCOMPRA.IDUSUARIO);
            return View(cARRITOCOMPRA);
        }

        // GET: CarritosCompras/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITOCOMPRA cARRITOCOMPRA = db.CARRITOCOMPRA.Find(id);
            if (cARRITOCOMPRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDTARIFAENVIO = new SelectList(db.TARIFAENVIO, "IDTARIFA", "NOMBRETARIFA", cARRITOCOMPRA.IDTARIFAENVIO);
            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "IDUSUARIO", "USERNAME", cARRITOCOMPRA.IDUSUARIO);
            return View(cARRITOCOMPRA);
        }

        // POST: CarritosCompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCARRITO,IDTARIFAENVIO,IDUSUARIO,ENVIO,SUBTOTAL,LUGARENTREGA,METODOPAGO,TOTAL")] CARRITOCOMPRA cARRITOCOMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARRITOCOMPRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDTARIFAENVIO = new SelectList(db.TARIFAENVIO, "IDTARIFA", "NOMBRETARIFA", cARRITOCOMPRA.IDTARIFAENVIO);
            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "IDUSUARIO", "USERNAME", cARRITOCOMPRA.IDUSUARIO);
            return View(cARRITOCOMPRA);
        }

        // GET: CarritosCompras/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITOCOMPRA cARRITOCOMPRA = db.CARRITOCOMPRA.Find(id);
            if (cARRITOCOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cARRITOCOMPRA);
        }

        // POST: CarritosCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CARRITOCOMPRA cARRITOCOMPRA = db.CARRITOCOMPRA.Find(id);
            db.CARRITOCOMPRA.Remove(cARRITOCOMPRA);
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
