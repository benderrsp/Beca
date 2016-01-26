using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carga
{
    public class LectorCsv
    {

        string path;
        char separador;
        List<String> columnas = new List<string>();
        List<List<string>> lineas = new List<List<string>>();


        public int Count
        {
            get
            {
                return lineas.Count;
            }
        }

        public LectorCsv(string path, char separador)
        {
            this.path = path;
            this.separador = separador;
        }


        public List<String> this[int numeroLinea]
        {
            get
            {
                if (numeroLinea < lineas.Count)
                {
                    return lineas[numeroLinea];
                }
                return null;
            }
        }

        public String this[int index, string nombreColumna]
        {
            get
            {
                if (index >= lineas.Count) return null;

                int indiceColumna = columnas.IndexOf(nombreColumna.ToLower());

                if (indiceColumna < 0) return null;

                return lineas[index][indiceColumna].Replace("'","''");

            }
        }

        public void ProcesaFichero()
        {
            String linea;
            string[] elementos;
            List<string> lista;

            try
            {
                StreamReader fichero = File.OpenText(path);

                linea = fichero.ReadLine();

                ProcesaCabeceras(linea);

                while ((linea = fichero.ReadLine()) != null)
                {
                    elementos = linea.Split(separador);
                    lista = new List<string>();

                    foreach (string elemento in elementos)
                    {
                        lista.Add(elemento);
                    }

                    lineas.Add(lista);
                }

                fichero.Close();
            }
            catch (Exception ex)
            {
                //TODO hacer algo cuando se produce una excepcion al leer el fichero
                throw ex;
            }
        }

        protected void ProcesaCabeceras(string lineaCabeceras)
        {
            string[] cabeceras = lineaCabeceras.Split(separador);

            foreach (string cabecera in cabeceras)
            {
                columnas.Add(cabecera.ToLower());
            }
        }



    }
}

