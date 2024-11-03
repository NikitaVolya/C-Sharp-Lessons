using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//Користувач вводить з клавіатури три числа.
//Необхідно підрахувати кількість разів послідовності цих трьох чисел в масиві. 
//Наприклад: користувач ввів: 7 6 5;
//масив: 7 6 5 3 4 7 6 5 8 7 6 5; 
//кількість повторень послідовності: 3.

namespace Exercice3
{
    internal class Program
    {
        static bool checkArrays(int[] a, int[] b, int slice)
        {
            int j = 0;
            for (; j + slice < a.Length && j < b.Length; j++)
            {
                if (a[j + slice] != b[j])
                    return false;
            }
            return j == b.Length;
        }

        static int findInArray(int[] a, int[] b)
        {
            int rep = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (checkArrays(a, b, i))
                    rep++;
            }

            return rep;
        }

        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 5, 2, 3, 1, 5 };
            int[] test = new int[] { 2, 3, 5};
            Console.WriteLine(findInArray(array, test));
            Console.ReadKey();
        }
    }
}
