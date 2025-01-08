using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Завдання 2:
//Для масиву рядків з назвою міст, реалізуйте наступні запити:
// Отримати весь масив міст.
// Отримати міста з довжиною назви, що дорівнює заданому.
// Отримати міста, назви яких починаються з літери A.
// Отримати міста, назви яких закінчуються літерою M.
// Отримати міста, назви яких починаються з літери N і
//закінчуються літерою K.
// Отримати міста, назви яких починаються з Ne. Результат
//відсортувати за спаданням.

namespace Exercice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cities = new string[] {
                "Kyiv",
                "Kharkiv",
                "Odesa",
                "Dniprom",
                "Lviv",
                "Zaporizhzhia",
                "Avdiivka",
                "Nemyriv",
                "Kryvyi Rih",
                "Mykolaiv",
                "Novhorod-Siversk",
                "Mariupol",
                "Vinnytsia",
                "Kherson",
                "Chernihiv",
                "Poltava",
                "Cherkasy",
                "Zhytomyr",
                "Nizhynk",
                "Sumy",
                "Rivne",
                "Ivano-Frankivsk" };

            var cities_list = from c in cities
                              select c;
            foreach (var c in cities_list) Console.Write("{0} ", c);
            Console.WriteLine();


            int length = 5;
            var cities_length = from c in cities
                                where c.Length == length
                                select c;
            foreach (var c in cities_length) Console.Write("{0} ", c);
            Console.WriteLine();


            var cities_start_with_a = from c in cities
                                      where c.ToLower()[0] == 'a'
                                      select c;
            foreach (var c in cities_start_with_a) Console.Write("{0} ", c);
            Console.WriteLine();


            var cities_start_with_m = from c in cities
                                      where c.ToLower()[c.Length - 1] == 'm'
                                      select c;
            foreach (var c in cities_start_with_m) Console.Write("{0} ", c);
            Console.WriteLine();


            var cities_n_to_t = from c in cities
                                where c.ToLower()[0] == 'n' && c.ToLower()[c.Length - 1] == 'k'
                                select c;
            foreach (var c in cities_n_to_t) Console.Write("{0} ", c);
            Console.WriteLine();


            var cities_ne = from c in cities.OrderBy(c => c)
                            where c.ToLower()[0] == 'n' && c.ToLower()[1] == 'e'
                            select c;
            foreach (var c in cities_ne) Console.Write("{0} ", c);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
