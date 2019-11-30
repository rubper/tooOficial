using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using Too.Models;

namespace Too
{
    /// <summary>
    /// Descripción breve de ServicioCarrito
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioCarrito : System.Web.Services.WebService
    {
        contextoBaseVentas db = new contextoBaseVentas();

        [WebMethod]
        public void ObtenerTarifa(decimal i)
        {
            List<TARIFAENVIO> lsTarifa = db.TARIFAENVIO.Where(m => m.IDTARIFA == i).ToList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(lsTarifa));
        }
    }
}
