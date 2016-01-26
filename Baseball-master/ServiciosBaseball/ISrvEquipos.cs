using BaseBall.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosBaseball
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISrvEquipos" in both code and config file together.
    [ServiceContract]
    public interface ISrvEquipos
    {
        [OperationContract]
        int GetAñoInicial();
        [OperationContract]
        int GetAñoFinal();
        [OperationContract]
        List<Equipo> GetEquiposByYear(int year);
        [OperationContract]
        List<Player> GetJugadoresEquipoAño(string idTeam, int year);
        [OperationContract]
        Player GetJugador(string id);
    }
}
