using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            //obtener id de carrito desde cookies
            HttpCookie myCookie = Request.Cookies["CarritoCompra"];
            ViewBag.IdCarritoCompra = myCookie.Value;
            //Todos los dptos en lista
            List<DEPARTAMENTO> dptos = conexionBase.DEPARTAMENTO.ToList();
            //Todos los productos en lista
            List<PRODUCTO> productos = conexionBase.PRODUCTO.Include(p => p.SUBDEPARTAMENTO).ToList();
            //cantidad de departamentos
            int tamañoArr = dptos.Count();
            //creación de un array de productos del misma cantidad que departamentos
            PRODUCTO[] prodAux = new PRODUCTO[tamañoArr];
            List<PRODUCTO> nousados = new List<PRODUCTO>();
            for (int i = 1; i <= tamañoArr; i++)
            {
                foreach (var j in productos)
                {
                    if (j.SUBDEPARTAMENTO.IDCATEGORIAPROD.Equals(i))
                    {
                        if (prodAux[i - 1] == null)
                        {
                            prodAux[i - 1] = j;
                        }
                        else
                        {
                            nousados.Add(prodAux[i - 1]);
                            prodAux[i - 1] = j;
                        }
                    }
                }
            }
            for (int j = 0; j < tamañoArr; j++)
            {
                if (prodAux[j] == null)
                {
                    prodAux[j] = nousados.Last();
                    nousados.Remove(prodAux[j - 1]);
                }
            }
            productos = prodAux.ToList();
            return View(productos);
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