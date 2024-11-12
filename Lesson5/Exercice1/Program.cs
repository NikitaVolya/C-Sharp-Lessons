using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Створіть класи для створення парних чисел, непарних
//чисел, простих чисел, чисел Фібоначчі. Використовуйте
//механізми просторів імен.

using EvenNumbers;
using NotEvenNumbers;
using PrimeNumbers;

namespace Exercice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EvenNumbers.Number number1 = new EvenNumbers.Number(10);
            NotEvenNumbers.Number number2 = new NotEvenNumbers.Number(10);
            
            Console.WriteLine(number1);
            Console.WriteLine(number2);
            Console.WriteLine(PrimeNumbers.PrimeNumber.IsPrimeNumber(9857));

            Console.ReadLine();
        }
    }
}
