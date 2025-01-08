using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2:
//Додайте до масиву з першого завдання нову функціональність:
// Відобразіть три перші максимальні елементи.
// Відобразіть три перші мінімальні елементи.
//Для реалізації завдання використовуйте сімейство методів Skip,
//Take.

namespace Exercice2
{
    internal class Program
    {
        static void Print<T>(IEnumerable<T> lst ) where T : struct
        {
            foreach (var n in lst) Console.Write("{0} ", n);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 7777, 311, 4, 5, 9, 18, 3743 };

            // Відобразіть три перші максимальні елементи.
            var min_nums_a = (from n in a 
                       orderby n
                       select n).Take(3);
            Print(min_nums_a);

            // Відобразіть три перші мінімальні елементи.
            var max_nums_a = (from n in a
                              orderby n descending
                              select n).Take(3);
            Print(max_nums_a);

            Console.ReadLine();
        }
    }
}
