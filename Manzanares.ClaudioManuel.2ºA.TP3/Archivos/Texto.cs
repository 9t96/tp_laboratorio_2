using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en archivo de texto la cadena pasa en la ruta especificada.
        /// </summary>
        /// <param name="archivo">Ruta donde se guardara el archivo.</param>
        /// <param name="dato">Datos a guardar en el archivo.</param>
        /// <returns></returns>
        public bool guardar(string archivo, string dato)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.WriteLine(dato);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Lee los dato de un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta de la archivo.</param>
        /// <param name="dato">Lugar donde se almacenaran los datos del archivo.</param>
        /// <returns></returns>
        public bool leer(string archivo, out string dato)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    dato = sr.ReadToEnd();
                }
                return true;
            }
            catch (Exception e)
            {
                dato = "";
                throw new ArchivosException(e);
            }
        }
    }
}
