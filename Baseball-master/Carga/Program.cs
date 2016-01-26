using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carga
{
    class Program
    {
        static void Main(string[] args)
        {
            //CargaEquipos();
            CargaJugadores();
            CargaApariciones();
            CargaSalarios();
        }

        private static void CargaSalarios()
        {
            string sql;

            LectorCsv lector = new LectorCsv(@"D:\Trabajo\lahman-csv_2015-01-24\Salaries.csv", ',');
            lector.ProcesaFichero();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString);
            conn.Open();

            SqlCommand comando;

            comando = conn.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "delete from Salaries;";
            comando.ExecuteNonQuery();

            StreamWriter log = File.CreateText("SalaryLog.txt");

            for (int i = 0; i < lector.Count; i++)
            {
                sql = "insert into Salaries values(";
                sql += lector[i, "YearId"].ToSqlNumber();
                sql += "," + lector[i, "TeamId"].ToSqlString();
                sql += "," + lector[i, "LgId"].ToSqlString();
                sql += "," + lector[i, "PlayerId"].ToSqlString();
                sql += "," + lector[i, "Salary"].ToSqlNumber();
                sql += ")";

                comando = conn.CreateCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    log.WriteLine("*** Error en" + i.ToString());
                    log.WriteLine(sql);
                }
            }

            conn.Close();
            conn.Dispose();
        }

        private static void CargaApariciones()
        {
            string sql;

            LectorCsv lector = new LectorCsv(@"D:\Trabajo\lahman-csv_2015-01-24\Appearances.csv", ',');
            lector.ProcesaFichero();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString);
            conn.Open();

            SqlCommand comando;

            comando = conn.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "delete from Appearances;";
            comando.ExecuteNonQuery();

            StreamWriter log = File.CreateText("AppearancesLog.txt");

            for (int i = 0; i < lector.Count; i++)
            {
                sql = "insert into Appearances values(";
                sql += lector[i, "YearId"].ToSqlNumber();
                sql += "," + lector[i, "TeamId"].ToSqlString();
                sql += "," + lector[i, "LgId"].ToSqlString();
                sql += "," + lector[i, "PlayerId"].ToSqlString();
                sql += "," + lector[i, "G_all"].ToSqlNumber();
                sql += "," + lector[i, "GS"].ToSqlNumber();
                sql += "," + lector[i, "G_batting"].ToSqlNumber();
                sql += "," + lector[i, "G_defense"].ToSqlNumber();
                sql += "," + lector[i, "G_p"].ToSqlNumber();
                sql += "," + lector[i, "G_c"].ToSqlNumber();
                sql += "," + lector[i, "G_1b"].ToSqlNumber();
                sql += "," + lector[i, "G_2b"].ToSqlNumber();
                sql += "," + lector[i, "G_3b"].ToSqlNumber();
                sql += "," + lector[i, "G_ss"].ToSqlNumber();
                sql += "," + lector[i, "G_lf"].ToSqlNumber();
                sql += "," + lector[i, "G_cf"].ToSqlNumber();
                sql += "," + lector[i, "G_rf"].ToSqlNumber();
                sql += "," + lector[i, "G_of"].ToSqlNumber();
                sql += "," + lector[i, "G_dh"].ToSqlNumber();
                sql += "," + lector[i, "G_ph"].ToSqlNumber();
                sql += "," + lector[i, "G_pr"].ToSqlNumber();
                sql += ")";

                comando = conn.CreateCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    log.WriteLine("*** Error en" + i.ToString());
                    log.WriteLine(sql);
                }
            }

            conn.Close();
            conn.Dispose();
        }

        private static void CargaJugadores()
        {
            string sql, aux;

            LectorCsv lector = new LectorCsv(@"D:\Trabajo\lahman-csv_2015-01-24\Master.csv", ',');
            lector.ProcesaFichero();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString);
            conn.Open();

            SqlCommand comando;

            comando = conn.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "delete from Master;";
            comando.ExecuteNonQuery();

            StreamWriter log = File.CreateText("MasterLog.txt");

            for (int i = 0; i < lector.Count; i++)
            {
                sql = "insert into Master values(";
                sql += lector[i, "playerID"].ToSqlString();
                sql += "," + lector[i, "bithyear"].ToSqlNumber();
                sql += "," + lector[i, "birthmonth"].ToSqlNumber();
                sql += "," + lector[i, "birthday"].ToSqlNumber();
                sql += "," + lector[i, "birthCountry"].ToSqlString();
                aux = lector[i, "birthState"];
                aux = aux.Length > 2 ? aux.Substring(0, 2) : aux;
                sql += "," + aux.ToSqlString();
                sql += "," + lector[i, "birthCity"].ToSqlString();
                sql += "," + lector[i, "deathYear"].ToSqlNumber();
                sql += "," + lector[i, "deathMonth"].ToSqlNumber();
                sql += "," + lector[i, "deathDay"].ToSqlNumber();
                sql += "," + lector[i, "deathCountry"].ToSqlString();
                aux = lector[i, "deathState"];
                aux = aux.Length > 2 ? aux.Substring(0, 2) : aux;
                sql += "," + aux.ToSqlString();
                sql += "," + lector[i, "deathCity"].ToSqlString();
                sql += "," + lector[i, "nameFirst"].ToSqlString();
                sql += "," + lector[i, "nameLast"].ToSqlString();
                sql += "," + lector[i, "nameGiven"].ToSqlString();
                sql += "," + lector[i, "weight"].ToSqlNumber();
                sql += "," + lector[i, "height"].ToSqlNumber();
                sql += "," + lector[i, "bats"].ToSqlString();
                sql += "," + lector[i, "throws"].ToSqlString();
                sql += "," + lector[i, "debut"].ToSqlDate();
                sql += "," + lector[i, "finalGame"].ToSqlDate();
                sql += "," + lector[i, "retroID"].ToSqlString();
                sql += "," + lector[i, "bbrefID"].ToSqlString();
                sql += ")";

                comando = conn.CreateCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    log.WriteLine("*** Error en" + i.ToString());
                    log.WriteLine(sql);
                }
            }

            conn.Close();
            conn.Dispose();
        }

        private static void CargaEquipos()
        {
            string sql;

            LectorCsv lector = new LectorCsv(@"D:\Trabajo\lahman-csv_2015-01-24\Teams.csv", ',');
            lector.ProcesaFichero();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseBall"].ConnectionString);
            conn.Open();

            SqlCommand comando;

            comando = conn.CreateCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "delete from teams;";
            comando.ExecuteNonQuery();

            StreamWriter log = File.CreateText("TeamLog.txt");

            for (int i = 0; i < lector.Count; i++)
            {
                sql = "insert into teams values(";
                sql += lector[i, "yearID"];
                sql += ",'" + lector[i, "lgID"] + "'";
                sql += ",'" + lector[i, "teamID"] + "'";
                sql += ",'" + lector[i, "franchID"] + "'";
                sql += ",'" + lector[i, "divID"] + "'";
                sql += "," + lector[i, "Rank"].ToSqlNumber();
                sql += "," + lector[i, "G"].ToSqlNumber();
                sql += "," + lector[i, "Ghome"].ToSqlNumber();
                sql += "," + lector[i, "W"].ToSqlNumber();
                sql += "," + lector[i, "L"].ToSqlNumber();
                sql += ",'" + lector[i, "DivWin"] + "'";
                sql += ",'" + lector[i, "WCWin"] + "'";
                sql += ",'" + lector[i, "LgWin"] + "'";
                sql += ",'" + lector[i, "WSWin"] + "'";
                sql += "," + lector[i, "R"].ToSqlNumber();
                sql += "," + lector[i, "AB"].ToSqlNumber();
                sql += "," + lector[i, "H"].ToSqlNumber();
                sql += "," + lector[i, "2B"].ToSqlNumber();
                sql += "," + lector[i, "3B"].ToSqlNumber();
                sql += "," + lector[i, "HR"].ToSqlNumber();
                sql += "," + lector[i, "BB"].ToSqlNumber();
                sql += "," + lector[i, "SO"].ToSqlNumber();
                sql += "," + lector[i, "SB"].ToSqlNumber();
                sql += "," + lector[i, "CS"].ToSqlNumber();
                sql += "," + lector[i, "HBP"].ToSqlNumber();
                sql += "," + lector[i, "SF"].ToSqlNumber();
                sql += "," + lector[i, "RA"].ToSqlNumber();
                sql += "," + lector[i, "ER"].ToSqlNumber();
                sql += "," + lector[i, "ERA"].ToSqlNumber();
                sql += "," + lector[i, "CG"].ToSqlNumber();
                sql += "," + lector[i, "SHO"].ToSqlNumber();
                sql += "," + lector[i, "SV"].ToSqlNumber();
                sql += "," + lector[i, "IPouts"].ToSqlNumber();
                sql += "," + lector[i, "HA"].ToSqlNumber();
                sql += "," + lector[i, "HRA"].ToSqlNumber();
                sql += "," + lector[i, "BBA"].ToSqlNumber();
                sql += "," + lector[i, "SOA"].ToSqlNumber();
                sql += "," + lector[i, "E"].ToSqlNumber();
                sql += "," + lector[i, "DP"].ToSqlNumber();
                sql += "," + lector[i, "FP"].ToSqlNumber();
                sql += ",'" + lector[i, "name"] +"'";
                sql += ",'" + lector[i, "park"] +"'";
                sql += "," + lector[i, "attendance"].ToSqlNumber();
                sql += "," + lector[i, "BPF"].ToSqlNumber();
                sql += "," + lector[i, "PPF"].ToSqlNumber();
                sql += ",'" + lector[i, "teamIDBR"]+"'";
                sql += ",'" + lector[i, "teamIDlahman45"] + "'";
                sql += ",'" + lector[i, "teamIDretro"] + "'";
                sql += ")";

                comando = conn.CreateCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    log.WriteLine("*** Error en" + i.ToString());
                    log.WriteLine(sql);
                }
            }

            conn.Close();
            conn.Dispose();
        }
    }
}
