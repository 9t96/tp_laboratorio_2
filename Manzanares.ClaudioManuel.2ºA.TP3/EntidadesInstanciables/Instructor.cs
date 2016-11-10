using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public sealed class Instructor:PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public Instructor()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        static Instructor()
        {
            Instructor._random = new Random();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)           
        {
            _clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClase();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Hace publicos los datos del instructor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un instructor sera distinto de una EClase si no da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Un instructor sera igual a una EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            bool daEsaClase = false;

            foreach (Gimnasio.EClases item in i._clasesDelDia.ToList())
            {
                if (item == clase)
                    daEsaClase = true;
            }

            return daEsaClase;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Retorna uan cadena con las clases que el instructor dicta en el dia.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("CLASES DEL DIA ");
            foreach (Gimnasio.EClases item in _clasesDelDia)
            {
                str.AppendLine(item.ToString());
            }

            return str.ToString();
        }
        /// <summary>
        /// Retorna una cadena con los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.MostrarDatos());
            str.AppendLine(this.ParticiparEnClase());

            return str.ToString();
        }
        /// <summary>
        /// Asigna dos clase al azar al instructor.
        /// </summary>
        private void _randomClase()
        {
            for (int i = 0 ; i < 2; i++)
            {
                _clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
            }
        }
       #endregion

    }
}
