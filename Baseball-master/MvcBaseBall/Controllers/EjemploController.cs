using BaseBall.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcBaseBall.Controllers
{
    public class EjemploController : ApiController
    {
        // GET: api/Ejemplo
        public IEnumerable<Player> Get(string equipo, int year)
        {
            ServicioEquipos.SrvEquiposClient equipos = new ServicioEquipos.SrvEquiposClient();
            List<Player> jugadores = equipos.GetJugadoresEquipoAño(equipo, year).ToList();
            return jugadores;
        }
        
    }
}
