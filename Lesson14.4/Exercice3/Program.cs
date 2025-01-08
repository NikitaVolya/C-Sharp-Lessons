using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3:
//Додайте до першого завдання клас, який містить інформацію про
//працівників. Потрібно зберігати такі дані:
// ПІБ співробітника
// Посада
// Контактний телефон
// Email
// Заробітна плата
//Помістіть інформацію про працівників всередину фірми.
//Для масиву співробітників фірми реалізуйте наступні запити:
// Отримати список усіх працівників певної фірми.
// Отримати список усіх працівників певної фірми, в яких заробітна плата більша заданої.
// Отримати список працівників усіх фірм, в яких є посада «Менеджер».
// Отримати список працівників, в яких телефон починається з «23».
// Отримати список працівників, в яких Email починається з «di».
// Отримати список працівників з ім'ям Lionel

namespace Exercice3
{
    class Employer
    {
        public string FullName;
        public string Post;
        public string PhoneNumber;
        public string Email;
        public double Salary;

        public override string ToString() => $"{FullName}, {Post} | {Salary} ({PhoneNumber}, {Email})";
    }

    class Firm
    {
        public string FirmName;
        public DateTime FirmDate;
        public string FirmProfile;
        public UInt32 EmployeesNumber;
        public string DirectorFullName;
        public string FirmAddress;
        public List<Employer> Employers;
        public override string ToString() => $"{FirmName} : {FirmProfile} | {EmployeesNumber}, {DirectorFullName} | {FirmAddress} ({FirmDate})";
    }

    internal class Program
    {
        static void Print<T>(IEnumerable<T> list)
        {
            foreach (T f in list) Console.WriteLine(f);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Firm[] firms = new Firm[]
            {
                new Firm
                {
                    FirmName = "TechNova Ltd.",
                    FirmDate = new DateTime(2010, 5, 12),
                    FirmProfile = "IT",
                    EmployeesNumber = 150,
                    DirectorFullName = "Johnathan Smith",
                    FirmAddress = "123 Tech Avenue, Silicon Valley, CA",
                    Employers = new List<Employer>
                    {
                        new Employer { FullName = "Lionel Carter", Post = "Software Engineer", PhoneNumber = "2345678901", Email = "di.lionel@technova.com", Salary = 85000 },
                        new Employer { FullName = "Emily Johnson", Post = "Manager", PhoneNumber = "2312345678", Email = "emily.j@technova.com", Salary = 92000 }
                    }
                },
                new Firm
                {
                    FirmName = "GreenLeaf Industries",
                    FirmDate = new DateTime(2003, 8, 19),
                    FirmProfile = "Marketing",
                    EmployeesNumber = 85,
                    DirectorFullName = "Eleanor Green",
                    FirmAddress = "456 Forest Road, Denver, CO",
                    Employers = new List<Employer>
                    {
                        new Employer { FullName = "Michael Brown", Post = "Marketing Specialist", PhoneNumber = "2345557890", Email = "di.michael@greenleaf.com", Salary = 60000 },
                        new Employer { FullName = "Sophia Martinez", Post = "Manager", PhoneNumber = "2319876543", Email = "sophia.m@greenleaf.com", Salary = 75000 }
                    }
                },
                new Firm
                {
                    FirmName = "Global Insights Inc.",
                    FirmDate = new DateTime(2015, 2, 10),
                    FirmProfile = "Market Research",
                    EmployeesNumber = 120,
                    DirectorFullName = "Michael Carter",
                    FirmAddress = "789 Business Plaza, Chicago, IL",
                    Employers = new List<Employer>
                    {
                        new Employer { FullName = "Lionel Garcia", Post = "Data Analyst", PhoneNumber = "2343456789", Email = "di.lionel@globalinsights.com", Salary = 65000 },
                        new Employer { FullName = "Emma Davis", Post = "Manager", PhoneNumber = "2311112233", Email = "emma.d@globalinsights.com", Salary = 80000 }
                    }
                },
                new Firm
                {
                    FirmName = "AquaPure Solutions",
                    FirmDate = new DateTime(2008, 11, 5),
                    FirmProfile = "Water Purification Systems",
                    EmployeesNumber = 60,
                    DirectorFullName = "Sophia Martinez",
                    FirmAddress = "321 Clearwater Drive, Austin, TX",
                    Employers = new List<Employer>
                    {
                        new Employer { FullName = "John White", Post = "Engineer", PhoneNumber = "2348765432", Email = "john.w@aquapure.com", Salary = 70000 },
                        new Employer { FullName = "Lionel Evans", Post = "Manager", PhoneNumber = "2313334445", Email = "di.lionel@aquapure.com", Salary = 78000 }
                    }
                },
                new Firm
                {
                    FirmName = "UrbanEdge Designs",
                    FirmDate = new DateTime(2012, 6, 22),
                    FirmProfile = "Marketing",
                    EmployeesNumber = 40,
                    DirectorFullName = "James White",
                    FirmAddress = "654 Skyline Street, Seattle, WA",
                    Employers = new List<Employer>
                    {
                        new Employer { FullName = "Liam Brown", Post = "Graphic Designer", PhoneNumber = "2349876543", Email = "liam.b@urbanedge.com", Salary = 50000 },
                        new Employer { FullName = "Noah Wilson", Post = "Manager", PhoneNumber = "2315556667", Email = "noah.w@urbanedge.com", Salary = 72000 }
                    }
                }
            };

            // Отримати список усіх працівників певної фірми.
            Print(from firm in firms
                  from employer in firm.Employers
                  where firm == firms[0]
                  select employer);


            // Отримати список усіх працівників певної фірми, в яких заробітна плата більша заданої.
            double min_salary = 9000;
            Print(from firm in firms
                  from employer in firm.Employers
                  where employer.Salary > min_salary
                  select employer);

            // Отримати список працівників усіх фірм, в яких є посада «Менеджер».
            Print(from firm in firms
                  from employer in firm.Employers
                  where employer.Post == "Manager"
                  select employer);

            // Отримати список працівників, в яких телефон починається з «23».
            Print(from firm in firms
                  from employer in firm.Employers
                  where employer.PhoneNumber.StartsWith("23")
                  select employer);

            // Отримати список працівників, в яких Email починається з «di».
            Print(from firm in firms
                  from employer in firm.Employers
                  where employer.Email.StartsWith("di")
                  select employer);

            // Отримати список працівників з ім'ям Lionel
            Print(from firm in firms
                  from employer in firm.Employers
                  where employer.FullName.StartsWith("Lionel")
                  select employer);

            Console.ReadLine();
        }
    }
}
