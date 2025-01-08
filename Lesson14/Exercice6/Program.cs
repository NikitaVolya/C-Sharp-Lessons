using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

//Завдання 6:
//Користувач вводить шлях до файлу. Додаток відображає
//статистичну інформацію про файл:
// кількість речень;
// кількість великих літер;
// кількість маленьких літер;
// кількість голосних літер;
// кількість приголосних літер;
// кількість цифр.

namespace Exercice6
{
    internal class Program
    {
        static string LoadFormFile(string filepatch)
        {
            string rep;
            try
            {
                using (FileStream fs = new FileStream(filepatch, FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                {
                    rep = sr.ReadToEnd();
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                rep = "";
            }

            return rep;
        }

        static int Count(string text, Predicate<char> predicate)
        {
            int rep = 0;
            foreach (char c in text)
                if (predicate(c))
                    rep++;
            return rep;
        }

        static int Count(string[] texts, Predicate<string> predicate)
        {
            int rep = 0;
            foreach (string value in texts)
                if (predicate(value))
                    rep++;
            return rep;
        }

        static bool IsVowes(char c)
        {
            switch (c)
            {
                case 'a': case 'e': case 'i': 
                case 'o': case 'u': return true;
                    default: return false;
            }
        }

        static void Main(string[] args)
        {
            string filepatch = Console.ReadLine();
            string data = LoadFormFile(filepatch);

            Predicate<string> containeInt = (string s) =>
            {
                foreach (char c in s)
                    if (Char.IsDigit(c))
                        return true;
                return false;
            };

            Console.WriteLine("number of sentences: " + data.Split('.').Length);
            Console.WriteLine("number of upercase letters: " + Count(data, (c) => c >= 'A' && c <= 'Z'));
            Console.WriteLine("number of lowercase letters: " + Count(data, (c) => c >= 'a' && c <= 'z'));
            Console.WriteLine("the number of vowels: " + Count(data, IsVowes));
            Console.WriteLine("the number of consonant letters: " + Count(data, (c) => !IsVowes(c)));
            Console.WriteLine("the number of digits: " + Count(data.Split(new char[] { ' '}), containeInt));

            Console.ReadLine();
        }
    }
}
