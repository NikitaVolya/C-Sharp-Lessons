using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Користувач вводить з клавіатури п'ять чисел. Необхід-
//но знайти суму чисел, максимум і мінімум з п'яти чисел,
//добуток чисел. Результат обчислень вивести на екран.

namespace Exercice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Enter " + (i + 1) + " number: ");
                String tmp = Console.ReadLine();
                numbers[i] = Convert.ToInt32(tmp);
            }

            int minN = numbers[0];
            int maxN = numbers[0];
            int repMultiple = 1;
            int repSum = 0;
            for (int i = 0; i < numbers.Length; i++){
                minN = Math.Min(minN, numbers[i]);
                maxN = Math.Max(maxN, numbers[i]);
                repMultiple *= numbers[i];
                repSum += numbers[i];
            }

            Console.WriteLine("Min number: " + minN);
            Console.WriteLine("Max number: " + maxN);
            Console.WriteLine("Multiple number: " + repMultiple);
            Console.WriteLine("Sum number: " + repSum);
            Console.ReadLine();
        }
    }
}
