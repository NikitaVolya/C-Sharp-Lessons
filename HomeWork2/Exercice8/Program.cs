using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 8
//Користувач вводить з клавіатури речення. Додаток має
//підрахувати кількість голосних літер у реченні.

namespace Exercice8
{
    internal class Program
    {
        static int vowelsNumber(string line)
        {
            int count = 0;

            foreach (var ch in line)
            {
                switch (ch)
                {
                    case 'a': case 'e':
                    case 'u': case 'o':
                    case 'i':
                        count++;
                        break;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            Console.Write("Text: ");
            string line = Console.ReadLine();
            Console.WriteLine("Vowels number: " + vowelsNumber(line));
            Console.ReadKey();
        }
    }
}
