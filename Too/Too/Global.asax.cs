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
        CARRITOCOMPRA carro;
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
                //añade a la base un registro vacío de carrito (genera id en base)
                if (db.CARRITOCOMPRA.Count() == 0)
                {
                    id = 1;
                }
                else
                {
                    id = db.CARRITOCOMPRA.Max(p => p.IDCARRITO) + 1;
                }
                //se llena cookie con la información
                carrito.Value = id.ToString();
                carrito.Expires = DateTime.Now.AddYears(1);
                //se mete la cookie a la respuesta
                Response.Cookies.Add(carrito);
            }
            else
            {
                //obtener el valor de cookie en un auxiliar
                id = decimal.Parse(ckRequest.Value);
                //intentar obtener el carrito de compra con el valor de cookie
                CARRITOCOMPRA verificarCarrito = db.CARRITOCOMPRA.Find(id);

                //validar (si existe, entonces...)
                if (verificarCarrito != null && verificarCarrito.IDCARRITO == id)
                {
                    carro = verificarCarrito;
                    //el valor de cookie carrito del paso 1 se llena con el valor de cookie de request
                    carrito.Value = ckRequest.Value;
                    //expira en un año
                    carrito.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(carrito);
                }
                //sin embargo, si no existe...
                else
                {
                    //añade a la base un registro vacío de carrito (genera id en base)
                    //obtiene el id del ultimo carrito registrado (se guarda en id)
                    if (db.CARRITOCOMPRA.Count() == 0)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = db.CARRITOCOMPRA.Max(p => p.IDCARRITO) + 1;
                    }
                    //se obtiene el ultimo carrito registrado en objeto
                    //se llena cookie con la información
                    carrito.Value = id.ToString();
                    carrito.Expires = DateTime.Now.AddYears(1);
                    //se mete la cookie a la respuesta
                    Response.Cookies.Add(carrito);
                }

            }
            
        }
    }
}
