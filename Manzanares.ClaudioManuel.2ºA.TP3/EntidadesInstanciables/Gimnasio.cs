using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;
using EntidadesAbstractas;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]

    public class Gimnasio
    {
        public enum EClases { CrossFit, Natacion, Pilates, Yoga }

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        #region Constructores

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Indexador de jornada.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Jornada especificada.</returns>
        public Jornada this[int index]
        {
            get
            {
                if (index < this._jornada.Count || index > this._jornada.Count)
                    return this._jornada[index];
                else
                    return null;
            }
        }
        /// <summary>
        /// Propiedad get que permite serializar.
        /// </summary>
        public List<Alumno> alumnos
        {
            get
            {
                return this._alumnos;
            }

        }
        /// <summary>
        /// Propiedad get que permite serializar.
        /// </summary>
        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }

        }
        /// <summary>
        /// Propiedad get que permite serializar.
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this._jornada;
            }
        }
        #endregion

        #region Sobrecargas.

        /// <summary>
        /// Un Gimnasio será igual a un Alumno si el mismo no está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un Gimnasio será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
            {
                foreach (Alumno item in g._alumnos)
                {
                    if (item == a)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// retornará el primer Instructor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio g, EClases e)
        {
            Instructor noDaEsaClse = null;

            foreach (Instructor item in g.Instructores)
            {
                if (item != e)
                     noDaEsaClse = item;
            }

            return noDaEsaClse;
        }
        /// <summary>
        ///  retornará el primer instructor capaz de dar esa clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio g, EClases e)
        {
            if (!Object.ReferenceEquals(g, null))
            {
                foreach (Instructor item in g._instructores)
                {
                    if (item == e)
                    {
                        return item;
                    }
                }
            }
            throw new SinInstructorException();
        }
        /// <summary>
        /// Un Gimnasio será igual a un Instructor si el mismo no está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Un Gimnasio será igual a un Instructor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool daClase = false;

            foreach (Instructor item in g.Instructores)
            {              
                if (item == i)
                   return daClase = true;
            }

            return daClase;
        }

        /// <summary>
        /// Agrega un alumno al gimnasio.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static  Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (!Object.ReferenceEquals(g, null) && !Object.ReferenceEquals(a, null))
            {
                if (g != a)
                {
                    g._alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            else
                throw new NullReferenceException();
            return g;
        }
        /// <summary>
        /// Crea una nueva jornada con la clas especificada, el primer profesor capaz de dictarla y la lista de alumnos que que participen de la misma.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static  Gimnasio operator +(Gimnasio g, EClases e)
        {
            if (!Object.ReferenceEquals(g, null))
            {
                switch (e)
                {
                    case Gimnasio.EClases.CrossFit:
                        Jornada aux = new Jornada(e, g == e);
                        foreach (Alumno item in g._alumnos)
                        {
                            if (item == e)
                            {
                                aux += item;
                            }
                        }
                        g._jornada.Add(aux);
                        return g;
                    case Gimnasio.EClases.Natacion:
                        Jornada aux2 = new Jornada(e, g == e);
                        foreach (Alumno item in g._alumnos)
                        {
                            if (item == e)
                            {
                                aux2 += item;
                            }
                        }
                        g._jornada.Add(aux2);
                        return g;
                    case Gimnasio.EClases.Pilates:
                        Jornada aux3 = new Jornada(e, g == e);
                        foreach (Alumno item in g._alumnos)
                        {
                            if (item == e)
                            {
                                aux3 += item;
                            }
                        }
                        g._jornada.Add(aux3);
                        return g;
                    case Gimnasio.EClases.Yoga:
                        Jornada aux4 = new Jornada(e, g == e);
                        foreach (Alumno item in g._alumnos)
                        {
                            if (item == e)
                            {
                                aux4 += item;
                            }
                        }
                        g._jornada.Add(aux4);
                        return g;
                }
            }
            return null;
        }
        /// <summary>
        /// Agrega un instructor al gimnasio.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static  Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g == i)
                throw new Exception("Instructor Repetido.");

            g._instructores.Add(i);
            return g;
        }
        /// <summary>
        /// Hace publicos los datos el gimnasio.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve una cadena que contiene todos los datos del gimnasio.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private string MostrarDatos(Gimnasio gim)
        {
            StringBuilder str = new StringBuilder();

            foreach (Jornada item in gim.Jornada)
            {
                str.Append(item.ToString());
            }

            return str.ToString(); 
        }
        /// <summary>
        /// Guarda el gimnasio pasado por parametro en un archivo xml.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            string archivo = "gimnasio.xml";

            Xml<Gimnasio> serializador = new Xml<Gimnasio>();
            serializador.guardar(archivo, gim);

            return true;
        }
        /// <summary>
        /// Lee el gimnasio pasador por parametro de un xml.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static Gimnasio Leer()
        {
            Gimnasio auxGimnasio = null;
            string archivo = "gimnasio.xml";

            Xml<Gimnasio> deserializador = new Xml<Gimnasio>();
            deserializador.leer(archivo, out auxGimnasio);

            return auxGimnasio;
        }
        #endregion

    }
}
