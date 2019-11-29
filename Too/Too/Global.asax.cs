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
//                añadirCookieCarrito();
            }
            //sin embargo, si hay un valor de la cookie, y este valor es positivo
            else if (ckRequest.Value != null && int.Parse(ckRequest.Value) > 1)
            {
                try
                {
                    //obtener el valor de cookie en un auxiliar
                    int i = int.Parse(ckRequest.Value);
                    //intentar obtener el carrito de compra con el valor de cookie
                    CARRITOCOMPRA verificarCarrito = db.CARRITOCOMPRA.Find(i);

                    //validar (si existe, entonces...)
                    if (verificarCarrito != null)
                    {
                        //el valor de cookie carrito del paso 1 se llena con el valor de cookie de request
                        carrito.Value = ckRequest.Value;
                        //expira en un año
                        carrito.Expires = DateTime.Now.AddYears(1);
                        //el objeto carro de la presente clase se vuelve el objeto que se trajo en request
                        carro = verificarCarrito;
                        //el id del carrito de la presente clase se vuelve el id que se trajo en request
                        id = i;
                    }
                    //sin embargo, si no existe...
                    else
                    {
                        //eliminar cookie CarritoCompra
                        Response.Cookies.Remove("CarritoCompra");
                        //añadir nueva cookie
//                        añadirCookieCarrito();
                    }

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
//               añadirCookieCarrito();
            }
        }

 /*       public void añadirCookieCarrito()
        {
            //añade a la base un registro vacío de carrito (genera id en base)
            db.CARRITOCOMPRA.Add(new CARRITOCOMPRA());
            db.SaveChanges();
            //obtiene el id del ultimo carrito registrado (se guarda en id)
            id = db.CARRITOCOMPRA.Max(p => p.IDCARRITO);
            //se obtiene el ultimo carrito registrado en objeto
            carro = db.CARRITOCOMPRA.Find(id);
            //se llena cookie con la información
            carrito.Value = id.ToString();
            carrito.Expires = DateTime.Now.AddYears(1);
            //se mete la cookie a la respuesta
            Response.Cookies.Add(carrito);
        }
*/
    }
}
