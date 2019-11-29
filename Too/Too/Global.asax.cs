using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Too.Models;

namespace Too
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private contextoBaseVentas db = new contextoBaseVentas();
        private HttpCookie carrito, cantCarrito;

        private decimal id;
        CARRITOCOMPRA carro = new CARRITOCOMPRA();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        // db.CARRITOCOMPRA.Where(cc => cc.IDCARRITO == id).ToList(); select IDCARRITO from CARRITOCOMPRA where IDCARRITO = id; (obtiene el muy objeto)
        public void Session_Start()
        {
            //inicializa las cookies
            carrito = new HttpCookie("CarritoCompra");
            cantCarrito = new HttpCookie("CantidadCarrito");
            //obtener cookie "CarritoCompra" de la request
            HttpCookie ckRequest = Request.Cookies["CarritoCompra"];
            //si la cookie de la request es nula, añadir nueva
            if (ckRequest == null)
            {
                id = 1;
                if (db.CARRITOCOMPRA.Count() != 0)
                {
                    id = db.CARRITOCOMPRA.Max(p => p.IDCARRITO) + 1;
                }
                //se llena cookie con la información
                Response.Cookies["CarritoCompra"].Value = id.ToString();
                Response.Cookies["CarritoCompra"].Expires = DateTime.Now.AddYears(1);
                CARRITOCOMPRA aux = new CARRITOCOMPRA();
                //carro.IDCARRITO = id;
                db.CARRITOCOMPRA.Add(aux);
                db.SaveChanges();
            }
            else
            {
                //obtener el valor de cookie en un auxiliar
                id = decimal.Parse(ckRequest.Value);
                //intentar obtener el carrito de compra con el valor de cookie
                CARRITOCOMPRA verificarCarrito = db.CARRITOCOMPRA.Find(id);

                //validar (caso 1: es válida)
                if (verificarCarrito != null && verificarCarrito.IDCARRITO == id)
                {
                    Response.Cookies["CarritoCompra"].Value = ckRequest.Value;
                    Response.Cookies["CarritoCompra"].Expires = DateTime.Now.AddYears(1);

                }
                //sin embargo, (Caso 2: no es válida)
                else
                {
                    //añade a la base un registro vacío de carrito (genera id en base)
                    //obtiene el id del ultimo carrito registrado (se guarda en id
                    id = 1;
                    if (db.CARRITOCOMPRA.Count() != 0)
                    {
                        id = db.CARRITOCOMPRA.Max(p => p.IDCARRITO) + 1;
                    }
                    //se llena cookie con la información
                    Response.Cookies["CarritoCompra"].Value = id.ToString();
                    Response.Cookies["CarritoCompra"].Expires = DateTime.Now.AddYears(1);
                    CARRITOCOMPRA aux = new CARRITOCOMPRA();
                    //carro.IDCARRITO = id;
                    db.CARRITOCOMPRA.Add(aux);
                    db.SaveChanges();
                }

            }
            
        }
    }
}
