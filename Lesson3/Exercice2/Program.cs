using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Напишіть метод, який перевіряє чи є число числом
//Фібоначчі. Число передається як параметр. Якщо число
//просте, потрібно повернути з методу true, інакше — false.

namespace Exercice2
{
    internal class Program
    {
        static bool isNotFib(int n)
        {
            int a = 0;
            int b = 1;
            while (a < n)
            {
                int tmp = a + b;
                a = b;
                b = tmp;
            }
            return n != a;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("5 is number of fib: " + (isNotFib(5) ? "not" : "yes"));
            Console.WriteLine("11 is number of fib: " + (isNotFib(11) ? "not" : "yes"));
            Console.ReadKey();
        }
    }
}
