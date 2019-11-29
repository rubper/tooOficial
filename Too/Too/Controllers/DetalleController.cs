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
                carro = new CARRITOCOMPRA();
                db.CARRITOCOMPRA.Add(carro);
                db.SaveChanges();
                idCarrito = db.CARRITOCOMPRA.Max(p => p.IDCARRITO);
                carro.IDCARRITO = idCarrito;
                Response.Cookies["CarritoCompra"].Value = idCarrito.ToString();
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
                //debe retornar no encontrado pues sería contradictorio que pudiera acceder al detalle de un producto que no existe
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
            try{
                CARRITOCOMPRA carro = db.CARRITOCOMPRA.Find(idcarrito);
                ViewBag.idCarro = idcarrito;
                return View(carro.DETALLECARRITO);
            } catch
            {
                ViewBag.MensajeError = "No hay carrito que mostrar";
                ViewBag.BoolError = true;
                return View(new CARRITOCOMPRA().DETALLECARRITO);
            }
        }
        public ActionResult Delete(decimal id)
        {
            int idcarro;
            //obtiene el id del carrito actual
            idcarro = int.Parse(Request.Cookies["CarritoCompra"].Value);
            try
            {
                //validar producto y carrito
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if ( idcarro == null)
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
                return RedirectToAction("Carrito", new { idcarrito = Convert.ToDecimal(idcarro) });
            }
            return RedirectToAction("Carrito", new { idcarrito = Convert.ToDecimal(idcarro)});
        }
        public ActionResult Pagar(int id)
        {
            CARRITOCOMPRA carro = new CARRITOCOMPRA();
            try
            {
                List<PRODUCTO> lsprod = new List<PRODUCTO>();
                List<DETALLECARRITO> det = db.DETALLECARRITO.Where(m => m.IDCARRITO == id).ToList();
                carro = db.CARRITOCOMPRA.Find(id);
                decimal asdf, total = 0;
                PRODUCTO aux;
                foreach (DETALLECARRITO hes in det)
                {
                    asdf = hes.IDPRODUCTO;
                    aux = db.PRODUCTO.Find(asdf);
                    if (aux != null) {
                        lsprod.Add(aux);
                        total += aux.PRECIOUNIT * hes.CANTIDADPROD;
                    }

                }
                ViewBag.total = total;
                ViewBag.lsta = lsprod;
            } catch { }
            return View(carro);
        }
    }
}
