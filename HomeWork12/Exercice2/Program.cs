using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть generic-версію методу обчислення мінімуму
//з трьох чисел

namespace Exercice2
{
    public class Func<T> where T : IComparable<T>
    {
        static public T Min(T a, T b) => (a.CompareTo(b) < 0 ? a : b);
        static public T Min(T a, T b, T c) => Min(a, Min(b, c));
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Func<int>.Min(7, 5, 4));

            Console.ReadLine();
        }
    }
}
