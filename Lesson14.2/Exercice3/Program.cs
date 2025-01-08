using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;


//Завдання 3:
//Додайте до масиву з першого завдання нову функціональність:
// Відобразіть статистику входження кожного числа до
//масиву. Наприклад: 7 – 3 рази, 5 – 2 рази, 8 – 4 рази і т. д.
// Відобразіть статистику входження парних чисел у масив.
//Наприклад: 2 – 4 рази, 6 – 2 рази і т. д.
// Відобразіть статистику входження парних і непарних чисел
//до масиву. Наприклад: парні – 3 рази, непарні – 2 рази.

namespace Exercice3
{
    internal class Program
    {
        class Element<T> where T : struct
        {
            public Element(T key, int count)
            {
                Key = key;
                Count = count;
            }
            public T Key { get; set; }
            public int Count { get; set; }

            public override string ToString()
            {
                return $"{Key} : {Count} times";
            }
        }

        static void Print<T>(IEnumerable<T> lst)
        {
            foreach (var n in lst) Console.Write("{0} ", n);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] a = new int[] { 18, 7777, 311, 4, 5, 18, 5, 1, 1 };

            var nums = from n in a.Distinct()
                        select new {
                            Key = n, 
                            Count = a.Count(x => x == n)
                        };

            Print(nums);

            var even_nums = from n in a.Distinct()
                            where n % 2 == 0
                            select new
                            {
                                Key = n,
                                Count = a.Count(x => x == n)
                            };
            Print(even_nums);

            var nums_types = from couple in (
                                from n in a
                                group n by n % 2 == 0)
                             select new
                             {
                                 key = (couple.First() % 2 == 0 ? "even nums" : "odd nums"),
                                 count = couple.Count()
                             };

            Print(nums_types);

            Console.ReadLine();
        }
    }
}
