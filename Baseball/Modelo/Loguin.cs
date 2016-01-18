using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public static class Loguin
    {
        public static string datosCon;
        public static void conexion(string server, string name, string user,string pass)
        {
            //"Server = BENDER-PC\\SQLEXPRESS; Database = Baseball; User Id = sa;Password = NCSadmin";
            datosCon = "Server = " + server + "; Database = " + name + "; User Id = " + user + ";Password = " + pass + ";";
        }
    }
}
