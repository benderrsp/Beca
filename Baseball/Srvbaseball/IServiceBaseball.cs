using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Modelo;

namespace Srvbaseball
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceBaseball" in both code and config file together.
    [ServiceContract]
    public interface IServiceBaseball
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        int GetAñoInicio();
        [OperationContract]
        int GetAñoFin();
        [OperationContract]
        List<Equipo> GetEquiposAño(int año);
        [OperationContract]
        List<Jugador> GetJugadoresEquipo(string equipo,int año);
    }
}
