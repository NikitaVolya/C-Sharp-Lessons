using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 5
//Створіть лямбда-вираз для відображення унікальних,
//негативних чисел у масиві. Напишіть код для тестування
//роботи лямбди.

namespace Exercice5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 14, -5, -7, 21, -3, -3, -5 };
            Func<List<int>, int> unique_negative_numbers = (List<int> list) =>
            {
                HashSet<int> set = new HashSet<int>();

                foreach (int i in list)
                {
                    if (i < 0 && !set.Contains(i))
                        set.Add(i);
                }
                return set.Count;
            };
            Console.WriteLine(unique_negative_numbers(nums));
            Console.ReadLine();
        }
    }
}
