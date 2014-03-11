using System;
using System.Collections.Generic;

namespace FactoresPrimos
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
                    result = FactoresPrimos(int.Parse(input));
                    Console.WriteLine(String.Join(",", result));
                }
                else
                    Console.WriteLine("Por favor, inserta un número de tipo entero y mayor que 0.");

                input = Console.ReadLine();
            }
        }

        private static List<int> FactoresPrimos(int p)
        {
            List<int> result = new List<int>();
            if (p == 1)
                result.Add(p);
            else
            {           
                while (p>1)
                {
                    int div = 2;

                    while (p % div != 0)
                        div++;

                    p = p / div;
                    result.Add(div);
                }
            }

            return result;                
        }
    }
}
