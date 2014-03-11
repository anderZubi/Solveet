using System;

namespace ContadorBinarioBacktracking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (!String.IsNullOrEmpty(input))
            {
                string result = "";
                BinaryCounter(int.Parse(input), result);

                input = Console.ReadLine();
            }
        }

        private static void BinaryCounter(int n, string result)
        {
            if (n == result.Length)
                Console.WriteLine(result);
            else
            {
                BinaryCounter(n, result + "0");
                BinaryCounter(n, result + "1");
            }
        }
    }
}
