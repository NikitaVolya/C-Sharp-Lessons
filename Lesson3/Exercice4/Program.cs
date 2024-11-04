using System;

namespace Exercice4
{
    class City
    {
        private string[] _city_districts;

        public string Name { get; set; }
        public string CountryName{ get; set; }
        public UInt32 ResidentsNumber { get; set; }
        public UInt64 CityNumber { get; set; }
        public string[] CityDisctricts
        {
            get {
                string[] rep = new string[_city_districts.Length];
                _city_districts.CopyTo(rep, _city_districts.Length);
                return rep;
            }
            set {
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

        public void Print()
        {
            string DistrictsNames = "[ ";
            foreach (var disctrict in _city_districts)
            {
                DistrictsNames += disctrict + ", ";
            }
            DistrictsNames += "]";
            Console.WriteLine($"Name: {Name}, Country: {CountryName}, ResidentsNumber: {ResidentsNumber}, CityNumber {CityNumber}, Districts: {DistrictsNames}");
        }
    }

    internal class Program
    {
       

        static void Main(string[] args)
        {
            City city = new City { 
               Name="Saint-Etienne",
               CountryName="France", 
               CityDisctricts = new string[] { "Metar", "Jean Monnet" },
               ResidentsNumber = 172718,
               CityNumber = 0477487748 
            };
            city.Print();
            Console.ReadKey();
        }
    }
}
