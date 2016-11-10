using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta { MesPrueba, Deudor, AlDia }

        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Constructores
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;   
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }


        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un alumno sera distinto de una clase solo si no toma es a clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static  bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            return (a._claseQueToma != clase);
        }
        
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>TRUE si toma esa clase y no es deudo.FALSE si no lo es.</returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            return (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor);
        }
        
        /// <summary>
        /// Hace publicos los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Retorna una cadena con todos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();

            str.Append(base.MostrarDatos());
            str.AppendLine(this.ParticiparEnClase());
            str.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);

            return str.ToString();
        }
        /// <summary>
        /// Retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns>Una cadena junto con la clase que toma.</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }
        #endregion
    }

}
