using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3:
//Додайте до першого завдання нову функціональність:
// Виведіть статистику за кількістю телефонів кожного
//виробника. Наприклад: Sony — 3, Samsung — 4, Apple — 5 і т. д.
// Виведіть статистику за кількістю моделей телефонів.
//Наприклад: IPhone 13 — 12, IPhone 10 — 11, Galaxy S22 — 8.
// Виведіть статистику телефонів за роками. Наприклад: 2019
//— 3, 2021 — 10, 2022 — 5

namespace Exercice3
{
    public struct Phone
    {
        public string PhoneName;
        public string PhoneManufactur;
        public float PhonePrice;
        public DateTime ReleaseDate;

        public override string ToString() => $"{PhoneName} {PhoneManufactur} : {PhonePrice} [{ReleaseDate}]";
    }

    public struct CountElement<T> where T : struct
    {
        public T Value;
        public int Count;
        public override string ToString() => $"{Value} : {Count}";
    }

    internal class Program
    {   
        static void Print<T>(IEnumerable<T> lst)
        {
            foreach (T t in lst)
                Console.WriteLine("{0}, ", t);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Phone[] phones = new Phone[]
            {
                new Phone { PhoneName = "Galaxy S23", PhoneManufactur = "Samsung", PhonePrice = 799.99f, ReleaseDate = new DateTime(2023, 2, 1) },
                new Phone { PhoneName = "iPhone 14", PhoneManufactur = "Apple", PhonePrice = 899.99f, ReleaseDate = new DateTime(2022, 9, 16) },
                new Phone { PhoneName = "Pixel 7", PhoneManufactur = "Google", PhonePrice = 599.99f, ReleaseDate = new DateTime(2022, 10, 6) },
                new Phone { PhoneName = "Samsung 11", PhoneManufactur = "Samsung", PhonePrice = 699.99f, ReleaseDate = new DateTime(2023, 1, 4) },
                new Phone { PhoneName = "Xperia 1 IV", PhoneManufactur = "Sony", PhonePrice = 1199.99f, ReleaseDate = new DateTime(2022, 5, 11) },
                new Phone { PhoneName = "Mi 13 Pro", PhoneManufactur = "Xiaomi", PhonePrice = 749.99f, ReleaseDate = new DateTime(2023, 2, 26) },
                new Phone { PhoneName = "Find X6", PhoneManufactur = "Xiaomi", PhonePrice = 899.99f, ReleaseDate = new DateTime(2023, 3, 20) },
                new Phone { PhoneName = "P60 Pro", PhoneManufactur = "Huawei", PhonePrice = 1099.99f, ReleaseDate = new DateTime(2023, 4, 7) },
                new Phone { PhoneName = "Vivo X90", PhoneManufactur = "Vivo", PhonePrice = 649.99f, ReleaseDate = new DateTime(2022, 11, 22) },
                new Phone { PhoneName = "Red Magic 8 Pro", PhoneManufactur = "Xiaomi", PhonePrice = 699.99f, ReleaseDate = new DateTime(2023, 1, 16) }
            };

            // Виведіть статистику за кількістю телефонів кожного
            //виробника. Наприклад: Sony — 3, Samsung — 4, Apple — 5 і т. д.
            var phones_stats = from products in (
                                    from p in phones
                                    group p by p.PhoneManufactur)
                               select new
                               {
                                   Value = products.First().PhoneManufactur,
                                   Count = products.Count()
                               };
            Print(phones_stats);

            // Виведіть статистику за кількістю моделей телефонів.
            //Наприклад: IPhone 13 — 12, IPhone 10 — 11, Galaxy S22 — 8.
            var phones_models = from products in (
                                    from p in phones
                                    group p by p.PhoneName)
                               select new
                               {
                                   Value = products.First().PhoneName,
                                   Count = products.Count()
                               };
            Print(phones_models);

            // Виведіть статистику телефонів за роками. Наприклад: 2019
            //— 3, 2021 — 10, 2022 — 5
            var phones_years = from products in (
                                    from p in phones
                                    group p by p.ReleaseDate.Year)
                                select new
                                {
                                    Value = products.First().ReleaseDate.Year,
                                    Count = products.Count()
                                };
            Print(phones_years);

            Console.ReadLine();
        }
    }
}
