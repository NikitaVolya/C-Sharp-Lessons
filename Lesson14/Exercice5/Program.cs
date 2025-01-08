using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 5:
//Додаток надає користувачеві можливість пошуку по файлу:
// Пошук заданого слова. Додаток показує, чи знайдено слово.
//Крім того, відображається інформація про те, де знайдено
//збіг.
// Пошук кількості входження слова у файл. Додаток
//відображає кількість знайденого слова.
// Пошук заданого слова у зворотному порядку. Наприклад,
//користувач шукає слово «moon». Це означає, що додаток
//шукає слово «moon» у зворотному напрямку: «noom». За
//результатами пошуку, додаток відображає кількість
//входжень.

namespace Exercice5
{
    internal class Program
    {
        static string[] LoadFormFile(string filepatch)
        {
            string[] rep;
            try
            {
                using (FileStream fs = new FileStream(filepatch, FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string data = sr.ReadToEnd();
                    rep = data.Split(new char[] { '\r', '\n', '\t', ' ', '.' });
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                rep = new string[0];
            }

            return rep;
        }

        static int[] Find(string[] values, string key)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == key)
                    result.Add(i);
            }
            return result.ToArray();
        }

        static string Reverse(string s)
        {
            string rep = "";
            foreach (char  c in s)
                rep = c + rep;
            return rep;
        }

        static int[] FintRevers(string[] values, string key) => Find(values, Reverse(key));

        static void Main(string[] args)
        {
            string[] words = LoadFormFile("text.txt");
            int[] finded_word = Find(words, "sit");

            Console.Write($"Word sit found {finded_word.Length} times in positions: ");
            foreach (int index in finded_word) 
                Console.Write(index + " ");
            Console.WriteLine();

            int[] finded_reverse_word = FintRevers(words, "sit");
            Console.Write($"Word tis found {finded_reverse_word.Length} times in positions: ");
            foreach (int index in finded_reverse_word)
                Console.Write(index + " ");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
