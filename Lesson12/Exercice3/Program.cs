using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть клас «Гараж». Клас має містити інформацію
//про машини, які знаходяться в гаража. Створіть клас
//«Автомобіль», в якому, відповідно, міститься інформація
//про автомобіль. Реалізуйте підтримку ітератора для класу
//«Гараж». Протестуйте можливість використання foreach
//для класу «Гараж».

class Auto
{
    public string Name { get; set; }
    public int CreatingYear { get; set; }
    public float Speed { get; set; }

    public Auto(string name, int creating_year, float speed)
    {
        Name = name;
        CreatingYear = creating_year;
        Speed = speed;
    }

    public override string ToString()
    {
        return $"{Name} | Creating year: {CreatingYear} | Speed: {Speed}";
    }
}

class Garage
{
    private List<Auto> _autos;

    public Garage() { }
    public Garage(params Auto[] autos)
    {
        _autos = new List<Auto>(autos);
    }
    public void AddAto(Auto auto)
    {
        _autos.Add(auto);
    }
    public IEnumerator<Auto> GetEnumerator()
    {
        for (int i = 0; i < _autos.Count; i++)
        {
            yield return _autos[i];
        }
    }
}

namespace Exercice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage(
                new Auto("Mercedes-Benz 770", 1930, 160),
                new Auto("Isetta", 1955, 97)
            );

            foreach (Auto auto in garage)
            {
                Console.WriteLine(auto.ToString());
            }
            Console.ReadKey();
        }
    }
}
