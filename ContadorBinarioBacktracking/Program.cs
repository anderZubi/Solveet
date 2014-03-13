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

                DateTime time = DateTime.Now;

                BinaryCounter(int.Parse(input), result);

                Console.WriteLine(DateTime.Now - time);

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
