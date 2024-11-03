using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 7
//Користувач вводить речення з клавіатури. Вам необхід-
//но перевернути кожне слово речення і вивести результат
//на екрані.
//Наприклад:
//користувач ввів: sun cat dogs cup tea;
//після перевороту: nus tac sgod puc aet.

namespace Exercice7
{
    internal class Program
    {
        static string reverseString(string str)
        {
            string rep = "";
            foreach (var item in str)
            {
                rep =  item + rep;
            }
            return rep;
        }

        static string reversWords(string line)
        {
            string[] words = line.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = reverseString(words[i]);
            }

            return String.Join(" ", words);
        }

        static void Main(string[] args)
        {
            Console.Write("Text: ");
            string line = Console.ReadLine();
            Console.WriteLine(reversWords(line));
            Console.ReadLine();
        }
    }
}
