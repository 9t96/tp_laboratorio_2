using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Extranjero, Argentino };

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;


        #region Constructores
        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad GET & SET de apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return _apellido;
            }

            set
            {
                _apellido = this.ValidarNombre(value);
            }
        }
        /// <summary>
        /// Propiedad GET & SET de nombre.
        /// </summary>
        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = this.ValidarNombre(value);
            }
        }
        /// <summary>
        /// Propiedad GET & SET de dni que valida el DNI.
        /// </summary>
        public int DNI
        {
            get
            {
                return _dni;
            }

            set
            {
                _dni = this.ValidarDni(this._nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad SET de dni que valida la cadena.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                _dni = this.ValidarDni(this.Nacionalidad, value);              
            }
        }
        /// <summary>
        /// Propiedad GET & SET de Nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return _nacionalidad;

            }

            set
            {
                _nacionalidad = value;
            }
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Hace publicos los datos de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("NOMBRE COMPLETO: "+this.Apellido+", "+this.Nombre);
            str.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return str.ToString();
        }
        /// <summary>
        /// Valida que la nacionalidad se corresponada con el DNI.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dato < 1 || dato > 89999999)
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                        else
                            return dato;

                    case ENacionalidad.Extranjero:
                        if (dato < 90000000)
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                        else
                            return dato;

                    default:
                        return dato;
                }

        }
        /// <summary>
        /// Verifica que la cadena contenga solo numero caso contrario la excepcion DniInvalidoException.
        /// Si contiene caracteres validos convierte la cadena en un entero y la valida nuevamente.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>El dni valido y parseado, '0' si no cotiene caracteres validos.</returns>
        private int ValidarDni(Persona.ENacionalidad nacionalidad, string dato)
        {
            int valido;

            if (dato != null && int.TryParse(dato, out valido))
                return this.ValidarDni(nacionalidad,valido);

            throw new DniInvalidoException("El DNI no es valido");

        }
        /// <summary>
        /// Valida que la cadena tenga caracteres validos.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Retorna la cadena si contiene caracteres validos, caso contrario una cadena vacia.</returns>
        private string ValidarNombre(string dato)
        {
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))
                return dato;
            else
                return "";
        }
        #endregion

    }
}
