using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть generic-версію методу пошуку суми елемен-
//тів у масиві.

namespace Exercice3
{
    class Func<T>
    {
        public static T Sum(T a, T b)
        {
            if (typeof(T) == typeof(int))
                return (T)(object)((int)(object)a + (int)(object)b);
            if (typeof(T) == typeof(float))
                return (T)(object)((float)(object)a + (float)(object)b);
            if (typeof(T) == typeof(double))
                return (T)(object)((double)(object)a + (double)(object)b);
            if (typeof(T) == typeof(string))
                return (T)(object)((string)(object)a + (string)(object)b);
            throw new Exception();
        }
        public static T Sum(T[] array)
        {
            T rep = array[0];
            for (int i = 1; i < array.Length; i++)
                rep = Func<T>.Sum(rep, array[i]);
            return rep;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Func<int>.Sum(new int[] { 2, 3, 4}));
            Console.Read();
        }
    }
}
