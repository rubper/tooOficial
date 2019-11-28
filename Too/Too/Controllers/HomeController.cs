using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Too.Models;

namespace Too.Controllers
{
    public class HomeController : Controller
    {
        private contextoBaseVentas conexionBase = new contextoBaseVentas();
        public ActionResult Index()
        {
            HttpCookie myCookie = Request.Cookies["CarritoCompra"];
            ViewBag.IdCarritoCompra = myCookie.Value;
            ViewBag.IdSession = Request.Cookies["ASP.NET_SessionId"].Value;
            var pRODUCTO = conexionBase.PRODUCTO.Include(p => p.SUBDEPARTAMENTO);
            return View(pRODUCTO.ToList());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}