using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 5
//Створіть лямбда-вираз для пошуку максимуму в ма-
//сиві. Напишіть код для тестування роботи лямбди.

namespace Exercice5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> findFunc = (int[] array) =>
            {
                int rep = array[0];
                for (int i = 1; i < array.Length; i++)
                    if (array[i] > rep)
                        rep = array[i];
                return rep;
            };

            Console.WriteLine("[5, 3, 4, 7, 1, 9, 2] max is: " + findFunc(new int[] {5, 3, 4, 7, 1, 9, 2 }));
            Console.ReadKey();
        }
    }
}
