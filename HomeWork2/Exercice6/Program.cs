using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Користувач вводить речення з клавіатури. Вам необ-
//    хідно підрахувати кількість слів у ньому.

namespace Exercice6
{
    internal class Program
    {
        static int countWords(string text)
        {
            int i = 0;
            int count = 0;
            bool isWord = false;

            while (i < text.Length)
            {
                if (!isWord && text[i] != ' ')
                {
                    count++;
                    isWord = true;
                }
                else if (text[i] == ' ')
                {
                    isWord = false;
                }
                i++;
            }

            return count;
        }

        static void Main(string[] args)
        {
            Console.Write("Text: ");
            string line = Console.ReadLine();
            Console.WriteLine("Words: " + countWords(line));
            Console.ReadKey();
        }
    }
}
