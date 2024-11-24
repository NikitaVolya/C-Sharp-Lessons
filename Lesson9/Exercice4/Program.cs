using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 4
//Реалізуйте додаток із другого практичного завдання
//за допомогою виклику Invoke.

namespace Exercice4
{
    public delegate float MathDeleggate(float a, float b);

    class MathFunctions
    {
        public static float Add(float a, float b) { 
            Console.WriteLine(a + " + " + b + " = " + (a + b));
            return a + b; 
        }
        public static float Sub(float a, float b)
        {
            Console.WriteLine(a + " - " + b + " = " + (a - b));
            return a - b;
        }
        public static float Mult(float a, float b)
        {
            Console.WriteLine(a + " * " + b + " = " + (a * b));
            return a * b;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            float a = 2;
            float b = 3.5f;
            MathDeleggate math_del = new MathDeleggate(MathFunctions.Add);
            math_del += MathFunctions.Sub;
            math_del += MathFunctions.Mult;

            math_del.Invoke(a, b);

            Console.ReadLine();
        }
    }
}
