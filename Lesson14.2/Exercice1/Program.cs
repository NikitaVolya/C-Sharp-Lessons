using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

//Завдання 1:
//Для масиву цілих виконайте наступні завдання з використанням
//агрегатних операцій з LINQ:
// Розрахуйте добуток елементів масиву.
// Розрахуйте кількість елементів масиву.
// Розрахуйте кількість елементів масиву, кратних 9.
// Розрахуйте кількість елементів масиву, кратних 7 і більших, ніж 945.
// Розрахуйте суму елементів масиву.
// Розрахуйте суму парних елементів масиву.
// Знайдіть мінімум в масиві.
// Знайдіть максимум в масиві.
// Знайдіть середнє значення в масиві.

namespace Exercice1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] a = new int[] { 1, 7777, 311, 4, 5, 9, 18, 3743 };

            // Розрахуйте добуток елементів масиву.
            int mult_a = (from n in a
                        select n).Aggregate((x, y) => x * y);

            // Розрахуйте кількість елементів масиву.
            int a_count = (from n in a select n).Count();

            // Розрахуйте кількість елементів масиву, кратних 9.
            int a_multiples_of_9 = (from n in a
                                    where n % 9 == 0
                                    select n).Count();

            // Розрахуйте кількість елементів масиву, кратних 7 і більших, ніж 945.
            int a_multiples_of_7 = (from n in a
                                    where n % 7 == 0 && n > 945
                                    select n).Count();

            // Розрахуйте суму елементів масиву.
            int a_sum = (from n in a  select n).Sum();

            // Розрахуйте суму парних елементів масиву.
            int a_even_sum = (from n in a
                              where n % 2 == 0
                              select n).Count();

            // Знайдіть мінімум в масиві.
            int a_min = (from n in a select n).Min();

            // Знайдіть максимум в масиві.
            int a_max = (from n in a select n).Max();

            // Знайдіть середнє значення в масиві.
            double a_avg = (from n in a select n).Average();

            Console.ReadKey();
        }
    }
}
