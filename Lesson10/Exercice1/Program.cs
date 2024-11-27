using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Створіть анонімний метод перевірки числа на пар-
//ність. Напишіть код для тестування методу.

namespace Exercice1
{
    delegate bool TestVelue(int value);
    class Dispacher
    {
        public event TestVelue TestEvent;
        public bool OnEvent(int value)
        {
            if (TestEvent != null)
                return TestEvent(value);
            throw new NullReferenceException();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dispacher dispacher = new Dispacher();
            dispacher.TestEvent += (int a) => a % 2 == 0;
            int num = 3;
            if (dispacher.OnEvent(num))
                Console.WriteLine("Is even");
            else
                Console.WriteLine("Is odd");
            Console.ReadKey();
        }
    }
}
