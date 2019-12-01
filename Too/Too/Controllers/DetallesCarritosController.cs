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
        //FUNCIONAMIENTO DE CARRITO
        // GET: Ver
        public ActionResult Ver(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITOCOMPRA carrito = db.CARRITOCOMPRA.Find(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            List<DETALLECARRITO> lsDetalle = db.DETALLECARRITO.Where(m => m.IDCARRITO == id).ToList();
            ViewBag.ListaCarrito = lsDetalle;
            return View(carrito);
        }

        // GET: DetallesCarritos/Create
        public ActionResult Añadir()
        {
            ViewBag.IDCARRITO = new SelectList(db.CARRITOCOMPRA, "IDCARRITO", "LUGARENTREGA");
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBREPROD");
            return View();
        }

        // POST: DetallesCarritos/Create
        // ACCIÓN AÑADIR PRODUCTO AL CARRITO

        //FUNCIONAMIENTO DE CARRITO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void AñadirProducto([Bind(Include = "IDPRODUCTO,IDCARRITO,CANTIDADPROD,PRECIO")] DETALLECARRITO dETALLECARRITO)
        {
            if (ModelState.IsValid)
            {
                bool seskipeara = true;
                decimal idCarrito = decimal.Parse(Request.Cookies["CarritoCompra"].Value);
                int cantidadCarrito = int.Parse(Request.Cookies["CantidadCarrito"].Value) + 1;
                List<DETALLECARRITO> lsDetalles = db.DETALLECARRITO.Where(m => m.IDCARRITO == idCarrito).ToList();
                if (lsDetalles != null)
                {
                    foreach(DETALLECARRITO detalle in lsDetalles)
                    {
                        if (detalle.IDPRODUCTO == dETALLECARRITO.IDPRODUCTO)
                        {
                            seskipeara = false;
                        }
                    }
                    if (seskipeara)
                    {
                        Response.Cookies["CantidadCarrito"].Value = cantidadCarrito.ToString();
                        Response.Cookies["CantidadCarrito"].Expires = DateTime.Now.AddYears(1);
                        db.DETALLECARRITO.Add(dETALLECARRITO);
                        db.SaveChanges();
                    }

                }
            }
            Response.Redirect("~/Detalle/Producto/" + dETALLECARRITO.IDPRODUCTO.ToString());
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
