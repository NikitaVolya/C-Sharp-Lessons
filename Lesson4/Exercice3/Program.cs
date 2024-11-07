using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        UInt16 cvc;
        UInt32 data;

        
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
        public string OwnerFullName { get; set; }
        public int CVC
        {
            get { return cvc; }
            set {
                if (value > 999 || value < 0)
                    throw new ArgumentException("Credit card: Invalid CVC format.");
                cvc = (ushort)Convert.ToInt16(value);
            }
        }

        public string Data
        {
            get {
                UInt32 day = data >> 27;
                UInt32 month = data >> 23 & 15;
                UInt32 year = data & 0b1111111111111111;
                return Convert.ToString((int)day) + "/" + Convert.ToString((int)month) + "/" + Convert.ToString((int)year);
            }
            set
            {
                if (value.Length != 10)
                    throw new ArgumentException("Credit card: Invalid date format.");
                if (value[2] != '/' || value[5] != '/')
                    throw new ArgumentException("Credit card: Invalid date format.");
                UInt32 day = Convert.ToUInt32(value.Substring(0, 2));
                
                UInt32 month = Convert.ToUInt32(value.Substring(3, 2));
                UInt32 year = Convert.ToUInt32(value.Substring(6));
                if (day > 31 || month > 12)
                    throw new ArgumentException("Credit card: Invalid date format.");

                data = day << 27 | month << 23 | year;
            }
        }

        public CreditCard(string pNumber, string pOwnerFullName, int pCVC, string pData)
        {
            Number = pNumber;
            OwnerFullName = pOwnerFullName;
            CVC = pCVC;
            Data = pData;
        }

        public void Print()
        {
            Console.WriteLine($"{Number} {CVC} {Data} {OwnerFullName}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard card;
            try
            {
                card = new CreditCard("1234567891234567", "Nikita Volianskyi", 203, "07/11/2023");
                card.Print();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                card = new CreditCard("12345678912345679", "Nikita Volianskyi", 203, "07/11/2023");
                card.Print();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                card = new CreditCard("1234567891234567", "Nikita Volianskyi", 2033, "07/11/2024");
                card.Print();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                card = new CreditCard("1234567891234567", "Nikita Volianskyi", 203, "72-22-2023");
                card.Print();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
