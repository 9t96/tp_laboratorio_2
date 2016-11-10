using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio:Persona
    {

        private int _indentificador;

        #region Contructor
        public PersonaGimnasio()
        {

        }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this._indentificador = id;
        }
        #endregion

        #region Sobrecargas
        public override bool Equals(object obj)
        {
            return this == (PersonaGimnasio)obj;
        }
        /// <summary>
        /// Dos PersonaGimnasio serán distintas si difieren en su Tipo, DNI o ID.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>TRUE si son distintas, FALSE si no lo son.</returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Dos PersonaGimnasio serán iguales si y sólo si son del mismo Tipo y su Id o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>TRUE si son iguales, FALSE si no lo son.</returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return (pg1.GetType() == pg2.GetType() && (pg1._indentificador == pg2._indentificador || pg1.DNI == pg2.DNI));

        }
        #endregion

        #region Metodos
        protected virtual string MostrarDatos()
        {
            StringBuilder str = new StringBuilder();

            str.Append(base.ToString());
            str.AppendLine("CARNET NÚMERO: " + this._indentificador);

            return str.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion
    }
}
