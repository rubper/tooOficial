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
        private HttpCookie carrito;
        private decimal id;
        CARRITOCOMPRA carro;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public void Session_Start()
        {
            carrito = new HttpCookie("CarritoCompra");
            carro = new CARRITOCOMPRA();
            db.CARRITOCOMPRA.Add(carro);
            db.SaveChanges();
            decimal idultimo = db.CARRITOCOMPRA.Max(p => p.IDCARRITO);
            List<CARRITOCOMPRA> lsCarro = db.CARRITOCOMPRA.Where(cc => cc.IDCARRITO == idultimo).ToList();
            carro = lsCarro.Last();
            id = carro.IDCARRITO;
            //se le añade el valor [id] a la cookie carrito
            carrito.Value = id.ToString();
            //en este punto la cookie se llama CarritoCompra, y tiene un valor id recien creado
            carrito.Expires = DateTime.Now.AddYears(1);
            //acá configuramos al cookie para que expire en un año
        }
        public void Application_BeginRequest()
        {
            HttpCookie myCookie = Request.Cookies["CarritoCompra"];
            if (Response.Cookies["CarritoCompra"].Value == null)
            {
                Response.Cookies.Add(carrito);
            }
            else
            {
                id = decimal.Parse(Response.Cookies["CarritoCompra"].Value.ToString());
                db.CARRITOCOMPRA.Remove(db.CARRITOCOMPRA.Last());
            }

        }
    }
}