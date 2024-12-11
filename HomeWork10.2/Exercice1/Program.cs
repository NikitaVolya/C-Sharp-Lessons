using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Створіть анонімний метод для отримання RGB зна-
//чення для кольору веселки. Колір веселки передається як
//параметр. Напишіть код для тестування методу.

namespace Exercice1
{
    internal class Program
    {
        delegate string RGBmethod(int r, int g, int b);
        static event RGBmethod rgb_method;

        static void Main(string[] args)
        {
            rgb_method = (int r, int g, int b) =>
            {
                switch (r * 1000000 + g * 1000 + b)
                {
                    case 255000000:
                        return "red";
                    case 255000:
                        return "green";
                    case 255:
                        return "blue";
                    case 255000255:
                        return "fuchsia";
                    case 255255:
                        return "cyan";
                    default:
                        return "Indefine";
                }
            };

            Console.WriteLine(rgb_method(255, 0, 0));
            Console.WriteLine(rgb_method(255, 0, 255));
            Console.ReadLine();
        }
    }
}
