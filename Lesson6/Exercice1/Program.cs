using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//В одному з попередніх практичних завдань ви створю-
//вали клас «Співробітник». Додайте до вже створеного класу
//інформацію про заробітну плату працівника. Виконайте
//навантаження + (для збільшення зарплати на вказану кіль-
//кість), – (для зменшення зарплати на вказану кількість), ==
//(перевірка на рівність зарплат працівників), < і > (перевірка
//на меншу чи більшу кількість зарплат працівників), != і
//Equals. Використовуйте механізм властивостей полів класу.

namespace Exercice1
{
    class Employer
    {
        private string _birthday;
        private string _telephoneNumber;
        private string _email;
        private double _salary;

        public Employer(string fullname, string birthday, string telephoneNumber, 
            string email, string workDescription, double salary)
        {
            Fullname = fullname;
            Birthday = birthday;
            TelephoneNumber = telephoneNumber;
            Email = email;
            WorkDescription = workDescription;
            _salary = salary;
        }

        public string Fullname { get; set; }
        public string Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (value.Length < 7)
                    return;

                short day = Convert.ToInt16(value.Substring(0, 2));
                if (day <= 0 || day > 31)
                    return;

                short month = Convert.ToInt16(value.Substring(3, 2));
                if (month <= 0 || month > 12)
                    return;
                _birthday = value;
            }
        }
        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set
            {
                if (value.Length < 10)
                    return;
                int number;
                if (!int.TryParse(value, out number))
                    return;

                _telephoneNumber = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.IndexOf('@') == -1)
                    return;
                _email = value;
            }
        }
        public string WorkDescription { get; set; }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public static Employer operator +(Employer obj, double value)
        {
            obj.Salary = obj.Salary + value;
            return obj;
        }
        public static Employer operator -(Employer obj, double value)
        {
            obj.Salary = -obj.Salary - value;
            return obj;
        }
        public static bool operator ==(Employer left, Employer right)
        {
            return left.Salary == right.Salary;
        }
        public static bool operator !=(Employer left, Employer right)
        {
            return !(left._salary == right._salary);
        }
        public static bool operator >(Employer left, Employer right)
        {
            return left._salary > right._salary;
        }
        public static bool operator <(Employer left, Employer right)
        {
            return left._salary < right._salary;
        }
        public override bool Equals(object other)
        {
            return ToString() == other.ToString();
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"Employer: {Fullname}, {_email} : {_birthday} [{_telephoneNumber}, {_salary} $]";
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
            Employer employer = new Employer("Nikita Voliankyi Oleksandr", "13-03-2006", "0981132029", 
                "volianskyinikita@gmail.com", "Back end", 1200);
            employer.Print();
            employer += 350.5;
            employer.Print();

            Console.ReadLine();
        }
    }
}
