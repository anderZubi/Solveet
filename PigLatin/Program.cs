/*
Descripción
  
El pig latin es un juego con el idioma inglés. Buenos días en pig latin se dice 'oodgay
orningmay'. El pig latin lo usan los niños para divertirse o para conversar secretamente sobre adultos u otros niños. Recíprocamente, los adultos a veces lo usan para hablar de temas sensibles que quieren que los niños no entiendan.
Los turistas anglohablantes a veces usan el pig latin para disimular sus
conversaciones cuando viajan por países donde el inglés es el segundo idioma.

Reglas simplificadas de conversión de inglés a Pig Latin
  
• La traducción se hace palabra a palabra.
• Si una palabra no comienza con una letra se deja igual.
• Para las palabras que comienzan con consonantes, se mueven todas las
consonantes antes de la primera vocal al final y se agrega la sílaba "ay".
• Para palabras que comienzan con vocal (incluyendo la y), simplemente se
agrega "yay" al final de la palabra.
 
Ejemplos
 
mess → essmay
father → atherfay
Rwanda → Andarway
choir → oirchay
ant → antyay
 
Se pide:
  
Escribe un programa en python que pida frases en inglés por teclado y las traduzca a Pig Latin.
Se debe tener en cuenta:
• La traducción de la frase se hace palabra a palabra.
• Se deben respetar todos los signos de puntuación.
• Se deben respetar las mayúsculas (si una palabra empieza con
mayúscula su traducción también debe empezar con mayúscula).
• El programa se ejecutará hasta que se introduzca una cadena vacía.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // Do while input is not an empty string
            while (!String.IsNullOrEmpty(input))
            {
                // Split the phrase.
                List<string> phrase = input.Split(' ').ToList();

                // For each word in a line, convert it to Pig Latin
                for (int i = 0; i < phrase.Count(); i++)
                {
                    phrase[i] = Modify(phrase[i]);
                }

                // Return the phrase
                Console.WriteLine(String.Join(" ", phrase));

                input = Console.ReadLine();
            }
        }

        private static string Modify(string word)
        {
            // If the first character is not a letter return the word
            if (!IsLetter(word[0]))
                return word;

            // else

            int index = 0;
            string prefix = "";
            string suffix = "";

            // Iterate while until a vowel is find, to extract the suffix
            while (!IsVowel(word[index]))
            {
                suffix += word[index];
                index++;
            }

            // The rest of the word will be the prefix
            prefix = word.Substring(index);

            // If word startet with consonant, append "ay". Else, append "yay"
            if (index > 0)
                suffix += "ay";
            else
                suffix += "yay";

            // If word ends with a punctuation sign, move it from the prefix to the suffix.
            if (!IsLetter(prefix.Last()))
            {
                char punctuation = prefix[prefix.Length - 1];
                prefix = prefix.Remove(prefix.Length - 1);
                suffix += punctuation;
            }

            // If words starts with capital letter, make the prefix capital.
            if (IsCapital(word[0]))
            {
                var arr = prefix.ToCharArray();
                arr[0] = Char.ToUpperInvariant(arr[0]);
                prefix = new string(arr);
                suffix = suffix.ToLowerInvariant();
            }

            // Append suffix to the prefix to return resultant word
            return prefix + suffix;
        }

        private static bool IsLetter(char p)
        {
            return Regex.IsMatch(p.ToString(), "[a-zA-Z]");
        }

        private static bool IsCapital(char p)
        {
            return Regex.IsMatch(p.ToString(), "[A-Z]");
        }

        private static bool IsVowel(char p)
        {
            return "aeiouyAEIOUY".Contains(p);
        }
    }
}
