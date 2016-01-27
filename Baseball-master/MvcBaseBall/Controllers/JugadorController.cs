using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBaseBall.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index(string id)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            
            return View("_Jugador", cliente.GetJugador(id));
        }
    }
}