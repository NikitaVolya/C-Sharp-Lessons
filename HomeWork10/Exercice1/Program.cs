using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Створіть набір методів для роботи з масивами:
//■ Метод для отримання усіх парних чисел у масиві;
//■ Метод для отримання усіх непарних чисел у масиві;
//■ Метод для отримання усіх простих чисел у масиві;
//■ Метод для отримання усіх чисел Фібоначчі в масиві.
//Використовуйте механізми делегатів.

namespace Exercice1
{
    internal class Program
    {
        delegate int CountDelegate(int[] nums);
        class Count
        {
            static int CountNums(int[] nums, Func<int, bool> func)
            {
                int rep = 0;
                foreach (int x in nums)
                    if (func(x)) rep++;
                return rep;
            }
            public static int EvenNums(int[] nums) => CountNums(nums, x => x % 2 == 0);

            public static int OddNums(int[] nums) => CountNums(nums, x => x % 2 != 0);

            public static bool IsPrime(int num)
            {
                bool[] test = new bool[num];
                for (int i = 0; i < test.Length; i++)
                    test[i] = true;

                for (int i = 2; i < num; i++)
                {
                    if (test[i])
                    {
                        if (num % i == 0)
                            return false;
                        for (int j = i; j < test.Length; j += i)
                            test[j] = false;
                    }
                }
                return true;
            }

            public static int PrimeNums(int[] nums) => CountNums(nums, IsPrime);

            public static bool IsFib(int num)
            {
                int a = 1;
                int b = 1;
                while (a < num)
                {
                    int tmp = b;
                    b = a + b; 
                    a = tmp;
                }    
                return num == a;
            }

            public static int FibNums(int[] nums) => CountNums(nums, IsFib);
        }

        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            CountDelegate del = Count.EvenNums;
            del += Count.OddNums;
            del += Count.PrimeNums;
            del += Count.FibNums;

            foreach (CountDelegate tmpDel in del.GetInvocationList())
            {
                Console.WriteLine($"{tmpDel.GetMethodInfo()} : {tmpDel(nums)}");
            }
            Console.ReadLine();
        }
    }
}
