/*
Dado los números n y m, escritos por el usuarios, donde m no puede ser mayor que n. Debemos obtener y mostrar de la manera mas efectiva un array de todas las posibles combinaciones de un número binario de n dígitos en donde aparezcan m veces repetidas el 1.

Para ello podéis utilizar cualquier lenguaje de programación y recursividad (backtracking).

Como de referencia podéis inspiraros de las soluciones del desafío anterior Contador Binario(backtracking básico)

Ejemplo de entrada:
3
2

Ejemplo de salida:
011
101
110
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacktrackingBinarioMN
{
    class Program
    {
        static void Main(string[] args)
        {
            string n  = Console.ReadLine();
            

            while (!String.IsNullOrEmpty(n))
            {
                string m = Console.ReadLine();
                string result = "";

                DateTime time = DateTime.Now;

                BinaryCounter(int.Parse(n), int.Parse(m), result);

                Console.WriteLine(DateTime.Now - time);

                n = Console.ReadLine();
            }
        }

        private static void BinaryCounter(int n, int m, string result)
        {
            if (n == result.Length && result.Where(x => x == '1').Count() == m)
                Console.WriteLine(result);
            else if (result.Where(x => x == '1').Count() == m)
            {
                BinaryCounter(n, m, result + "0");
            }
            else if (result.Length < n && n - result.Length >=  m - result.Where(x => x == '1').Count())
            {
                BinaryCounter(n, m, result + "0");
                BinaryCounter(n, m, result + "1");
            }
        }
    }
}
