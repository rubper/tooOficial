using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Too.Models;
using System.Data.Entity;

namespace Too.Controllers
{
    public class ArticulosController : Controller
    {
        private contextoBaseVentas db = new contextoBaseVentas();
        // GET: Articulos
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(m => m.SUBDEPARTAMENTO);
            return View(pRODUCTO.ToList());
        }
        [HttpPost]
        public ActionResult Busqueda(string search)
        {
            List<PRODUCTO> lsProductos = db.PRODUCTO.Include(m => m.TAG).ToList();
            List<PRODUCTO> listaSalida = new List<PRODUCTO>();
            string[] nombreProducto;
            if (search != null)
            {
                string[] lsAux = search.ToUpper().Split(' ', '.', ',');
                if (lsProductos.Count != 0) {
                    foreach (PRODUCTO prod in lsProductos)
                    {
                        nombreProducto = prod.NOMBREPROD.ToUpper().Split(' ', '.', ',');
                        if (nombreProducto.Length != 0) {
                            foreach (string varnombre in nombreProducto)
                            {
                                foreach (string varBusqueda in lsAux)
                                {
                                    if (varBusqueda == varnombre)
                                    {
                                        if (listaSalida.Contains(db.PRODUCTO.Find(prod.IDPRODUCTO))) { } 
                                        else
                                        {
                                            listaSalida.Add(prod);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return View(listaSalida);
        }
    }
}