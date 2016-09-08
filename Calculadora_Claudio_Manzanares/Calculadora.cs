using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Claudio_Manzanares
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion pertinente segun el operador paso por string.
        /// </summary>
        /// <param name="numero1">Primer numero a ser operado.</param>
        /// <param name="numero2">Segundo a numero a ser operado.</param>
        /// <param name="operador">Cadena que contiene al operador deseado.</param>
        /// <returns>Resultado de la operacion.</returns>
        public double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado;

            if (numero2.GetNumero() != 0)
            {
                switch (this.validarOperador(operador))
                {
                    case "+":
                       return resultado = numero1 + numero2;
                    case "-":
                       return resultado = numero1 - numero2;
                    case "*":
                       return resultado = numero1 * numero2;
                    case "/":
                       return resultado = numero1 / numero2;
                }
            }

            return 0;
        }
        /// <summary>
        /// Valida que la cadena pasada contenga un operador valido.
        /// </summary>
        /// <param name="operador">Cadena que contiene operador a validar.</param>
        /// <returns>Retorna la misma cadena si contiene un operador valido de lo contrario retorna +.</returns>
        public string validarOperador(string operador)
        {
            if ((operador != "*") && (operador != "+") && (operador != "-") && (operador != "/"))
                return "+";
            return operador;
        }
    }
}
