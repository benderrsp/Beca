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
        
        public string conexion = "Server = BECA1\\SQLEXPRESS; Database = Baseball; User Id = sa;Password = NCSadmin";
        public void DoWork()
        {
        }

        public Jugador jugador(string IdJugador, int año, string Idequipo)
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
                SqlDataReader lector = command.ExecuteReader();
              
                while (lector.Read())
                {
                    jugadorp.playerID = lector[0].ToString();
                    jugadorp.birthYear = Convert.ToInt32(lector[1]);
                    jugadorp.birthMonth = Convert.ToInt32(lector[2]);
                    jugadorp.birthDay = Convert.ToInt32(lector[3]);
                    jugadorp.birthCountry= lector[4].ToString();
                    jugadorp.birthState = lector[5].ToString();
                    jugadorp.birthCity = lector[6].ToString();
                    jugadorp.deathYear = Convert.ToInt32(lector[7]);
                    jugadorp.deathMonth = Convert.ToInt32(lector[8]);
                    jugadorp.deathDay = Convert.ToInt32(lector[9]);
                    jugadorp.deathCountry = lector[10].ToString();
                    jugadorp.deathState = lector[11].ToString();
                    jugadorp.deathCity = lector[12].ToString();
                    jugadorp.nameFirst = lector[13].ToString();
                    jugadorp.nameLast = lector[14].ToString();
                    jugadorp.nameGiven = lector[15].ToString();
                    jugadorp.weight = Convert.ToInt32(lector[16]);
                    jugadorp.height = Convert.ToInt32(lector[17]);
                    jugadorp.bats = lector[18].ToString();
                    jugadorp.throws = lector[19].ToString();
                    jugadorp.debut = (DateTime) lector[20];
                    jugadorp.finalGame = (DateTime)lector[21];
                    jugadorp.retroID = lector[22].ToString();
                    jugadorp.bbrefID = lector[23].ToString();

                }
                lector.Close();
                command = conn.CreateCommand();
                SqlParameter idj = command.Parameters.AddWithValue("@idj", IdJugador);
                SqlParameter idaño = command.Parameters.AddWithValue("@idano", año);
                SqlParameter idteam = command.Parameters.AddWithValue("@idequipo", Idequipo);
                command.CommandText = "SELECT        salary " +
                                      "FROM            Salaries " +
                                      "where (playerID = @idj) AND (yearID = @idano) AND (teamID = @idequipo)";
                SqlDataReader lector2 = command.ExecuteReader();

                while (lector2.Read())
                {
                    jugadorp.salarie = lector2[0].ToString();
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
                SqlParameter idjugador = command.Parameters.AddWithValue("@id", jugador.playerID);
                SqlParameter nombrejugador = command.Parameters.AddWithValue("@nameFirst", jugador.nameFirst);
                SqlParameter apellidojugador = command.Parameters.AddWithValue("@nameLast", jugador.nameLast);
                SqlParameter apodo = command.Parameters.AddWithValue("@nameGiven", jugador.nameGiven);
                SqlParameter añonac = command.Parameters.AddWithValue("@birthYear", jugador.birthYear);
                SqlParameter mesnac = command.Parameters.AddWithValue("@birthMonth", jugador.birthMonth);
                SqlParameter dianac = command.Parameters.AddWithValue("@birthDay", jugador.birthDay);

                command.CommandText = "UPDATE Master" +
                                      " Set nameFirst = @nameFirst" +
                                      ",nameLast = @nameLast " +
                                      ",nameGiven= @nameGiven " +
                                      ",birthYear= @birthYear " +
                                      ",birthMonth= @birthMonth " +
                                      ",birthDay= @birthDay " +
                                      "where playerID = @id;";
                conn.Open();
                command.ExecuteNonQuery();           
            }
        }
    }
}
