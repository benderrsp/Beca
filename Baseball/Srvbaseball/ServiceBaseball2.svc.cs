using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Modelo;
using System.Data.SqlClient;
using System.Data;

namespace Srvbaseball
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceBaseball2" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceBaseball2.svc o ServiceBaseball2.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceBaseball2 : IServiceBaseball2
    {
        //public static string conexion = Loguin.datosCon;
        public string conexion = "Server = BENDER\\SQLEXPRESS; Database = Baseball; User Id = sa;Password = NCSadmin";
        public void DoWork()
        {
        }

        public Jugador jugador(string IdJugador)
        {
            Jugador jugadorp = new Jugador();
            
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                SqlParameter añop = command.Parameters.AddWithValue("@id", IdJugador);
                command.CommandText = "SELECT        Master.*" +
                                      "FROM            Master " +
                                      "where Master.playerID=@id";
                conn.Open();
                SqlDataReader lector = lector = command.ExecuteReader();
                while (lector.Read())
                {
                    jugadorp.playerID = lector[0].ToString();
                    jugadorp.nameFirst= lector[13].ToString();

                }

            }
            return jugadorp;           
        }
        public void RellenarJugador(Jugador jugador)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                SqlParameter añop = command.Parameters.AddWithValue("@id", jugador.playerID);
                SqlParameter nameF = command.Parameters.AddWithValue("@nameFirst", jugador.nameFirst);
                command.CommandText = "UPDATE Master" +
                                      " Set nameFirst = @nameFirst" +
                                      ",nameLast = 'Rodriguez'" +
                                      "where playerID = @id;";
                conn.Open();
                command.ExecuteNonQuery();           
            }
        }
    }
}
