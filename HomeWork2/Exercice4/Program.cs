using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Дано 2 масиви розмірності M і N відповідно. 
//Необхідно переписати до третього масиву загальні елементи 
//перших двох масивів без повторень.Практичне завдання

namespace Exercice4
{
    internal class Program
    { 
        static int[] arraysConcatenation(int[] a, int[] b)
        {
            HashSet<int> numsSet = new HashSet<int>();
            foreach (var num in a)
                numsSet.Add(num);
            foreach (var num in b)
                numsSet.Add(num);

            return numsSet.ToArray();
        }

        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 2, 5 };
            int[] b = { 1, 3, 4, 6, 7 };

            int[] c = arraysConcatenation(a, b);

            foreach (var num in c)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
    }
}
