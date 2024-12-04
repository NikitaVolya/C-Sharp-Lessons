using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть клас «Будинок», в якому має міститися ін-
//формація про квартири в цьому будинку. Створіть клас
//«Квартира» з інформацією про мешканців квартир. Реалі-
//зуйте підтримку ітератора для класів «Будинок» і «Квар-
//тира». Протестуйте можливість використання foreach для
//класів «Будинок» і «Квартира».

class Apartment
{
    public string OwnerFullName { get; set; }
    public float Size { get; set; }
    public int Stage {  get; set; }

    public Apartment(string ownerFullName, float size, int stage)
    {
        OwnerFullName = ownerFullName;
        Size = size;
        Stage = stage;
    }

    public override string ToString()
    {
        return $"{OwnerFullName} | Size: {Size} | Stage: {Stage}";
    }
}

class House
{
    private List<Apartment> _apartments;

    public House() { }
    public House(params Apartment[] apartments)
    {
        _apartments = new List<Apartment>(apartments);
    }
    public void AddApartment(Apartment apartment)
    {
        _apartments.Add(apartment);
    }
    public IEnumerator<Apartment> GetEnumerator()
    {
        for (int i = 0; i < _apartments.Count; i++)
        {
            yield return _apartments[i];
        }
    }
}

namespace Exercice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            House house = new House (
                new Apartment("Volianskyi Nikita", 22, 1),
                new Apartment("Slobodanuke", 22, 2)
            );

            foreach (Apartment apartment in house)
            {
                Console.WriteLine(apartment.ToString());
            }
            Console.Read();
        }
    }
}
