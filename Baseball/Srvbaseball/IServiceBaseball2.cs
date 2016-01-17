using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Modelo;

namespace Srvbaseball
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceBaseball2" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceBaseball2
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        Jugador jugador(string IdJugador);
        [OperationContract]
        void RellenarJugador(Jugador jugador);
    }
}
