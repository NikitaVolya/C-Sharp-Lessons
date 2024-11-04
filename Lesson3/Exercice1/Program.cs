using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Напишіть метод, який повертає добуток чисел у вказа-
//ному діапазоні. Межі діапазону передаються як параметри.

namespace Exercice1
{
    internal class Program
    {

        static int multipleInterval(int start, int end)
        {
            int rep = 1;

            for (int i = start; i <= end; i++)
                rep *= i;

            return rep;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("2 * 3 * 4 = " + multipleInterval(2, 4));
            Console.ReadKey();
        }
    }
}
