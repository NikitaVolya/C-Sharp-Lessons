using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть додатки для виконання арифметичних опе-
//рацій. Підтримувані операції:
//■ Перевірка числа на парність;
//■ Перевірка числа на непарність;
//■ Перевірка на просте число;
//■ Перевірка на число Фібоначчі.
//Обов’язково використовуйте делегат типу Predicate.

namespace Exercice3
{
    public delegate bool MathTestDelegate(int number);

    class MathTest
    {
        public static bool IsEven(int number) { return number % 2 == 0; }
        public static bool IsOdd(int number) { return number % 2 != 0; }
        public static bool IsPrimne(int number) {
            bool[] numbers = new bool[number];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = true;

            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i])
                {
                    if (number % i == 0)
                        return false;
                    for (int j = i; j < numbers.Length; j += i)
                        numbers[j] = false;
                }
            }
            return true;
        }
        public static bool isFib(int number)
        {
            int a = 1;
            int b = 1;
            while (a < number)
            {
                int tmp = b;
                b = a + b;
                a = tmp;
            }
            return a == number;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 13;
            MathTestDelegate del = new MathTestDelegate(MathTest.IsEven);
            del += MathTest.IsOdd;
            del += MathTest.IsPrimne;
            del += MathTest.isFib;

            foreach (MathTestDelegate test in del.GetInvocationList())
                Console.WriteLine("Test: " + test.GetMethodInfo() + " = " + test(number));

            Console.ReadLine();
        }
    }
}
