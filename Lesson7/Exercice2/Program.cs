using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть клас Passport (паспорт), який міститиме па-
//спортну інформацію про громадянина заданої країни.
//За допомогою механізму спадкування реалізуйте клас
//ForeignPassport (закордонний паспорт), похідний від Passport.
//Нагадаємо, що закордонний паспорт містить, крім
//паспортних даних, дані про візи і номер закордонного
//паспорта.
//Кожен з класів повинен містити необхідні методи.

namespace Exercice2
{
    class Passport
    {
        private DateTime _birthday;

        public string FullName { get; set; }
        public string Country { get; set; }
        public string Number { get; set; }
        public int[] Birthday
        {
            get
            {
                return new int[3] { _birthday.Day, _birthday.Month, _birthday.Year };
            }
            set
            {
                if (value == null || value.Length != 3)
                    throw new ArgumentException();
                _birthday = new DateTime(value[2], value[1], value[0]);
            }
        }

        public Passport(string ful_name, string country, string number, int[] birthday)
        {
            FullName = ful_name;
            Country = country;
            Number = number;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return FullName + " (" + _birthday.ToString("d") + ") : " + Country + " | " + Number;
        }
    }

    class ForeignPassport : Passport 
    { 
        public string VisaNumber { get; set; }
        
        public ForeignPassport(string full_name, string country, string number, int[] birthday, string visa_number) : base(full_name, country, number, birthday)
        {
            VisaNumber = visa_number;
        }
        public ForeignPassport(Passport passport, string visa_number) : base(passport.FullName, passport.Country, passport.Number, passport.Birthday)
        {
            VisaNumber = visa_number;
        }

        public override string ToString()
        {
            return base.ToString() + " VisaNUmber: " + VisaNumber;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Passport base_passport = new Passport("Volianskyi Nikita", "Ukraine", "EH878695", new int[] {13, 3, 2006 });
            ForeignPassport foreign_passport = new ForeignPassport(base_passport, "123456789");

            Console.WriteLine(base_passport);
            Console.WriteLine(foreign_passport);
            Console.ReadLine();
        }
    }
}
