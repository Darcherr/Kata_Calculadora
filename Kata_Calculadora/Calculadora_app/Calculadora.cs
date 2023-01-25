using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_app
{
    public class Calculadora
    {
        public int Calcular(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            //var delimitadores = new List<char> { ',', '\n' };
            //delimitadores.Add(';');
            //delimitadores.Add(':');
            //delimitadores.Add(' ');
            //delimitadores.Add('|');

            // no deja agregar listas

            var numeros = input.Split(',', ';', ':', '|', ' ');

            var numerosInvalidos = numeros.Where(num => !int.TryParse(num, out int datoinservible))
                                          .Any();

            if (numerosInvalidos)
            {
                throw new ArgumentException("caracter/es no valido/s");
            }

            var numerosNegativos = numeros.Select(int.Parse)
                                          .Where(num => num < 0)
                                          .Any();

            if (numerosNegativos)
            {
                throw new ArgumentException("No se pueden utilizar numeros negativos");
            }




            return numeros.Select(int.Parse)
                          .Sum();

            //var numeros = input.Split(',');
            //int suma = 0;
            //foreach (var num in numeros)
            //{
            //    suma += int.Parse(num);
            //}
            //return suma;
        }
    }
}
