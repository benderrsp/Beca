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
            ViewBag.jugadores=null;
            int year = 2014;
            if(HttpContext.Request.Params["year"]==null)
            { 
               ViewBag.Year = "2014";
                
            }
            else
            {
                string team = HttpContext.Request.Params["team"];
                year = Convert.ToInt32(HttpContext.Request.Params["year"]);
                ServicioEquipos.SrvEquiposClient Equiposs = new ServicioEquipos.SrvEquiposClient();
                ViewBag.jugadores = Equiposs.GetJugadoresEquipoAño(team, year);
                ViewBag.Year = year;
            }

            ServicioEquipos.SrvEquiposClient Equipos = new ServicioEquipos.SrvEquiposClient();
            
            return View(Equipos.GetEquiposByYear(year));
           
            
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
            ViewBag.jugadores = jugadores; 
            return PartialView("_ListaJugadores", jugadores);
        }

        public ActionResult Jugador(string id)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            Player jugador = cliente.GetJugador(id);
            return PartialView("_Jugador", jugador);

        }

        //Ésta es la sobrecarga de obtener jugador
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