using Serilog;
using System;

//Завдання 2:
//Замініть механізм логування з попереднього завдання на
//Serialog. Механізм логування має працювати так само, як у
//попередньому завданні.

namespace Exercice2
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
                    _func = (a, b) => (float)Math.Pow(a, b);
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
                if (!_loop)
                    break;

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

        public static Serilog.Core.Logger logger = new LoggerConfiguration().WriteTo.Console().MinimumLevel.Debug().CreateLogger();


        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.MainLoop();
            Console.ReadLine();
        }
    }
}
