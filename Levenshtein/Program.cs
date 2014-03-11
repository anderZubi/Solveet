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

                Console.WriteLine(Levenshtein(words[0], words[1]));

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

    }
}
