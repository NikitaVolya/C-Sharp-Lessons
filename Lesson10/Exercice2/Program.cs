using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть анонімний метод для підрахунку квадрата
//числа. Напишіть код для тестування методу.

namespace Exercice2
{
    delegate int TestVelue(int value);
    class Dispacher
    {
        public event TestVelue Function;
        public int OnEvent(int value)
        {
            if (Function != null)
                return Function(value);
            throw new NullReferenceException();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Dispacher dispacher = new Dispacher();
            dispacher.Function += (int value) => value * value;
            int num = 12;
            Console.WriteLine($"Squer: {dispacher.OnEvent(num)}");
            Console.ReadLine();
        }
    }
}
