using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Реалізуйте користувацький тип «Фірма». В ньому має бути
//інформація про назву фірми, дату заснування, профіль бізнесу
//(маркетинг, IT, і т. д.), ПІБ директора, кількість працівників,
//адреса.
//Для масиву фірм реалізуйте такі запити:
// Отримати інформацію про всі фірми.
// Отримати фірми, які мають у назві слово «Food».
// Отримати фірми, які працюють у галузі маркетингу.
// Отримати фірми, які працюють у галузі маркетингу або IT.
// Отримати фірми з кількістю працівників більшою, ніж 100.
// Отримати фірми з кількістю працівників у діапазоні від 100 до 300.
// Отримати фірми, які знаходяться в Лондоні.
// Отримати фірми, в яких прізвище директора White.
// Отримати фірми, які засновані більше двох років тому.
// Отримати фірми з дня заснування яких минуло 123 дні.
// Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White».


namespace Exercice1
{
    class Firm
    {
        public string FirmName;
        public DateTime FirmDate;
        public string FirmProfile;
        public UInt32 EmployeesNumber;
        public string DirectorFullName;
        public string FirmAddress;

        public override string ToString() => $"{FirmName} : {FirmProfile} | {EmployeesNumber}, {DirectorFullName} | {FirmAddress} ({FirmDate})";
    }

    internal class Program
    {
        static void Print(IEnumerable<Firm> list)
        {
            foreach (Firm f in list) Console.WriteLine(f.ToString());
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
                    FirmAddress = "123 Tech Avenue, Silicon Valley, CA"
                },
                new Firm
                {
                    FirmName = "GreenLeaf Industries",
                    FirmDate = new DateTime(2003, 8, 19),
                    FirmProfile = "marketing",
                    EmployeesNumber = 85,
                    DirectorFullName = "Eleanor Green",
                    FirmAddress = "456 Forest Road, Denver, CO"
                },
                new Firm
                {
                    FirmName = "Global Insights Inc.",
                    FirmDate = new DateTime(2015, 2, 10),
                    FirmProfile = "Market Research",
                    EmployeesNumber = 120,
                    DirectorFullName = "Michael Carter",
                    FirmAddress = "789 Business Plaza, Chicago, IL"
                },
                new Firm
                {
                    FirmName = "AquaPure Solutions",
                    FirmDate = new DateTime(2008, 11, 5),
                    FirmProfile = "Water Purification Systems",
                    EmployeesNumber = 60,
                    DirectorFullName = "Sophia Martinez",
                    FirmAddress = "321 Clearwater Drive, Austin, TX"
                },
                new Firm
                {
                    FirmName = "UrbanEdge Designs",
                    FirmDate = new DateTime(2012, 6, 22),
                    FirmProfile = "marketing",
                    EmployeesNumber = 40,
                    DirectorFullName = "James White",
                    FirmAddress = "654 Skyline Street, Seattle, WA"
                },
                new Firm
                {
                    FirmName = "HealthGuard Food Co.",
                    FirmDate = new DateTime(2024, 1, 15),
                    FirmProfile = "Healthcare Solutions",
                    EmployeesNumber = 300,
                    DirectorFullName = "Emma Thompson",
                    FirmAddress = "10 Downing Street, London SW1A 2AA, United Kingdom"
                },
                new Firm
                {
                    FirmName = "NextGen Robotics",
                    FirmDate = new DateTime(2018, 4, 1),
                    FirmProfile = "IT",
                    EmployeesNumber = 220,
                    DirectorFullName = "Alexander Brown",
                    FirmAddress = "159 Innovation Drive, Detroit, MI"
                },
                new Firm
                {
                    FirmName = "BrightSpark Media Food",
                    FirmDate = new DateTime(2005, 9, 30),
                    FirmProfile = "marketing",
                    EmployeesNumber = 90,
                    DirectorFullName = "Isabella Roberts",
                    FirmAddress = "753 Creative Lane, Los Angeles, CA"
                },
                new Firm
                {
                    FirmName = "SafeShield Security White",
                    FirmDate = new DateTime(2013, 3, 18),
                    FirmProfile = "Cybersecurity",
                    EmployeesNumber = 110,
                    DirectorFullName = "David Black",
                    FirmAddress = "147 Secure Way, New York, NY"
                },
                new Firm
                {
                    FirmName = "Peak Performance Consulting",
                    FirmDate = new DateTime(1997, 7, 10),
                    FirmProfile = "Business Consulting",
                    EmployeesNumber = 50,
                    DirectorFullName = "Olivia White",
                    FirmAddress = "221B Baker Street, London NW1 6XE, United Kingdom"
                }
            };

            // Отримати інформацію про всі фірми.
            Print(from firm in firms 
                  select firm);

            // Отримати фірми, які мають у назві слово «Food».
            Print(from firm in firms 
                  where firm.FirmName.Contains("Food") 
                  select firm);

            // Отримати фірми, які працюють у галузі маркетингу.
            Print(from firm in firms 
                  where firm.FirmProfile.Contains("marketing") 
                  select firm);

            // Отримати фірми, які працюють у галузі маркетингу або IT.
            Print(from firm in firms
                  where firm.FirmProfile == "marketing" || firm.FirmProfile == "IT" 
                  select firm);

            // Отримати фірми з кількістю працівників більшою, ніж 100.
            Print(from firm in firms
                  where firm.EmployeesNumber > 100 
                  select firm);

            // Отримати фірми з кількістю працівників у діапазоні від 100 до 300.
            Print(from firm in firms 
                  where firm.EmployeesNumber > 100 && firm.EmployeesNumber < 300 
                  select firm);

            // Отримати фірми, які знаходяться в Лондоні.
            Print(from firm in firms 
                  where firm.FirmAddress.Contains("London")
                  select firm);

            // Отримати фірми, в яких прізвище директора White.
            Print(from firm in firms 
                  where firm.DirectorFullName.EndsWith("White") 
                  select firm);

            // Отримати фірми, які засновані більше двох років тому.
            Print(from firm in firms 
                  where firm.FirmDate < DateTime.Now.AddYears(-4) 
                  select firm);

            // Отримати фірми з дня заснування яких минуло 123 дні.
            Print(from firm in firms 
                  where firm.FirmDate < DateTime.Now.AddDays(-123) 
                  select firm);

            // Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White».
            Print(from firm in firms 
                  where firm.DirectorFullName.EndsWith("Black") && firm.FirmName.Contains("White") 
                  select firm);

            Console.ReadLine();
        }
    }
}
