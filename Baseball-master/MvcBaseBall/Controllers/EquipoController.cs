using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseBall.Modelos;

namespace MvcBaseBall.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult Index()
        {
            ViewBag.Year = "2014";

            ServicioEquipos.SrvEquiposClient Equipos = new ServicioEquipos.SrvEquiposClient();

            return View(Equipos.GetEquiposByYear(2014));
        }

        // Post: Equipo
        [HttpPost]
        public ActionResult Index(int year)
        {
            ViewBag.Year = year.ToString();

            ServicioEquipos.SrvEquiposClient Equipos = new ServicioEquipos.SrvEquiposClient();

            return View(Equipos.GetEquiposByYear(year));
        }

        
        public ActionResult Year(int id)
        {
            ViewBag.Year = id.ToString();

            ServicioEquipos.SrvEquiposClient Equipos = new ServicioEquipos.SrvEquiposClient();

            return View("Index",Equipos.GetEquiposByYear(id));
        }
        


        public ActionResult Jugadores(string equipo, int year)
        {
            ServicioEquipos.SrvEquiposClient equipos = new ServicioEquipos.SrvEquiposClient();
            List<Player> jugadores = equipos.GetJugadoresEquipoAño(equipo, year).ToList();
            return PartialView("_ListaJugadores", jugadores);
        }

        public ActionResult Jugador(string id)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            Player jugador = cliente.GetJugador(id);
            return PartialView("_Jugador", jugador);

        }
        public ActionResult Jugador(string id, int year, string equipo)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            Player jugador = cliente.GetJugador(id);
            return PartialView("_Jugador", jugador);
        }

        public ActionResult UpDate(Player jugador)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            cliente.RellenarJugador(jugador);
            return View("Index");
        }
    }
}