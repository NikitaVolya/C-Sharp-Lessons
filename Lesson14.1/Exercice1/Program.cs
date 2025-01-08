using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1:
//Для масиву цілих реалізуйте наступні запити:
// Отримати весь масив цілих.
// Отримати парні цілі.
// Отримати непарні цілі.
// Отримати значення більше заданого.
// Отримати числа в заданому діапазоні.
// Отримати числа, кратні семи. Результат відсортуйте за
//зростанням.
// Отримати числа, кратні восьми. Результат відсортуйте за
//спаданням.

namespace Exercice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 15, 6, 14, 7, 8, 9, 0, 4, 2, 11};


            var all_nums = from num in nums 
                           select num;
            foreach (var num in all_nums) Console.Write("{0}, ", num);
            Console.WriteLine();


            var even_nums = from num in nums
                            where num % 2 == 0
                            select num;
            foreach (var num in even_nums) Console.Write("{0}, ", num);
            Console.WriteLine();


            var odd_nums = from num in nums
                           where num % 2 != 0
                           select num;
            foreach (var num in odd_nums) Console.Write("{0}, ", num);
            Console.WriteLine();


            int x = 7;
            var more_numbers = from num in nums
                               where x < num
                               select num;
            foreach (var num in more_numbers) Console.Write("{0}, ", num);
            Console.WriteLine();


            int start = 3;
            int end = 8;
            var interval = from num in nums
                           where start < num && num < end
                           select num;
            foreach (var num in interval) Console.Write("{0}, ", num);
            Console.WriteLine();


            var multiples_of_7 = from num in nums.OrderBy(num => num)
                                 where num % 7 == 0
                                 select num;
            foreach (var num in multiples_of_7) Console.Write("{0}, ", num);
            Console.WriteLine();


            var multiples_of_8 = from num in nums.OrderBy(num => -num)
                                 where num % 8 == 0
                                 select num;
            foreach (var num in multiples_of_8) Console.Write("{0}, ", num);
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
