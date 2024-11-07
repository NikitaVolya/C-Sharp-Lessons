using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Користувач вводить до рядка з клавіатури 0 і 1. Необхід-
//но перетворити рядок на число цілого типу в десятковому
//поданні. Передбачити випадок виходу за межі діапазону,
//який визначається типом int, неправильне введення. Ви-
//користовуйте механізм виключень.

namespace Exercice2
{
    internal class Program
    {
        static int BinToInt(string value)
        {
            int rep = 0;
            try
            {
                rep = Convert.ToInt32(value, 2);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Bin value is overflow!");
            }
            return rep;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(BinToInt("1101"));
            Console.WriteLine(BinToInt("111111111111111111111111111111111"));
            Console.ReadLine();
        }
    }
}
