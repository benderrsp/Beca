using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carga
{
    public static class Extensiones
    {
        public static string ToSqlNumber(this string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
            {
                return "NULL";
            }

            return cadena;
        }

        public static string ToSqlString(this string cadena)
        {
            return "'" + cadena + "'";
        }

        public static string ToSqlDate(this string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
            {
                return "NULL";
            }

            DateTime fecha;
            if (DateTime.TryParse(cadena,out fecha))
            {
                return "'" + fecha.ToString("yyyyMMdd") + "'";
            }

            return cadena;
        }
    }
}
