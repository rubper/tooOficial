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
        // db.CARRITOCOMPRA.Where(cc => cc.IDCARRITO == id).ToList(); select IDCARRITO from CARRITOCOMPRA where IDCARRITO = id; (obtiene el muy objeto)
        public void Session_Start()
        {
            //inicializa la cookie
            carrito = new HttpCookie("CarritoCompra");
            //añade a la base un registro vacío de carrito (genera id en base)
            db.CARRITOCOMPRA.Add(new CARRITOCOMPRA());
            db.SaveChanges();
            //obtiene el id del ultimo carrito registrado (se guarda en id)
            id = db.CARRITOCOMPRA.Max(p => p.IDCARRITO);
            List<CARRITOCOMPRA> lsCarro = db.CARRITOCOMPRA.Where(cc => cc.IDCARRITO == id).ToList();
            //se obtiene en objeto
            carro = lsCarro.Last();
            //se llena cookie con la información
            carrito.Value = id.ToString();
            carrito.Expires = DateTime.Now.AddYears(1);
            HttpCookie ckRequest = Request.Cookies["CarritoCompra"];
            if (ckRequest == null)
            {
                Response.Cookies.Add(carrito);
            }
            else
            {
                id = decimal.Parse(ckRequest.Value.ToString());
                db.CARRITOCOMPRA.Remove(carro);
            }
        }
    }
}
