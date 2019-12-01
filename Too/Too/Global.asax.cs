using Too.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Too
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
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
            if (db.REGION.Count() == 0)
            {
                REGION region = new REGION();
                region.NOMBREREGION = "Región por defecto";
                db.REGION.Add(region);
                db.SaveChanges();
            }
            if (db.TARIFAENVIO.Count() == 0)
            {
                TARIFAENVIO tarifaInicial = new TARIFAENVIO();
                tarifaInicial.NOMBRETARIFA = "Sin Tarifa - 0";
                tarifaInicial.VALORTARIFA = 0;
                tarifaInicial.IDREGION = 1;
                db.TARIFAENVIO.Add(tarifaInicial);
                db.SaveChanges();
            }
            if (db.USUARIO.Count() == 0)
            {
                USUARIO usuarioInicial = new USUARIO();
                usuarioInicial.USERNAME = "visitante";
                usuarioInicial.PRIMERNOMBRE = "Visitante";
                usuarioInicial.PRIMERAPELLIDO = "Ventas Web";
                usuarioInicial.DIRECCION = "Ventas Web";
                usuarioInicial.CIUDAD = "Ciudad Visitante";
                usuarioInicial.PROVINCIA = "Provincia Visitante";
                usuarioInicial.TELEFONO = "telefono";
                usuarioInicial.PAIS = "Pais Visitante";
                usuarioInicial.EMAIL = "visitante@ventasweb.com";
                db.USUARIO.Add(usuarioInicial);
                db.SaveChanges();
            }
        }
        public void Application_AuthenticateRequest()
        {

        }
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
                carrito.Value = id.ToString();
                carrito.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Set(carrito);
                cantCarrito.Value = "0";
                cantCarrito.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Set(cantCarrito);
                CARRITOCOMPRA aux = new CARRITOCOMPRA();
                aux.IDCARRITO = id;
                aux.IDTARIFAENVIO = 1;
                aux.IDUSUARIO = 1;
                aux.USUARIO = db.USUARIO.Find(1);
                aux.TARIFAENVIO = db.TARIFAENVIO.Find(1);
                if (aux.TARIFAENVIO == null)
                {
                    if (db.REGION.Count() == 0)
                    {
                        REGION region = new REGION();
                        region.NOMBREREGION = "Región por defecto";
                        db.REGION.Add(region);
                        db.SaveChanges();
                    }
                    if (db.TARIFAENVIO.Count() == 0)
                    {
                        TARIFAENVIO tarifaInicial = new TARIFAENVIO();
                        tarifaInicial.NOMBRETARIFA = "Sin Tarifa - 0";
                        tarifaInicial.VALORTARIFA = 0;
                        tarifaInicial.IDREGION = 1;
                        db.TARIFAENVIO.Add(tarifaInicial);
                        db.SaveChanges();
                    }
                    aux.TARIFAENVIO = db.TARIFAENVIO.Find(1);

                }
                if (aux.USUARIO == null)
                {
                    USUARIO usuarioInicial = new USUARIO();
                    usuarioInicial.USERNAME = "visitante";
                    usuarioInicial.PRIMERNOMBRE = "Visitante";
                    usuarioInicial.PRIMERAPELLIDO = "Ventas Web";
                    usuarioInicial.DIRECCION = "Ventas Web";
                    usuarioInicial.CIUDAD = "Ciudad Visitante";
                    usuarioInicial.PROVINCIA = "Provincia Visitante";
                    usuarioInicial.TELEFONO = "telefono";
                    usuarioInicial.PAIS = "Pais Visitante";
                    usuarioInicial.EMAIL = "visitante@ventasweb.com";
                    db.USUARIO.Add(usuarioInicial);
                    db.SaveChanges();
                    aux.USUARIO = db.USUARIO.Find(1);
                }
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
                    Response.Cookies["CantidadCarrito"].Value = "0";
                    CARRITOCOMPRA aux = new CARRITOCOMPRA();
                    aux.IDTARIFAENVIO = 1;
                    aux.IDUSUARIO = 1;
                    aux.USUARIO = db.USUARIO.Find(1);
                    aux.TARIFAENVIO = db.TARIFAENVIO.Find(1);
                    if(aux.TARIFAENVIO == null)
                    {
                        if (db.REGION.Count() == 0)
                        {
                            REGION region = new REGION();
                            region.NOMBREREGION = "Región por defecto";
                            db.REGION.Add(region);
                            db.SaveChanges();
                        }
                        if (db.TARIFAENVIO.Count() == 0)
                        {
                            TARIFAENVIO tarifaInicial = new TARIFAENVIO();
                            tarifaInicial.NOMBRETARIFA = "Sin Tarifa - 0";
                            tarifaInicial.VALORTARIFA = 0;
                            tarifaInicial.IDREGION = 1;
                            db.TARIFAENVIO.Add(tarifaInicial);
                            db.SaveChanges();
                        }
                        aux.TARIFAENVIO = db.TARIFAENVIO.Find(1);

                    }
                    if (aux.USUARIO == null)
                    {
                        USUARIO usuarioInicial = new USUARIO();
                        usuarioInicial.USERNAME = "visitante";
                        usuarioInicial.PRIMERNOMBRE = "Visitante";
                        usuarioInicial.PRIMERAPELLIDO = "Ventas Web";
                        usuarioInicial.DIRECCION = "Ventas Web";
                        usuarioInicial.CIUDAD = "Ciudad Visitante";
                        usuarioInicial.PROVINCIA = "Provincia Visitante";
                        usuarioInicial.TELEFONO = "telefono";
                        usuarioInicial.PAIS = "Pais Visitante";
                        usuarioInicial.EMAIL = "visitante@ventasweb.com";
                        db.USUARIO.Add(usuarioInicial);
                        db.SaveChanges();
                        aux.USUARIO = db.USUARIO.Find(1);
                    }
                    //carro.IDCARRITO = id;
                    db.CARRITOCOMPRA.Add(aux);
                    db.SaveChanges();
                }

            }

        }
    }
}
