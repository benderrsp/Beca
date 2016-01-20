using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Modelo;

namespace Srvbaseball
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceBaseball" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceBaseball.svc or ServiceBaseball.svc.cs at the Solution Explorer and start debugging.
    public class ServiceBaseball : IServiceBaseball
    {
        public void DoWork()
        {
        }
        public static string conexion = "Server = BECA1\\SQLEXPRESS; Database = Baseball; User Id = sa;Password = NCSadmin";
        //public static string conexion = Loguin.datosCon;
        public int GetAñoInicio()
        {
            int año = 1995;         
            //string conexion = "Server = BENDER-PC\\SQLEXPRESS = Baseball; User Id = sa;Password = NCSadmin";
            using (SqlConnection conn = new SqlConnection(conexion))
            {                
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT MIN (yearID) FROM Teams";
                conn.Open();
                SqlDataReader lector = lector = command.ExecuteReader();
                while(lector.Read())
                { 
                año = Convert.ToInt16(lector[0]);
                }

            }
            return año;
            }
        public int GetAñoFin()
        {
            int año = 0;
            //string conexion = "Server = BENDER-PC\\SQLEXPRESS; Database = Baseball; User Id = sa;Password = NCSadmin";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT MAX (yearID) FROM Teams";
                conn.Open();
                SqlDataReader lector = lector = command.ExecuteReader();
                while (lector.Read())
                {
                    año = Convert.ToInt16(lector[0]);
                }

            }
            return año;
        }
        public List<Equipo> GetEquiposAño(int año)
        {
            List<Equipo> equipos = new List<Equipo>();
            //string conexion = "Server = BENDER-PC\\SQLEXPRESS; Database = Baseball; User Id = sa;Password = NCSadmin";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand command = conn.CreateCommand();
                SqlParameter añop = command.Parameters.AddWithValue("@año", año);
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT teamID, name, yearID " +
               "FROM Teams " +
               "WHERE yearID = @año";
                conn.Open();
                SqlDataReader lector = command.ExecuteReader();
                int cont = 0;

                while (lector.Read())
                {
                    //if (cont < 100)
                    //{
                    Equipo equipo = new Equipo();
                    equipo.teamID = lector[0].ToString();
                    equipo.name = lector[1].ToString();
                    equipo.yerID = Convert.ToInt16(lector[2]);
                    cont++;
                    //}
                    //else break;
                    equipos.Add(equipo);

                }
            }
            return equipos;
        }
       
        public List<Jugador> GetJugadoresEquipo(string equipo,int año)
        {
            List<Jugador> jugadores = new List<Jugador>();
            //string conexion = "Server = BENDER-PC\\SQLEXPRESS; Database = Baseball; User Id = sa;Password = NCSadmin";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand command = conn.CreateCommand();
                SqlParameter añop = command.Parameters.AddWithValue("@año",año);
                SqlParameter equipop = command.Parameters.AddWithValue("@equipo", equipo);
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT        Master.nameFirst AS Expr1, " +                
                "Appearances.playerID AS Expr2, " +
                "Appearances.teamID, " +
                "Appearances.yearID, " +
                "Master.nameFirst +' ' + Master.nameLast, " +
                "Master.* " +
                "FROM  Appearances INNER JOIN " +
                "Master ON Appearances.playerID = Master.playerID " +
                "where Appearances.teamID = @equipo AND Appearances.yearID = @año ";
                conn.Open();
                SqlDataReader lector = command.ExecuteReader();
                int cont = 0;

                while (lector.Read())
                {
                    //if (cont < 100)
                    //{
                    Jugador jugador = new Jugador();
                    jugador.nameFirst = lector[0].ToString();
                    jugador.playerID = lector[1].ToString();
                    jugador.NombreCompleto= lector[4].ToString();
                    jugadores.Add(jugador);
                    cont++;

                    //}
                    //else break;
                    //equipos.Add(cont.ToString());

                }
            }
            return jugadores;
        }

    }
}
