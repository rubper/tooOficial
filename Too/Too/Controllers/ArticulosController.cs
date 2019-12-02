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
            ViewBag.categors = db.SUBDEPARTAMENTO.Include(m => m.DEPARTAMENTO);
            var pRODUCTO = db.PRODUCTO.Include(m => m.SUBDEPARTAMENTO);
            return View(pRODUCTO.ToList());
        }
        [HttpPost]
        public ActionResult Index(string cats, string fltPrecio)
        {
            List<PRODUCTO> lsProductos = db.PRODUCTO.Include(m => m.SUBDEPARTAMENTO.DEPARTAMENTO).ToList();
            List<PRODUCTO> listaSalida = new List<PRODUCTO>();
            //valida lista de todos los productos
            if (lsProductos != null)
            {
                //si el campo de precio está vacio o tiene 0
                if (fltPrecio == "" || fltPrecio == "0" || fltPrecio == "0.0" || fltPrecio == "0.00")
                { //pero se ha seleccionado algún radiobotón
                    if (cats != "")
                    {
                        //iterar
                        foreach (PRODUCTO prodTodos in lsProductos)
                        { //si la cat del producto corresponde con la que nos dieron
                            if (prodTodos.SUBDEPARTAMENTO.DEPARTAMENTO.NOMBRECATEGORIA == cats)
                            { //añadir a la lista
                                listaSalida.Add(prodTodos);
                            }
                        }
                    }
                //en caso contrario el campo de precio tiene un valor, intentar parsear (si se puede es porque es número)
                //si el campo precio no es número
                } else if (!decimal.TryParse(fltPrecio,out decimal i))
                {
                    //si el primer char del precio es un !
                    if(fltPrecio.First() == '!') {
                        //reemplazar todos los !, por 0
                        fltPrecio = fltPrecio.Replace("!", "0");
                        //intentar parsear
                        decimal.TryParse(fltPrecio, out decimal precio);
                        //sí no se ha seleccionado ningun radioboton
                        if (cats == "")
                        {
                            //recorrer la lista
                            foreach (PRODUCTO prodTodos in lsProductos)
                            {//si el elemento actual es mayor que el precio dado
                                if (prodTodos.PRECIOUNIT > precio)
                                        listaSalida.Add(prodTodos);
                            }
                        } else
                        {
                            //recorrer la lista
                            foreach (PRODUCTO prodTodos in lsProductos)
                            {//si el elemento actual es mayor que el precio dado
                                if (prodTodos.PRECIOUNIT > precio)
                                    //y su categoría corresponde con la categoría dada
                                    if (prodTodos.SUBDEPARTAMENTO.DEPARTAMENTO.NOMBRECATEGORIA == cats)
                                    {
                                        listaSalida.Add(prodTodos);
                                    }
                            }
                        }
                        //caso contrario, si el primer char del precio no es un !
                    } else
                    {
                        //intentar parsear
                        decimal.TryParse(fltPrecio, out decimal precio);
                        //sí no se ha seleccionado ningun radioboton
                        if (cats == "")
                        {
                            //recorrer la lista
                            foreach (PRODUCTO prodTodos in lsProductos)
                            {//si el elemento actual es mayor que el precio dado
                                if (prodTodos.PRECIOUNIT <= precio)
                                    listaSalida.Add(prodTodos);
                            }
                        }
                        else
                        {
                            //recorrer la lista
                            foreach (PRODUCTO prodTodos in lsProductos)
                            {//si el elemento actual es mayor que el precio dado
                                if (prodTodos.PRECIOUNIT <= precio)
                                    //y su categoría corresponde con la categoría dada
                                    if (prodTodos.SUBDEPARTAMENTO.DEPARTAMENTO.NOMBRECATEGORIA == cats)
                                    {
                                        listaSalida.Add(prodTodos);
                                    }
                            }
                        }
                    }
                }
                else
                {
                    //intentar parsear
                    decimal.TryParse(fltPrecio, out decimal precio);
                    //sí no se ha seleccionado ningun radioboton
                    if (cats == "")
                    {
                        //recorrer la lista
                        foreach (PRODUCTO prodTodos in lsProductos)
                        {//si el elemento actual es mayor que el precio dado
                            if (prodTodos.PRECIOUNIT <= precio)
                                listaSalida.Add(prodTodos);
                        }
                    }
                    else
                    {
                        //recorrer la lista
                        foreach (PRODUCTO prodTodos in lsProductos)
                        {//si el elemento actual es mayor que el precio dado
                            if (prodTodos.PRECIOUNIT <= precio)
                                //y su categoría corresponde con la categoría dada
                                if (prodTodos.SUBDEPARTAMENTO.DEPARTAMENTO.NOMBRECATEGORIA == cats)
                                {
                                    listaSalida.Add(prodTodos);
                                }
                        }
                    }
                }
            }
            ViewBag.categors = db.SUBDEPARTAMENTO.Include(m => m.DEPARTAMENTO);
            return View(listaSalida);
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