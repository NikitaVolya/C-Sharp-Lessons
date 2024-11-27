using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 4
//Створіть лямбда-вираз для перевірки, чи є заданий
//день днем програміста (день програміста — 256 день року).
//Напишіть код для тестування роботи лямбди

namespace Exercice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day1 = 113;
            int day2 = 256;
            Func<int, bool> func = (int value) => value == 256;

            if (func(day1))
                Console.WriteLine("Day 1 is fete day");
            else
                Console.WriteLine("Day 1 is not fete day");
            if (func(day2))
                Console.WriteLine("Day 2 is fete day");
            else
                Console.WriteLine("Day 2 is not fete day");
            Console.ReadLine();
        }
    }
}
