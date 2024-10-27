using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//Завдання 4
//Користувач вводить з клавіатури межі числового діапазону.
//Потрібно показати усі числа Фібоначчі з цього діапазону.
//Числа Фібоначчі — елементи числової послідовності,
//у якій перші два числа дорівнюють 0 і 1, а кожне
//наступне число дорівнює сумі двох попередніх чисел.
//Наприклад, якщо вказано діапазон 0–20, результат буде:
//0, 1, 1, 2, 3, 5, 8, 13.

namespace Exercice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter start of interval: ");
            int user_begin = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter end of interval: ");
            int user_end = Convert.ToInt32(Console.ReadLine());



            int a = 0;
            int b = 1;
            while (a <= user_end) {
                if (a >= user_begin)
                    Console.Write(a + ", ");

                int tmp = a + b;
                a = b;
                b = tmp;
            }

            Console.ReadLine();
        }
    }
}
