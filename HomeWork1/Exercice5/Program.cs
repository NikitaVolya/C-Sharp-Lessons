using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 5
//Дано цілі додатні числа A і B (A < B). Вивести усі цілі
//числа від A до B включно; кожне число має виводитися у
//новому рядку; при цьому кожне число має виводитися у
//кількість разів, рівну його значенню. Наприклад: якщо А
//= 3, а В = 7, то програма має сформувати в консолі такий
//висновок:
//3 3 3
//4 4 4 4
//5 5 5 5 5
//6 6 6 6 6 6
//7 7 7 7 7 7 7

namespace Exercice5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter start: ");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter end: ");
            int B = Convert.ToInt32(Console.ReadLine());

            while (A <= B)
            {
                for (int i = 0; i < A; i++)
                    Console.Write(A + " ");
                Console.WriteLine();
                A++;
            }
            Console.ReadLine();
        }
    }
}
