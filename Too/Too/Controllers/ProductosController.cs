using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Too.Models;

namespace Too.Controllers
{
    public class ProductosController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        // GET: Productos
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.SUBDEPARTAMENTO);
            return View(pRODUCTO.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(decimal id)
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

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.IDSUBCATEGORIA = new SelectList(db.SUBDEPARTAMENTO, "IDSUBCATEGORIA", "NOMSUBCATEGORIA");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRODUCTO pRODUCTO, HttpPostedFileBase imageload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (imageload != null && imageload.ContentLength > 0)
                    {
                        byte[] imagenData = null;
                        using (var imagen = new BinaryReader(imageload.InputStream))
                        {
                            imagenData = imagen.ReadBytes(imageload.ContentLength);
                        }
                        pRODUCTO.IMAGENPROD = imagenData;
                    }

                    db.PRODUCTO.Add(pRODUCTO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "");
            }
            ViewBag.IDSUBCATEGORIA = new SelectList(db.SUBDEPARTAMENTO, "IDSUBCATEGORIA", "NOMSUBCATEGORIA", pRODUCTO.IDSUBCATEGORIA);
            return View(pRODUCTO);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(decimal id)
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
            ViewBag.IDSUBCATEGORIA = new SelectList(db.SUBDEPARTAMENTO, "IDSUBCATEGORIA", "NOMSUBCATEGORIA", pRODUCTO.IDSUBCATEGORIA);
            return View(pRODUCTO);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPRODUCTO,IDSUBCATEGORIA,NOMBREPROD,DESCPROD,PRECIOUNIT,IMAGENPROD,DISPONIBILIDAD")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
				HttpPostedFileBase FileBase = Request.Files[0];
                WebImage image = new WebImage(FileBase.InputStream);
                pRODUCTO.IMAGENPROD = image.GetBytes();
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDSUBCATEGORIA = new SelectList(db.SUBDEPARTAMENTO, "IDSUBCATEGORIA", "NOMSUBCATEGORIA", pRODUCTO.IDSUBCATEGORIA);
            return View(pRODUCTO);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(decimal id)
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

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
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

        //Obtener imagenes de los productos
        public ActionResult obtenerImagen(int id)
        {
            PRODUCTO produ = db.PRODUCTO.Find(id);
            byte[] byteImagen = produ.IMAGENPROD;
            MemoryStream memoryStream = new MemoryStream(byteImagen);
            return File(memoryStream, "image/jpg");
        }
    }
}
