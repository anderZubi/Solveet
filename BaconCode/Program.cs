using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaconCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert secret word.");
            string word = Console.ReadLine();

            Console.WriteLine("Insert a phrase.");
            string phrase = Console.ReadLine();

            Console.WriteLine(Baconify(word, phrase));

            Console.ReadLine();
        }

        private static string Baconify(string word, string phrase)
        {
            Dictionary<char, string> baconDictionary = new Dictionary<char,string>(){
                {'a',"AAAAA"},{'b',"AAAAB"},{'c',"AAABA"},{'d',"AAABB"},{'e',"AABAA"},
                {'f',"AABAB"},{'g',"AABBA"},{'h',"AABBB"},{'i',"ABAAA"},{'j',"ABAAA"},
                {'k',"ABAAB"},{'l',"ABABA"},{'m',"ABABB"},{'n',"ABBAA"},{'o',"ABBAB"},
                {'p',"ABBBA"},{'q',"ABBBB"},{'r',"BAAAA"},{'s',"BAAAB"},{'t',"BAABA"},
                {'u',"BAABB"},{'v',"BAABB"},{'W',"BABAA"},{'x',"BABAB"},{'y',"BABBA"},
                {'z',"BABBB"}
            };

            StringBuilder sb = new StringBuilder();
            char[] result = new char[phrase.Length];
            int index = 0;

            foreach (char c in word)
            {
                sb.Append(baconDictionary[Char.ToLower(c)]);
            }

            for(int i = 0; i<phrase.Length; i++)
            {
                if (Regex.IsMatch(phrase[i].ToString(),"[a-zA-Z]"))
                {
                    if (index < sb.Length && sb[index] == 'B')
                        result[i] = Char.ToUpper(phrase[i]);
                    else
                        result[i] = Char.ToLower(phrase[i]);

                    index++;
                }
                else
                    result[i] = phrase[i];
            }

            return new string(result);
        }
    }
}
