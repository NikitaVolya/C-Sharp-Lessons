using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Напишіть метод, який сортує масив за зменшенням
//або зростанням, залежно від вибору користувача.
//Алгоритм сортування реалізуйте самостійно. На-
//приклад, може бути реалізоване сортування методом
//перестановок.

namespace Exercice3
{
    internal class Program
    {
        static void printArray(int[] nums)
        {
            foreach (var num in nums)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static int[] arrayFilter(int[] nums, Func<int, int, bool> func, int value)
        {
            int count = 0;
            foreach (var num in nums)
                if (func(num, value))
                    count++;

            int[] rep = new int[count];
            int i = 0;
            foreach (var num in nums)
                if (func(num, value))
                    rep[i++] = num;
            return rep;
        }

        static void arrayRecSort(ref int[] nums, Func<int, int, bool> minNumsFunc, Func<int, int, bool> maxNumsFunc)
        {
            if (nums.Length == 0 || nums.Length == 1)
                return;

            
            int center = nums[0];
            nums = nums.Skip(1).ToArray();
            
            int[] min_num = arrayFilter(nums, minNumsFunc, center);
            int[] max_num = arrayFilter(nums, maxNumsFunc, center);

            arrayRecSort(ref min_num, minNumsFunc, maxNumsFunc);
            arrayRecSort(ref max_num, minNumsFunc, maxNumsFunc);

            nums = min_num.Append(center).Concat(max_num).ToArray();
        }

        static int[] arraySort(int[] nums)
        {
            Func<int, int, bool> minNumsFunc = (a, b) => a <= b;
            Func<int, int, bool> maxNumsFunc = (a, b) => a > b;

            arrayRecSort(ref nums, minNumsFunc, maxNumsFunc);
            return nums;
        }

        static int[] arrayReversSort(int[] nums)
        {
            Func<int, int, bool> minNumsFunc = (a, b) => a >= b;
            Func<int, int, bool> maxNumsFunc = (a, b) => a < b;

            arrayRecSort(ref nums, minNumsFunc, maxNumsFunc);
            return nums;
        }

        static void Main(string[] args)
        {
            int[] nums = { 5, 6, 4, 1, 2, 5, 3, 1, 4};
            nums = arraySort(nums);
            printArray(nums);
            nums = arrayReversSort(nums);
            printArray(nums);
            Console.ReadKey();
        }
    }
}
