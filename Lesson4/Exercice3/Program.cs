using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть клас «Кредитна картка». Вам необхідно зберіга-
//ти інформацію про номер картки, ПІБ власника, CVC, дату
//завершення роботи картки і т.д. Передбачити механізми
//ініціалізації полів класу. Якщо значення для ініціалізації
//неправильне, генеруйте виняток.

namespace Exercice3
{
    class CreditCard
    {
        UInt64 number;
        
        public string Number
        {
            get
            {
                return Convert.ToString(number);
            }
            set
            {
                if (value.Length != 16)
                    throw new ArgumentException("Credit card: Invalid credit card number format.");

                if (!value.All(char.IsNumber))
                    throw new ArgumentException("Credit card: Invalid credit card number format.");

                number = Convert.ToUInt64(value);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard a = new CreditCard { Number="1234567891234567"};
            Console.WriteLine(a.Number);
            Console.ReadKey();
        }
    }
}
