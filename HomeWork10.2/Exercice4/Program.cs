using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 4
//Створіть лямбда-вираз для підрахунку кількості по-
//зитивних чисел в масиві. Напишіть код для тестування
//роботи лямбди.

namespace Exercice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 14, -5, -7, 21, -3 };
            Func<List<int>, int> poistive_numbers = (List<int> list) =>
            {
                int count = 0;
                foreach (int x in list)
                    if (x > 0) count++;
                return count;
            };
            Console.WriteLine(poistive_numbers(nums));
            Console.ReadLine();
        }
    }
}
