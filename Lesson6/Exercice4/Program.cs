using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 4
//В одному з попередніх практичних завдань ви створю-
//вали клас «Кредитна картка». Додайте до вже створеного
//класу інформацію про суму грошей на картці. Виконай-
//те перевантаження + (для збільшення суми грошей на
//вказану кількість), – (для зменшення суми грошей на
//вказану кількість), == (перевірка на рівність CVC коду),
//< і > (перевірка на меншу чи більшу кількість суми гро-
//шей), != і Equals. Використовуйте механізм властивостей
//полів класу.

namespace Exercice4
{
    class CreditCard
    {
        UInt64 number;
        UInt16 cvc;
        UInt32 data;

        public CreditCard(string pNumber, string pOwnerFullName, int pCVC, string pData, double cash)
        {
            Number = pNumber;
            OwnerFullName = pOwnerFullName;
            CVC = pCVC;
            Data = pData;
            Cash = cash;
        }

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
            set
            {
                if (value > 999 || value < 0)
                    throw new ArgumentException("Credit card: Invalid CVC format.");
                cvc = (ushort)Convert.ToInt16(value);
            }
        }
        public string Data
        {
            get
            {
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
        public double Cash { get; set; }

        public static CreditCard operator +(CreditCard c1, double value)
        {
            c1.Cash += value;
            return c1;
        }
        public static CreditCard operator -(CreditCard c1, double value)
        {
            c1.Cash -= value;
            return c1;
        }
        public static bool operator ==(CreditCard c1, int value)
        {
            return c1.CVC == Convert.ToUInt16(value);
        }
        public static bool operator !=(CreditCard c1, int value)
        {
            return !(c1 == value);
        }
        public static bool operator <(CreditCard c1, double value)
        {
            return c1.Cash < value;
        }
        public static bool operator >(CreditCard c1, double value)
        {
            return c1.Cash > value;
        }

        public override string ToString()
        {
            return $"{Number} {CVC} {Data} {OwnerFullName}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
