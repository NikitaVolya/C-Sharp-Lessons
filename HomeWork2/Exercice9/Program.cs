using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 9
//Створіть додаток для підрахунку кількості входжень
//підрядка в рядок. Користувач вводить вихідний рядок і
//слово для пошуку. Додаток відображає результат пошуку.
//Наприклад:
//користувач ввів: Why she had to go. I don't know, she
//wouldn't say;
//підрядок для пошуку: she;
//результат пошуку: 2.

namespace Exercice9
{
    internal class Program
    {
        static int countWord(string line, string word)
        {
            line = line.ToLower();
            word = word.ToLower();

            int count = 0;
            string[] words = line.Split(' ').ToArray();

            foreach (var item in words)
                if (word == item)
                    count++;

            return count;
        }

        static void Main(string[] args)
        {
            Console.Write("Text: ");
            string line = Console.ReadLine();
            Console.WriteLine(countWord(line, "she"));
            Console.ReadKey();
        }
    }
}
