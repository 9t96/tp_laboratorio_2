using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa los datos pasados por parametro con el nombre de ruta especificado.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>TRUE si serializo correctamente, FALSE  si no lo hizo.</returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(escritor, datos);
                    escritor.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }
        /// <summary>
        /// Lee un archivo Xml en la ruta especificada.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>TRUE si la lectura fue correcta, FALSE si no lo fue.</returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(lector);
                    lector.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }
    }

}