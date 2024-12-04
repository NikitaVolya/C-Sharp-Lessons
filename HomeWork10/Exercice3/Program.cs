using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть клас «Кредитна картка». Клас повинен містити:
//■ Номер картки;
//■ ПІБ власника;
//■ Термін дії карти;
//■ PIN;
//■ Кредитний ліміт;
//■ Сума грошей.
//Створіть потрібний набір способів класу. Реалізуйте
//події для наступних ситуацій:
//■ Поповнення рахунку;
//■ Витрата коштів з рахунку;
//■ Старт використання кредитних коштів;
//■ Досягнення ліміту заданої суми грошей;
//■ Зміна PIN.

namespace Exercice3
{
    class CreditCard
    {
        UInt64 _number;
        UInt16 _cvc;
        UInt32 _data;

        UInt16 _pin;
        double _credit_limit;


        public CreditCard(string pNumber, int pCVC, string pData, string pOwnerFullName, int pPin, double pCash)
        {
            Number = pNumber;
            OwnerFullName = pOwnerFullName;
            CVC = pCVC;
            Data = pData;
            PIN = pPin;
            Cash = pCash;
        }

        public string Number
        {
            get
            {
                return Convert.ToString(_number);
            }
            set
            {
                if (value.Length != 16)
                    throw new ArgumentException("Credit card: Invalid credit card number format.");

                if (!value.All(char.IsNumber))
                    throw new ArgumentException("Credit card: Invalid credit card number format.");

                _number = Convert.ToUInt64(value);
            }
        }
        public string OwnerFullName { get; set; }
        public int CVC
        {
            get { return _cvc; }
            set
            {
                if (value > 999 || value < 0)
                    throw new ArgumentException("Credit card: Invalid CVC format.");
                _cvc = (ushort)Convert.ToInt16(value);
            }
        }
        public string Data
        {
            get
            {
                UInt32 day = _data >> 27;
                UInt32 month = _data >> 23 & 15;
                UInt32 year = _data & 0b1111111111111111;
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

                _data = day << 27 | month << 23 | year;
            }
        }
        public double Cash { get; set; }
        public int PIN
        {
            get => Convert.ToInt32(_pin);
            set
            {
                if (value < 0 || 9999 < value)
                    throw new ArgumentException("Invalide pin code format");
                _pin = Convert.ToUInt16(_pin);
            }
        }
        public double CreditLimit
        {
            get => _credit_limit;
            set
            {
                if (value < 0) throw new ArgumentException();
                _credit_limit = value;
            }
        }

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
