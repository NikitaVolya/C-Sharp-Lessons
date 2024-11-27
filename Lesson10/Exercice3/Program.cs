using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть лямбда-вираз для підрахунку куба числа.
//Напишіть код для тестування роботи лямбди.

namespace Exercice3
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 3;
            Func<int, int> func = (int value) => value * value * value;
            Console.WriteLine("Cube of 3 = " + func(num));
            Console.ReadLine();
        }
    }
}
