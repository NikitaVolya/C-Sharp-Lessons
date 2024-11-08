using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 4
//Користувач вводить до рядка з клавіатури математич-
//ний вираз. Наприклад, 3*2*1*4. Програма має підрахувати
//результат введеного виразу. У рядку можуть бути лише
//цілі числа і оператор*. Для обробки помилок введення
//використовуйте механізм виключень

namespace Exerice4
{

    internal class Program
    {
        static int evalMultiple(string line)
        {
            if (line == null) 
                throw new ArgumentException("The line must not be null");
            if (line == "")
                throw new ArgumentException("The line must not be empty");
            if (!Char.IsDigit(line[0]))
                throw new ArgumentException("Invalide first character in string: " + line[0]);
            int rep = 1;
            int tmp = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '*')
                {
                    rep *= tmp;
                    tmp = 0;
                }
                else if (Char.IsDigit(line[i]))
                    tmp = tmp * 10 + line[i] - '0';
                else
                    throw new ArgumentException("Invalide value in string: " + line[i]);
            }
            rep *= tmp;
            return rep;
        }
        static void Main(string[] args)
        {
            try {
                Console.WriteLine(evalMultiple("2*12*2"));
            } catch (ArgumentException e) { 
                Console.WriteLine(e.Message); 
            }
            try
            {
                Console.WriteLine(evalMultiple("2*12*2.4"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine(evalMultiple("2*12a*2"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine(evalMultiple("*12*24"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine(evalMultiple(""));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine(evalMultiple(null));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
