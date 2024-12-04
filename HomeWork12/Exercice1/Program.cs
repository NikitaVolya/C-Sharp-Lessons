using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Створіть generic-версію методу обчислення макси-
//муму з трьох чисел

namespace Exercice1
{
    public class Func<T> where T : IComparable<T>
    {
        static public T Max(T a, T b) => (a.CompareTo(b) > 0 ? a : b);
        static public T Max(T a, T b, T c) => Max(a, Max(b, c));
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Func<int>.Max(7, 5, 4));

            Console.ReadLine();
        }
    }
}
