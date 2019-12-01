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
                bool seañadira = true;
                int cantidadCarrito = 0;
                decimal idCarrito = decimal.Parse(Request.Cookies["CarritoCompra"].Value);
                HttpCookie galletaCantidad = Request.Cookies.Get("CantidadCarrito");
                HttpCookie galletaCantidadSalida = new HttpCookie("CantidadCarrito");
                List<DETALLECARRITO> lsDetalles;
                //se obtiene lista de detalles donde su carrito corresponda al carrito de la request
                lsDetalles = db.DETALLECARRITO.Where(m => m.IDCARRITO == idCarrito).ToList();
                //si la lista tiene elementos
                if (lsDetalles != null)
                {// para cada uno de los elementos
                    foreach (DETALLECARRITO detalle in lsDetalles)
                    {//si el producto ya está en la lista
                        if (detalle.IDPRODUCTO == dETALLECARRITO.IDPRODUCTO)
                        {//se saltará el ingreso
                            seañadira = false;
                        }
                    }
                    if (seañadira)
                    {
                        db.DETALLECARRITO.Add(dETALLECARRITO);
                        db.SaveChanges();
                    }
                }
                //si la cookie ya existe
                if (galletaCantidad != null)
                {
                    if (galletaCantidad.Value != null)
                    {
                        //cantidad de productos en el carrito es el valor anterior + 1
                        cantidadCarrito = int.Parse(galletaCantidad.Value) + 1;
                    } else
                    {
                        cantidadCarrito = 1;
                    }
                    galletaCantidadSalida.Value = cantidadCarrito.ToString();
                    galletaCantidadSalida.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Set(galletaCantidadSalida);
                } else
                {
                    //si no existe, se intenta obtener la lista de detallecarrito
                    lsDetalles = db.DETALLECARRITO.Where(m => m.IDCARRITO == idCarrito).ToList();
                    //si la lista no está vacía
                    if (lsDetalles != null)
                    {
                        int aux = 0;
                        //para cada uno
                        foreach (DETALLECARRITO detalle in lsDetalles)
                        {
                            aux++;
                        }
                        galletaCantidadSalida.Value = aux.ToString();
                        galletaCantidadSalida.Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Set(galletaCantidadSalida);

                    } else
                    {
                        galletaCantidadSalida.Value = "1";
                        galletaCantidadSalida.Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Set(galletaCantidadSalida);
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
