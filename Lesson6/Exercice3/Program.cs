using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//В одному з попередніх практичних завдань ви ство-
//рювали клас «Місто». Виконайте перевантаження + (для Практичне завдання 1
//збільшення кількості жителів на вказану кількість), – (для
//зменшення кількості жителів на вказану кількість), ==
//(перевірка на рівність двох міст за кількістю жителів),
//< і > (перевірка на меншу чи більшу кількість мешкан-
//ців), != і Equals. Використовуйте механізм властивостей
//полів класу.

namespace Exercice3
{
    class City
    {
        private string[] _city_districts;

        public City(string name, string countryName, uint residentsNumber, ulong cityNumber, string[] cityDisctricts)
        {
            Name = name;
            CountryName = countryName;
            ResidentsNumber = residentsNumber;
            CityNumber = cityNumber;
            CityDisctricts = cityDisctricts;
        }

        public string Name { get; set; }
        public string CountryName { get; set; }
        public UInt32 ResidentsNumber { get; set; }
        public UInt64 CityNumber { get; set; }
        public string[] CityDisctricts
        {
            get
            {
                string[] rep = new string[_city_districts.Length];
                _city_districts.CopyTo(rep, _city_districts.Length);
                return rep;
            }
            set
            {
                _city_districts = new string[value.Length];
                value.CopyTo(_city_districts, 0);
            }
        }
        public string GetDistrictName(int index)
        {
            if (index < 0 || index >= _city_districts.Length)
                return null;
            return _city_districts[index];
        }
        public int DistrictsNumber
        {
            get { return _city_districts.Length; }
        }

        public static City operator +(City city, long number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number));
            city.ResidentsNumber += Convert.ToUInt32(number);
            return city;
        }
        public static City operator -(City city, long number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number));
            if (number > city.ResidentsNumber)
                city.ResidentsNumber = 0;
            else
                city.ResidentsNumber -= Convert.ToUInt32(number);
            return city;
        }
        public static bool operator ==(City city1, City city2)
        {
            return city1.ResidentsNumber == city2.ResidentsNumber;
        }
        public static bool operator !=(City city1, City city2)
        {
            return !(city1 == city2);
        }
        public static bool operator <(City city1, City city2)
        {
            return city1.ResidentsNumber < city2.ResidentsNumber;
        }
        public static bool operator >(City city1, City city2)
        {
            return city1.ResidentsNumber > city2.ResidentsNumber;
        }
        public override string ToString()
        {
            string DistrictsNames = "[ ";
            foreach (var disctrict in _city_districts)
            {
                DistrictsNames += disctrict + ", ";
            }
            DistrictsNames += "]";
            return $"Name: {Name}, Country: {CountryName}, ResidentsNumber: {ResidentsNumber}, CityNumber {CityNumber}, Districts: {DistrictsNames}";
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
            City city = new City(
               "Saint-Etienne",
               "France",
               172000,
               0477487748,
               new string[] { "Metar", "Jean Monnet" }
            );
            city += 1000;
            Console.WriteLine(city);
            Console.ReadLine();
        }
    }
}
