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
