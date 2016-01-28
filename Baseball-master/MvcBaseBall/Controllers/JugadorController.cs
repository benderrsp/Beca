using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseBall.Modelos;
using System.Web.Routing;

namespace MvcBaseBall.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index(string id)
        {
         
            return View();
           
        }

        [HttpGet]
        public ActionResult Modificar(string id, int year, string team)
        {
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            Player jugador = cliente.GetJugador(id);
            return View("JugadorForm", jugador);
        }

        [HttpPost]
        public ActionResult Modificar(Player jugador,int year, string team)
        {
            //HttpContext.Request.Params
            ServicioEquipos.SrvEquiposClient cliente = new ServicioEquipos.SrvEquiposClient();
            cliente.RellenarJugador(jugador);

            RouteValueDictionary routeData = new RouteValueDictionary();
            routeData.Add("year", year);
            routeData.Add("team", team);
            ViewBag.error = true;
            //return RedirectToAction("Index", "Equipo",routeData);
            return View("JugadorForm",jugador);
        }
    }
}