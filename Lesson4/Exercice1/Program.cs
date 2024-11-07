using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Користувач вводить до рядка з клавіатури набір сим-
//волів від 0-9. Необхідно перетворити рядок на число ціло-
//го типу. Передбачити випадок виходу за межі діапазону,
//який визначається типом int. Використовуйте механізм
//виключень.

namespace Exercice1
{
    internal class Program
    {
        static int inputInteger()
        {
            int rep = 0;
            try
            {
                rep = Convert.ToInt32(Console.ReadLine());
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Input value is overflow!");
            }
            return rep;
        }

        static void Main(string[] args)
        {

            int a = inputInteger();
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
