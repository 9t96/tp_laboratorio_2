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

        public List<Alumno> alumnos
        {
            get
            {
                return this._alumnos;
            }

        }

        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }

        }

        public List<Jornada> Jornada
        {
            get
            {
                return this._jornada;
            }
        }
        #endregion

        #region Sobrecargas.


        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

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

        public static  Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g == i)
                throw new Exception("Instructor Repetido.");

            g._instructores.Add(i);
            return g;
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        #endregion

        #region Metodos
        private string MostrarDatos(Gimnasio gim)
        {
            StringBuilder str = new StringBuilder();

            foreach (Jornada item in gim.Jornada)
            {
                str.Append(item.ToString());
            }

            return str.ToString(); 
        }

        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            if (xml.guardar("Gimnasio.xml", gim))
            {

                return true;
            }

            return false;
        }

        public static bool Leer(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            Gimnasio aux;
            if (xml.leer("Gimnasio.xml", out aux))
            {
                Console.WriteLine(aux.ToString());
                return true;
            }

            return false;
        }
        #endregion

    }
}
