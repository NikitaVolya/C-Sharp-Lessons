using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 6
//Створіть лямбда-вираз для перевірки тексту на задане
//слово. Напишіть код для тестування роботи лямбди.

namespace Exercice6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> contain_word =
                (string text, string word) => text.Split(' ').Contains(word);

            Console.WriteLine(contain_word("Hello world", "world"));
            Console.WriteLine(contain_word("Hello world", "hello"));
            Console.ReadLine();
        }
    }
}
