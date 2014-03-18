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

                count = 0;

                DateTime time = DateTime.Now;

                BinaryCounter(int.Parse(n), int.Parse(m), result);

                Console.WriteLine(DateTime.Now - time);

                Console.WriteLine("BinaryCounter calls: " + count.ToString());

                n = Console.ReadLine();
            }
        }

        static int count = 0;

        private static void BinaryCounter(int n, int m, string result)
        {
            count++;

            if (n == 0)
            {
                Console.WriteLine(result);
            }
            else if (m == 0)
            {
                BinaryCounter(n - 1, m, result + "0");
            }
            else if (m > 0 && m == n)
            {
                
                BinaryCounter(n - 1, m - 1, result + "1");
            }
            else if (m > 0 && m < n)
            {
                BinaryCounter(n - 1, m, result + "0");
                BinaryCounter(n - 1, m - 1, result + "1");
            }
        }
    }
}
