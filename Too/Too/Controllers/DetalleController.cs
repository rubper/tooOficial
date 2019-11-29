using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Too.Models;

namespace Too.Controllers
{
    public class DetalleController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();

        //FUNCIONAMIENTO DE CARRITO
        // GET: Descripcion del producto 
        public ActionResult Producto(int id)
        {
            //obtiene cookie
            HttpCookie ckRequest = Request.Cookies["CarritoCompra"];
            //valida id de carrito
            if (ckRequest.Value == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //obtiene valor de cookie (id de carrito)
            decimal idCarrito = decimal.Parse(ckRequest.Value);
            //busca objeto carrito con el id
            CARRITOCOMPRA carro = db.CARRITOCOMPRA.Find(idCarrito);
            //valida objeto carrito
            if(carro == null)
            {
                return HttpNotFound();
            }
            //valida id de producto
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //busca objeto producto con el id
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            //valida objeto
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            //mete a viewbag producto y carrito
            ViewBag.PROD = pRODUCTO;
            ViewBag.CARR = carro;
            //manda detallecarro en view
            DETALLECARRITO detallecarro = new DETALLECARRITO();
            return View(detallecarro);
        }
        public ActionResult Carrito(int idcarrito)
        {
            CARRITOCOMPRA carro = db.CARRITOCOMPRA.Find(idcarrito);
            return View(carro.DETALLECARRITO);
        }
        public ActionResult Delete(decimal id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //obtiene el id del carrito actual
                int idcarro = int.Parse(Request.Cookies["CarritoCompra"].Value);
                //validar producto y carrito
                if (id == null || idcarro == null)
                {
                    return HttpNotFound();
                }
                //busca DetalleCarrito que contenga producto y carrito anteriores
                DETALLECARRITO productoABorrar = db.DETALLECARRITO.Find(id, idcarro);
                //eliminar detalle carrito de la base
                db.DETALLECARRITO.Remove(productoABorrar);
                db.SaveChanges();
            } catch (Exception ex)
            {

            }
            return RedirectToAction("Carrito");
        }
    }
}
