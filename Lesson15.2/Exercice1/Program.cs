using System;

//Завдання 1:
//Створіть програму «Калькулятор», яка дозволить користувачу
//проводити базові арифметичні операції:
// додавання;
// віднімання;
// множення;
// ділення;
// відсоток;
// піднесення до степеня.
//Підключіть NLog для логування роботи програми. Логування має
//працювати за такими правилами:
// залежно від вибору користувача, логування має виводити
//інформацію у файл або консоль;
// у разі серйозної помилки (наприклад, ділення на нуль),
//логування має відобразити інформацію в консоль і файл.

namespace Exercice1
{
    class Calculator
    {
        private Func<float, float, float> _func;
        private float _number;
        private bool _loop;
        

        public Calculator()
        {
            _func = (a, b) => a + b;
            _number = 0;
            _loop = true;
        }

        private void ChoiceFunction()
        {
            Console.Write("Math function: ");
            char function_name = Console.ReadLine()[0];
            switch (function_name)
            {
                case '+':
                    _func = (a, b) => a + b;
                    break;
                case '*':
                    _func = (a, b) => a * b;
                    break;
                case '-':
                    _func = (a, b) => a - b;
                    break;
                case '/':
                    _func = (a, b) => a / b;
                    break;
                case '%':
                    _func = (a, b) => a * (b / 100.0f);
                    break;
                case '^':
                    _func = (a, b) =>(float) Math.Pow(a, b);
                    break;
                case 'q':
                    _func = (a, b) => a;
                    _loop = false;
                    break;
                default:
                    _func = null;
                    Program.logger.Error("Uknown function");
                    break;
            }
        }

        private static float GetFloat()
        {
            float rep = 0.0f;
            try
            {
                Console.Write("Number: ");
                rep = float.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Program.logger.Error("Error: Parse float number");
            }
            return rep;
        }

        public void MainLoop()
        {
            _number = GetFloat();
            while (_loop)
            {
                Console.WriteLine(_number);

                ChoiceFunction();
                if (_func == null)
                    continue;

                float tmp = GetFloat();
                try
                {
                    _number = _func(_number, tmp);
                } 
                catch (Exception ex)
                {
                    Program.logger.Error("Error: Calculation function");
                    continue;
                }
            }
        }
    }

    internal class Program
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.MainLoop();
            Console.ReadLine();
        }
    }
}
