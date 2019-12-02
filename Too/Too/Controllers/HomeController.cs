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

            //Todos los productos en lista
            List<PRODUCTO> productos = conexionBase.PRODUCTO.Include(p => p.SUBDEPARTAMENTO).ToList();
            //Todos los dptos en lista
            List<DEPARTAMENTO> dptos = conexionBase.DEPARTAMENTO.ToList();
            //cantidad de departamentos
            int cantidadDepartamentos = dptos.Count();

            //AUXILIARES
            //Lista que se usará de salida hacia la view
            List<PRODUCTO> listaProductosSalida = new List<PRODUCTO>();
            //no usados
            List<PRODUCTO> nousados = new List<PRODUCTO>();
            //objeto producto que se usará para meter a lista
            PRODUCTO prodAux = new PRODUCTO();
            //para cada uno de los departamentos
            foreach (var departamento in dptos)
            {
                //revisar en cada uno de los productos
                foreach (var producto in productos)
                {
                    //si el producto pertenece a dicho departamento
                    if (producto.SUBDEPARTAMENTO.IDCATEGORIAPROD.Equals(departamento.IDCATEGORIAPROD))
                    {
                        //si es así, entonces prodAux será el producto actual de la lista productos (contiene todos)
                        prodAux = producto;
                        //se verifica si la lista de salida no está vacía
                        if (listaProductosSalida.Count != 0)
                        {
                            //validar: si la lista ya contiene un producto con dicha categoría
                            if (revisarSiContiene(listaProductosSalida, departamento.IDCATEGORIAPROD))
                            {
                                //intentar
                                try
                                {
                                    //eliminar todos los productos con la categoría especificada
                                    listaProductosSalida.RemoveAll(match: m => m.SUBDEPARTAMENTO.IDCATEGORIAPROD == departamento.IDCATEGORIAPROD);
                                    //añadir prodAux
                                    listaProductosSalida.Add(prodAux);
                                }
                                catch (ArgumentNullException ex)
                                {
                                    //no se encontró en caso contrario
                                    return new HttpNotFoundResult();
                                }

                            }
                            else
                            //si la lista no contiene el producto
                            {
                                listaProductosSalida.Add(prodAux);
                            }
                        }
                        else
                        {
                            listaProductosSalida.Add(prodAux);

                        }
                    }
                }
            }
            ViewBag.listaProds = conexionBase.PRODUCTO.Include(p => p.SUBDEPARTAMENTO).ToList();
            return View(listaProductosSalida);
        }

        //revisa la lista ya contiene un producto con la categoría indicada
        private bool revisarSiContiene(List<PRODUCTO> listaProductosSalida, decimal categoria)
        {
            bool aux = false;
            if (listaProductosSalida.Count != 0)
            {
                foreach (PRODUCTO prod in listaProductosSalida)
                {
                    if (prod.SUBDEPARTAMENTO.IDCATEGORIAPROD == categoria)
                    {
                        aux = true;
                    }
                }
            }
            return aux;
        }

        private PRODUCTO obtenerUltimoProductoConCategoria(List<PRODUCTO> listaProductosSalida, decimal categoria)
        {
            PRODUCTO aux = new PRODUCTO();
            foreach (PRODUCTO prod in listaProductosSalida)
            {
                if (prod.SUBDEPARTAMENTO.IDCATEGORIAPROD == categoria)
                {
                    aux = prod;
                }
            }
            return aux;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Admin()
        {
            ViewBag.Message = "Gestione los elementos de su página web de ventas";

            return View();
        }
    }
}