using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Користувач з клавіатури вводить шестизначне число.
//Необхідно перевернути число і відобразити результат.
//Наприклад, якщо введено 341256, результат 652143.

namespace Exercice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input number: ");
            int userNumer = Convert.ToInt32(Console.ReadLine());

            int rep = 0;
            while (userNumer > 0) { 
                rep = rep * 10 + userNumer % 10;
                userNumer /= 10;
            }

            Console.WriteLine(rep);
            Console.ReadLine();
        }
    }
}
