using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        string ruta;
        
        /// <summary>
        /// Asigana la ruta del archivo.
        /// </summary>
        /// <param name="ruta"></param>
        public Texto(string ruta)
        {
            this.ruta = ruta;
        }

        /// <summary>
        /// Guarda los datos pasados por parametro en un archivo de texto.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            bool succed = false;

            try
            {
                using (StreamWriter escritor = new StreamWriter(ruta,true))
                {
                    escritor.WriteLine(datos);
                    succed = true;
                }
            }
            catch (Exception e)
            {
                succed = false;
                throw e;
            }

            return succed;
        }

        /// <summary>
        /// Lee los datos y los guarda en una lista generica de string.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            bool succed = false;
            datos = new List<string>();

            try
            {
                using (StreamReader lector = new StreamReader(ruta))
                {
                    while (!lector.EndOfStream)
                    {
                        datos.Add(lector.ReadLine());
                    }

                    succed = true;
                }
            }
            catch (Exception)
            {
                succed = false;
                datos = default(List<string>);
            }

            return succed;
        }
    }
}
