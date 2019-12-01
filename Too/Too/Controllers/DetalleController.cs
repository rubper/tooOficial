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
            if (carro == null)
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
            try
            {
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
            }
            catch
            {
                ViewBag.MensajeError = "No hay carrito que mostrar";
                ViewBag.BoolError = true;
                return View(new CARRITOCOMPRA().DETALLECARRITO);
            }
        }

        [HttpPost]
        public ActionResult Carrito([Bind(Include = "IDCARRITO,IDTARIFAENVIO,ENVIO,SUBTOTAL,LUGARENTREGA,METODOPAGO")] CARRITOCOMPRA cARRITOCOMPRA)
        {
            List<CARRITOCOMPRA> listaCarritosQuery = db.CARRITOCOMPRA.Include(m => m.DETALLECARRITO).Where(m => m.IDCARRITO == cARRITOCOMPRA.IDCARRITO).ToList();
            CARRITOCOMPRA carro = new CARRITOCOMPRA();
            if (listaCarritosQuery != null && listaCarritosQuery.Count != 0)
            {
                carro = listaCarritosQuery.Last();
            }
            else
            {
                return RedirectToAction("Error");
            }
            //Obtenido el carrito de la transacción
            //lista de salida de productos*
            List<PRODUCTO> lsprod = new List<PRODUCTO>();
            //obtiene lista de todos los detalles de producto de la base
            List<DETALLECARRITO> lsDetalle = carro.DETALLECARRITO.ToList();
            if (lsDetalle != null)
            {
                //obtiene todas las tarifas de envío
                List<TARIFAENVIO> lsTarifa = db.TARIFAENVIO.ToList();
                //auxiliares
                decimal idproducto, subtotal = 0;
                PRODUCTO productoAux;
                //para cada uno de los elementos en lsDetalle
                foreach (DETALLECARRITO detalleAux in lsDetalle)
                {
                    //obtiene el id de producto
                    idproducto = detalleAux.IDPRODUCTO;
                    //busca el producto con el id
                    productoAux = db.PRODUCTO.Find(idproducto);
                    //si lo encuentra
                    if (productoAux != null)
                    {
                        //añadir el producto a la lista de salida de productos*
                        lsprod.Add(productoAux);
                        //aumentar el subtotal con cada producto que se encuentra
                        subtotal += productoAux.PRECIOUNIT * detalleAux.CANTIDADPROD;
                    }

                }
                //añadir el subtotal al carrito
                ViewBag.subtotal = carro.SUBTOTAL = subtotal;
                //se lleva a lista en una viewbag
                ViewBag.lsta = lsprod;
                if (lsprod == null)
                {
                    return RedirectToAction("Error");
                }
            }
            //HASTA ACÁ SE TIENEN TODOS LOS PRODUCTOS PERTENECIENTES AL CARRITO
            //se obtiene el carrito de compra con el id provisto en el formulario
            //CARRITOCOMPRA result = db.CARRITOCOMPRA.SingleOrDefault(b => b.IDCARRITO == cARRITOCOMPRA.IDCARRITO);
            if (carro != null)
            {
                decimal total = 0;
                carro.IDTARIFAENVIO = cARRITOCOMPRA.IDTARIFAENVIO;
                carro.TARIFAENVIO = db.TARIFAENVIO.Find(cARRITOCOMPRA.IDTARIFAENVIO);
                carro.ENVIO = cARRITOCOMPRA.ENVIO;
                carro.SUBTOTAL = cARRITOCOMPRA.SUBTOTAL;
                carro.LUGARENTREGA = cARRITOCOMPRA.LUGARENTREGA;
                carro.METODOPAGO = cARRITOCOMPRA.LUGARENTREGA;
                var tarifa = carro.TARIFAENVIO;
                if (tarifa != null)
                {

                    total = cARRITOCOMPRA.SUBTOTAL + tarifa.VALORTARIFA;
                    ViewBag.total = total;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Pagar");
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
                if (idcarro == null)
                {
                    return HttpNotFound();
                }
                //busca DetalleCarrito que contenga producto y carrito anteriores
                DETALLECARRITO productoABorrar = db.DETALLECARRITO.Find(id, idcarro);
                //eliminar detalle carrito de la base
                db.DETALLECARRITO.Remove(productoABorrar);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Carrito", new { idcarrito = Convert.ToDecimal(idcarro) });
            }
            return RedirectToAction("Carrito", new { idcarrito = Convert.ToDecimal(idcarro) });
        }
        /// <summary>
        /// Pagar: Lleva a pantalla de compra final, lleva consigo el total y la lista de productos correspondiente al carrito
        /// </summary>
        /// <param name="id">identificador del carrito del usuario actual</param>
        /// <returns>Resultado de acción (vista con parámetro carrito de compra)</returns>
        [Authorize]
        public ActionResult Pagar()
        {
            CARRITOCOMPRA carro = db.CARRITOCOMPRA.Find(decimal.Parse(Request.Cookies["CarritoCompra"].Value));
            return View(carro);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
