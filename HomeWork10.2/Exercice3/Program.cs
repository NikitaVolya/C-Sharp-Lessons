using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть лямбда-вираз для підрахунку кількості чи-
//сел у масиві, кратних семи. Напишіть код для тестування
//роботи лямбди

namespace Exercice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>{14, 5, 7, 21, 3 };
            Func<List<int>, int> even_to_7 = (List<int> list) =>
            {
                int count = 0;
                foreach (int x in list)
                    if (x % 7 == 0) count++;
                return count;
            };
            Console.WriteLine(even_to_7(nums));
            Console.ReadLine();
        }
    }
}
