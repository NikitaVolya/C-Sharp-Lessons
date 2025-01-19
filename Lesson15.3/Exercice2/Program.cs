using System;
using Serilog;

//Завдання 2:
//Створіть додаток для генерації фейкових користувачів. Кожен
//користувач повинен мати таку інформацію:
// Ім'я
// Прізвище
// Контактний телефон
// Email
// Адреса
//Генерація фейкових користувачів оформіть у вигляді класу.
//Фактично, потрібно створити клас для створення фейкового
//користувача.
//Напишіть код для тестування фейкових користувачів.
//В програмі налаштуйте логування з використанням Serialog.

namespace Exercice2
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }

        public override string ToString() => $"{FirstName} {LastName} {PhoneNumber} {Email} {Adresse}";
    }

    public class UserRandomBilder
    {
        private static Random random = new Random();

        static public string GetRandomFirstName()
        {
            string[] names = new string[]
            {
                "John", "Emily", "Michael", "Sophia", "James", "Olivia",
                "David", "Emma", "Daniel", "Isabella", "Matthew", "Ava", "Andrew", "Mia",
                "William", "Charlotte", "Christopher", "Amelia", "Joshua", "Harper"
            };
            return names[random.Next(names.Length)];
        }
        static public string GetRandomLastName()
        {
            string[] lastNames = { "Smith", "Johnson", "Brown", "Williams", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin" };
            return lastNames[random.Next(lastNames.Length)];
        }
        static public string GetRandomPhoneNumber()
        {
            string rep = "";
            for (int i = 0; i < 10; i++)
            {
                rep += (char)random.Next('0', '9');
            }
            return rep;
        }
        static public string GenerateEmail(string first_name, string last_name) => first_name.ToLower() + "." + last_name.ToLower() + "@gmail.com";
        static public string GetRandomAdresse()
        {
            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville", "Fort Worth", "Columbus", "San Francisco", "Charlotte", "Seattle", "Denver", "Washington", "Boston" };
            string[] streets = { "Main Street", "High Street", "Oak Avenue", "Maple Drive", "Elm Street", "Pine Lane", "Cedar Road", "Church Street", "River Road", "Sunset Boulevard", "Park Avenue", "Broadway", "5th Avenue", "1st Street", "Spring Street", "Hilltop Road", "Lakeview Drive", "Meadow Lane", "Washington Avenue", "King Street" };
            return cities[random.Next(cities.Length)] + ", " + streets[random.Next(cities.Length)] + ", " + Convert.ToString(random.Next(35));
        }

        static public User GetRandomUser()
        {
            string FirstName = GetRandomFirstName();
            string LastName = GetRandomLastName();
            string Email = GenerateEmail(FirstName, LastName);
            string PhoneNumber = GetRandomPhoneNumber();
            string Adresse = GetRandomAdresse();
            Program.logger.Information($"Generate user = fn:{FirstName} ln:{LastName} e:{Email} pn:{PhoneNumber} a:{Adresse}");
            return new User { FirstName = FirstName, LastName = LastName, 
                Email = Email, PhoneNumber = PhoneNumber, Adresse = Adresse };
        }

        static public User[] GenerateUserList(int number)
        {
            User[] rep = new User[number];
            for (int i = 0; i < number; i++)
                rep[i] = GetRandomUser();
            return rep;
        }
    }

    internal class Program
    {
        public static Serilog.Core.Logger logger = new LoggerConfiguration()
            .WriteTo.Console().MinimumLevel.Debug().CreateLogger();

        static void Main(string[] args)
        {
            User[] users = UserRandomBilder.GenerateUserList(15);
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine(users[i]); 
            }

            Console.ReadLine();
        }
    }
}
