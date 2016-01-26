using BaseBall.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosBaseball
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SrvEquipos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SrvEquipos.svc or SrvEquipos.svc.cs at the Solution Explorer and start debugging.
    public class SrvEquipos : ISrvEquipos
    {
        public int GetAñoFinal()
        {
            int año = 1900;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString))
            {
                conn.Open();
                SqlCommand comando = conn.CreateCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select max(yearid) from teams";

                año = (int)comando.ExecuteScalar();
                conn.Close();
            }

            return año;
        }

        public int GetAñoInicial()
        {
            int año = 1900;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString))
            {
                conn.Open();

                SqlCommand comando = conn.CreateCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select min(yearid) from teams";

                año = (int)comando.ExecuteScalar();

                conn.Close();
            }

            return año;
        }

        public List<Equipo> GetEquiposByYear(int year)
        {
            List<Equipo> equipos = new List<Equipo>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString))
            {
                Equipo equipo;

                conn.Open();

                SqlCommand comando = conn.CreateCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select teamID, name from dbo.Teams where yearid = " + year.ToString();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    equipo = new Equipo();
                    equipo.teamID = reader.GetString(0);
                    equipo.name = reader.GetString(1);

                    equipos.Add(equipo);
                }

                conn.Close();
            }

            return equipos;
        }

        public List<Player> GetJugadoresEquipoAño(string idTeam, int year)
        {
            List<Player> jugadores = new List<Player>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString))
            {
                Player jugador;

                conn.Open();

                SqlCommand comando = conn.CreateCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select m.playerID, m.nameGiven, m.nameFirst, m.nameLast from master as m join Appearances as a on m.playerID = a.playerID ";
                comando.CommandText += "where a.teamID='" + idTeam + "' ";
                comando.CommandText += "and a.yearID =" + year + " order by m.playerID;";

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    jugador = new Player();
                    jugador.PlayerId = reader.GetString(0);
                    jugador.NameGiven = reader.GetString(1);
                    jugador.NameFirst = reader.GetString(2);
                    jugador.NameLast = reader.GetString(3);

                    jugadores.Add(jugador);
                }

                conn.Close();
            }

            return jugadores;
        }
        public Player GetJugador(string id)
        {
            Player jugador = new Player();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString))
            {
                SqlCommand command = conn.CreateCommand();
                SqlParameter idjug = command.Parameters.AddWithValue("@id", id);

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT        Master.* " +
                                       "FROM Master " +
                                       "WHERE playerID=@id";
                conn.Open();
                SqlDataReader lector = command.ExecuteReader();


                while (lector.Read())
                {


                    jugador.PlayerId = lector[0].ToString();
                    jugador.NameFirst = lector[13].ToString();
                    jugador.NameLast= lector[14].ToString();


                }
            }
            return jugador;
        }
    }
}
