using System;
using System.Collections.Generic;
using System.Linq;

namespace Divisores
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (!String.IsNullOrEmpty(input))
            {
                int value;
                List<int> result; ;

                if (int.TryParse(input, out value) && value > 0)
                {
                    result = Divisores(int.Parse(input));
                    Console.WriteLine(String.Join(",", result.OrderBy(x => x)));
                }
                else
                    Console.WriteLine("Por favor, inserta un número de tipo entero y mayor que 0.");

                input = Console.ReadLine();
            }
        }

        private static List<int> Divisores(int p)
        {
            List<int> result = new List<int>();
            int max = p;

            for (int i = 1; i < max; i++)
            {
                if (p % i == 0)
                {
                    int div = p / i;
                    result.Add(i);
                    result.Add(div);
                    max = div;
                }
            }

            return result;
        }
    }
}
