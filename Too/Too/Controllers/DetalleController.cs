using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
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
                List<PRODUCTO> lsprod = new List<PRODUCTO>();
                List<DETALLECARRITO> lsDetalle = carro.DETALLECARRITO.ToList();
                List<TARIFAENVIO> lsTarifa = db.TARIFAENVIO.ToList();
                decimal idproducto, total = 0;
                PRODUCTO productoAux;
                foreach (DETALLECARRITO detalleAux in lsDetalle)
                {
                    idproducto = detalleAux.IDPRODUCTO;
                    productoAux = db.PRODUCTO.Find(idproducto);
                    if (productoAux != null)
                    {
                        lsprod.Add(productoAux);
                        total += productoAux.PRECIOUNIT * detalleAux.CANTIDADPROD;
                    }

                }
                ViewBag.subtotal = carro.SUBTOTAL = total;
                ViewBag.lsta = lsprod;
                ViewBag.Tarifas = lsTarifa;
                ViewBag.tarif = lsTarifa.First().VALORTARIFA;
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
        /// <summary>
        /// Pagar: Lleva a pantalla de compra final, lleva consigo el total y la lista de productos correspondiente al carrito
        /// </summary>
        /// <param name="id">identificador del carrito del usuario actual</param>
        /// <returns>Resultado de acción (vista con parámetro carrito de compra)</returns>
        [Authorize]
        public ActionResult Pagar([Bind(Include = "IDCARRITO,IDTARIFAENVIO,ENVIO,SUBTOTAL,LUGARENTREGA,METODOPAGO")] CARRITOCOMPRA cARRITOCOMPRA)
        {
            ViewBag.Title = "Pagar";
            CARRITOCOMPRA carro = db.CARRITOCOMPRA.Find(cARRITOCOMPRA.IDCARRITO);
            List<PRODUCTO> lsprod = new List<PRODUCTO>();
            List<DETALLECARRITO> lsDetalle = carro.DETALLECARRITO.ToList();
            if (lsDetalle != null)
            {
                List<TARIFAENVIO> lsTarifa = db.TARIFAENVIO.ToList();
                decimal idproducto, subtotal = 0;
                PRODUCTO productoAux;
                foreach (DETALLECARRITO detalleAux in lsDetalle)
                {
                    idproducto = detalleAux.IDPRODUCTO;
                    productoAux = db.PRODUCTO.Find(idproducto);
                    if (productoAux != null)
                    {
                        lsprod.Add(productoAux);
                        subtotal += productoAux.PRECIOUNIT * detalleAux.CANTIDADPROD;
                    }

                }
                ViewBag.subtotal = carro.SUBTOTAL = subtotal;
                ViewBag.lsta = lsprod;
            }
            var result = db.CARRITOCOMPRA.SingleOrDefault(b => b.IDCARRITO == cARRITOCOMPRA.IDCARRITO);
            if (result != null)
            {
                result.IDTARIFAENVIO = cARRITOCOMPRA.IDTARIFAENVIO;
                result.ENVIO = cARRITOCOMPRA.ENVIO;
                result.SUBTOTAL = cARRITOCOMPRA.SUBTOTAL;
                result.LUGARENTREGA = cARRITOCOMPRA.LUGARENTREGA;
                result.METODOPAGO = cARRITOCOMPRA.LUGARENTREGA;
                var tarifa = db.TARIFAENVIO.Find(cARRITOCOMPRA.IDTARIFAENVIO);
                if(tarifa != null)
                {
                    var total = cARRITOCOMPRA.SUBTOTAL + tarifa.VALORTARIFA;
                    ViewBag.total = total;
                }
                db.SaveChanges();
            }
            return View(cARRITOCOMPRA);
        }
    }
}
