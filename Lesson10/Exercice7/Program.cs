using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 7
//Створіть лямбда-вираз для пошуку непарних чисел
//в масиві. Напишіть код для тестування роботи лямбди.

namespace Exercice7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> func = (int[] array) =>
            {
                List<int> list = new List<int>();
                for (int i = 0; i < array.Length; i++)
                    if (array[i] % 2 != 0)
                        list.Add(array[i]);
                return list.ToArray();
            };

            Console.WriteLine("[5, 3, 4, 7, 1, 9, 2] odds are: ");
            int[] nums = func(new int[] { 5, 1, 3, 6, 5, 8, 12, 11 });
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
