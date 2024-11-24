using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть додаток для виконання арифметичних опе-
//рацій. Підтримувані операції:
//■ Додавання двох чисел;
//■ Віднімання двох чисел;
//■ Множення двох чисел.
//Код програми обов’язково має використати механізм
//делегатів.

namespace Exercice2
{
    public delegate float MathDeleggate(float a,  float b);

    class MathFunctions
    {
        public static float Add(float a, float b) { return a + b; }
        public static float Sub(float a, float b) { return a - b; }
        public static float Mult(float a, float b) { return a * b; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            float a = 2;
            float b = 3.5f;
            MathDeleggate math_del = new MathDeleggate(MathFunctions.Add);
            Console.WriteLine($"Math add: {a}, {b} = {math_del(a, b)}");
            math_del = MathFunctions.Sub;
            Console.WriteLine($"Math sub: {a}, {b} = {math_del(a, b)}");
            math_del = MathFunctions.Mult;
            Console.WriteLine($"Math mult: {a}, {b} = {math_del(a, b)}");
            Console.ReadLine();
        }
    }
}
