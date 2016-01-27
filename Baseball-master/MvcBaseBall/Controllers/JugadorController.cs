using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseBall.Modelos;

namespace MvcBaseBall.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index(string id)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            Player jugador = cliente.GetJugador(id);
            return View("JugadorForm", jugador);
           
        }
        public ActionResult Modificar(string id)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            Player jugador = cliente.GetJugador(id);
            return View("JugadorForm", jugador);
        }
        public ActionResult UpDate(Player jugador)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            cliente.RellenarJugador(jugador);
            return View("Exito");
        }
    }
}