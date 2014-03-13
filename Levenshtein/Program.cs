/*
 
 Se llama Distancia de Levenshtein, distancia de edición, o distancia entre palabras, al número mínimo de operaciones 
 requeridas para transformar una cadena de caracteres en otra. Se entiende por operación, bien una inserción, eliminación 
 o la sustitución de un carácter. Esta distancia recibe ese nombre en honor al científico ruso Vladimir Levenshtein, 
 quien se ocupara de esta distancia en 1965. Es útil en programas que determinan cuán similares son dos cadenas de caracteres, 
 como es el caso de los correctores de ortografía.

Por ejemplo:
'casa' y 'cosa' difieren en 1.
'caza' y 'cazar' difieren en 1.
'cazador' y 'cazar' difieren en 2.
'potable' y 'portable' difieren en 1.
 
 */

using System;
using System.Linq;

namespace Levenshtein
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (!String.IsNullOrEmpty(input))
            {
                string[] words = input.Split(' ');
                var time1 = DateTime.Now;
                Console.WriteLine("Recursive:");
                Console.WriteLine(Levenshtein(words[0], words[1]));
                var time2 = DateTime.Now;
                Console.WriteLine(time2-time1);
                Console.WriteLine("Iterative:");
                Console.WriteLine(LevenshteinIterative(words[0], words[1]));
                Console.WriteLine(DateTime.Now - time2);

                input = Console.ReadLine();
            }
        }

        private static int Levenshtein(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0) // Special case, if either of the two strings is empty, return the lenth of the longest
            {
                return Math.Max(s1.Length, s2.Length);
            }
            else // Else, return the Min of possible recursive solutions of substrings
            {
                int[] solutions = new int[3];

                solutions[0] = Levenshtein(s1.Remove(0, 1), s2) + 1;
                solutions[1] = Levenshtein(s1, s2.Remove(0, 1)) + 1;
                if (s1[0] == s2[0])
                    solutions[2] = Levenshtein(s1.Remove(0, 1), s2.Remove(0, 1));
                else
                    solutions[2] = Levenshtein(s1.Remove(0, 1), s2.Remove(0, 1)) + 1;

                return solutions.Min();
            }
        }

        private static int LevenshteinIterative(string s, string t)
        {
            // degenerate cases
            if (s == t) return 0;
            if (s.Length == 0) return t.Length;
            if (t.Length == 0) return s.Length;

            // create two work vectors of integer distances
            int[] v0 = new int[t.Length + 1];
            int[] v1 = new int[t.Length + 1];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
                v0[i] = i;

            for (int i = 0; i < s.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < t.Length; j++)
                {
                    var cost = (s[i] == t[j]) ? 0 : 1;
                    var arr = new int[3] { v1[j] + 1, v0[j + 1] + 1, v0[j] + cost };
                    v1[j + 1] = arr.Min();
                }

                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }

            return v1[t.Length];
        }

    }
}
