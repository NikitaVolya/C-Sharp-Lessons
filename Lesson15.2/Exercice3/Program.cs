using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

//Завдання 3:
//Створіть додаток для парсингу текстового файлу.
//Формат файлу:
//Число операція Число
//Число операція Число
//Наприклад:
//3 + 4
//2 * 5
//6 - 2
//Числа у файлі можуть бути лише цілими.
//Операція — одна з чотирьох: +, -, *, /.
//Додаток має підраховувати результат виразів з файлу і виводити
//його на екран.
//Приклад виведення:
//3 + 4 = 7
//2 * 5 = 10
//6 – 2 = 4
//Додаток має використовувати можливості NLog або Serialog для
//логування обробки файлу і роботи додатка.

namespace Exercice3
{
    public class FileMath
    {
        private string[] _data;

        public FileMath() 
        {
            _data = null;
        }

        public void Clear() => _data = null;
        public void LoadFile(string file_path)
        {
            try
            {
                string data = File.ReadAllText(file_path);
                _data = data.Split(new char[] { '\n' });
            }
            catch
            {
                Program.logger.Error("File dont found");
            }
        }
        public void SaveFile()
        {
            if (_data == null) 
            {
                Program.logger.Information("FileMath data is clear");
                return;
            }
            try
            {
                File.WriteAllText("output_file.txt", String.Join("\n", _data));
            }
            catch
            {
                Program.logger.Error("Saving file error");
            }
        }

        private static int FindOperatorIndex(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if ("+-*/".Contains(expression[i]))
                    return i;
            }
            return -1;
        }
        private static Func<double, double, double> GetMathFunction(char symbl)
        { 
            switch (symbl)
            {
                case '+': return (a, b) => a + b;
                case '-': return (a, b) => a - b;
                case '/': return (a, b) => a / b;
                case '*': return (a, b) => a * b;
                default: return null;
            }
        }
        private static double EvaluateExpression(string expression)
        {
            Program.logger.Information("Start evaluate expression {0}", expression);

            expression = expression.Replace(" ", "");

            int operatorIndex = FindOperatorIndex(expression);
            if (operatorIndex == -1)
                throw new ArgumentException("Syntax error");

            string leftPart = expression.Substring(0, operatorIndex);
            string rightPart = expression.Substring(operatorIndex + 1);
            char operation = expression[operatorIndex];

            double leftOperand = double.Parse(leftPart);
            double rightOperand = double.Parse(rightPart);

            double rep = GetMathFunction(operation)(leftOperand, rightOperand);
            Program.logger.Information("Done!");
            return rep;
        }
        public void Calcule()
        {
            if (_data == null)
            {
                Program.logger.Information("FileMath data is clear");
                return;
            }
            for (int i = 0; i < _data.Length; i++)
            {
                try
                {
                    _data[i] = EvaluateExpression(_data[i]).ToString();
                }
                catch
                {
                    Program.logger.Error("Evaluate Expression Error");
                }
            }
        }

        public void ExecuteFile(string file_path)
        {
            LoadFile(file_path);
            Calcule();
            SaveFile();
        }
    }

    internal class Program
    {
        public static Serilog.Core.Logger logger = new LoggerConfiguration().WriteTo.Console().MinimumLevel.Debug().CreateLogger();

        static void Main(string[] args)
        {
            FileMath file = new FileMath();
            file.ExecuteFile("test.txt");
            Console.ReadKey();
        }
    }
}
