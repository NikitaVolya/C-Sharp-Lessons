using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2:
//Додайте до першого завдання нову функціональність:
// Виведіть п'ять найдорожчих телефонів.
// Виведіть п'ять найдешевших телефонів.
// Виведіть три найстаріші моделі телефонів.
// Виведіть три найновіші моделі телефонів.
//Для реалізації завдання використовуйте сімейство методів Skip,
//Take.

namespace Exercice2
{
    public struct Phone
    {
        public string PhoneName;
        public string PhoneManufactur;
        public float PhonePrice;
        public DateTime ReleaseDate;

        public override string ToString() => $"{PhoneName} {PhoneManufactur} : {PhonePrice} [{ReleaseDate}]";
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


            // Виведіть п'ять найдорожчих телефонів.
            var most_expensive_phones = (from p in phones
                                    orderby p.PhonePrice descending
                                    select p).Take(5);
            Print(most_expensive_phones);

            // Виведіть п'ять найдешевших телефонів.
            var phones_cheapests = (from p in phones
                                         orderby p.PhonePrice
                                         select p).Take(5);
            Print(phones_cheapests);


            // Виведіть три найстаріші моделі телефонів.
            var oldes_phones = (from p in phones
                                orderby p.ReleaseDate
                                select p).Take(3);
            Print(oldes_phones);

            // Виведіть три найновіші моделі телефонів.
            var news_phones = ( from p in phones
                                orderby p.ReleaseDate descending
                                select p).Take(3);
            Print(news_phones);

            Console.ReadLine();
        }
    }
}
