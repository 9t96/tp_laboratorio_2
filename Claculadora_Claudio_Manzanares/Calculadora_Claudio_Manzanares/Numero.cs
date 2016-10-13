using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Claudio_Manzanares
{
    public class Numero
    {
        private double _cantidad;
        /// <summary>
        /// Incializa numero en 0.
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Recibe un numero y lo asigna.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this._cantidad = numero;
        }
        /// <summary>
        /// Recibe una cadena, trata de convertirla en double y la asigna.
        /// </summary>
        /// <param name="stringNumero"></param>
        public Numero(string stringNumero)
        {

            double resultado;
            if (double.TryParse(stringNumero, out resultado))
            {
                this._cantidad = resultado;
            }
        }
        /// <summary>
        /// Retorna el numero
        /// </summary>
        /// <returns>Retorna el numero.</returns>
        public double GetNumero()
        {
            return this._cantidad;
        }
        /// <summary>
        /// Valida la cadena pasada y la asigna en _cantidad.
        /// </summary>
        /// <param name="numero">Cadena a validar que contenga un numero.</param>
        private void SetNumber(string numero)
        {
            this._cantidad = Numero.ValidarNumero(numero);
        }
        /// <summary>
        /// Valida que la cadena contenga un numero.
        /// </summary>
        /// <param name="numeroString">Cadena a validar</param>
        /// <returns>0 si no es numero valido y un double con el numero si lo es</returns>
        private static double ValidarNumero(string numeroString)
        {
            double resultado;
            if (double.TryParse(numeroString, out resultado))
            {
                return resultado;
            }

            return 0;
        }
 
        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1._cantidad + numero2._cantidad;
        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1._cantidad - numero2._cantidad;
        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1._cantidad * numero2._cantidad;
        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            return numero1._cantidad / numero2._cantidad;
        }


    }
}
