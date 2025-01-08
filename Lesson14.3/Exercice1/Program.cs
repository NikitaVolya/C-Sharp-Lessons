using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1:
//Створіть користувацький тип «Телефон», який зберігатиме таку
//інформацію:
// Назва телефону
// Виробник
// Ціна
// Дата випуску

//Для масиву телефонів виконайте наступні завдання з
//використанням агрегатних операцій з LINQ:
// Підрахуйте кількість телефонів.
// Підрахуйте кількість телефонів з вартістю більше 100.
// Підрахуйте кількість телефонів з вартістю в діапазоні від 400 до 700.
// Підрахуйте кількість телефонів певного виробника.
// Знайдіть телефон з мінімальною вартістю.
// Знайдіть телефон з максимальною вартістю.
// Виведіть інформацію про найстарішу модель телефону.
// Виведіть інформацію про найновішу модель телефону.
// Знайдіть середню вартість телефону.

namespace Exercice1
{
    public struct Phone
    {
        public string PhoneName;
        public string PhoneManufactur;
        public float PhonePrice;
        public DateTime ReleaseDate;

        public override string ToString()
        {
            return $"{PhoneName} {PhoneManufactur} : {PhonePrice} [{ReleaseDate}]";
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Phone[] phones = new Phone[]
            {
                new Phone { PhoneName = "Galaxy S23", PhoneManufactur = "Samsung", PhonePrice = 799.99f, ReleaseDate = new DateTime(2023, 2, 1) },
                new Phone { PhoneName = "iPhone 14", PhoneManufactur = "Apple", PhonePrice = 899.99f, ReleaseDate = new DateTime(2022, 9, 16) },
                new Phone { PhoneName = "Pixel 7", PhoneManufactur = "Google", PhonePrice = 599.99f, ReleaseDate = new DateTime(2022, 10, 6) },
                new Phone { PhoneName = "OnePlus 11", PhoneManufactur = "OnePlus", PhonePrice = 699.99f, ReleaseDate = new DateTime(2023, 1, 4) },
                new Phone { PhoneName = "Xperia 1 IV", PhoneManufactur = "Sony", PhonePrice = 1199.99f, ReleaseDate = new DateTime(2022, 5, 11) },
                new Phone { PhoneName = "Mi 13 Pro", PhoneManufactur = "Xiaomi", PhonePrice = 749.99f, ReleaseDate = new DateTime(2023, 2, 26) },
                new Phone { PhoneName = "Find X6", PhoneManufactur = "Xiaomi", PhonePrice = 899.99f, ReleaseDate = new DateTime(2023, 3, 20) },
                new Phone { PhoneName = "P60 Pro", PhoneManufactur = "Huawei", PhonePrice = 1099.99f, ReleaseDate = new DateTime(2023, 4, 7) },
                new Phone { PhoneName = "Vivo X90", PhoneManufactur = "Vivo", PhonePrice = 649.99f, ReleaseDate = new DateTime(2022, 11, 22) },
                new Phone { PhoneName = "Red Magic 8 Pro", PhoneManufactur = "Xiaomi", PhonePrice = 699.99f, ReleaseDate = new DateTime(2023, 1, 16) }
            };

            // Підрахуйте кількість телефонів.
            int phones_count = (from p in phones select p).Count();
            Console.WriteLine(phones_count);

            // Підрахуйте кількість телефонів з вартістю більше 100.
            int phones_min100 = (from p in phones 
                                 where p.PhonePrice > 100.0f
                                 select p).Count();
            Console.WriteLine(phones_min100);

            // Підрахуйте кількість телефонів з вартістю в діапазоні від 400 до 700.
            int phones_among_400_700 = (from p in phones
                                        where p.PhonePrice >= 400.0f && p.PhonePrice <= 700.0f
                                        select p).Count();
            Console.WriteLine(phones_among_400_700);

            // Підрахуйте кількість телефонів певного виробника.
            int xiomi_phone = (from p in phones
                               where p.PhoneManufactur == "Xiaomi"
                               select p).Count();
            Console.WriteLine(xiomi_phone);

            // Знайдіть телефон з мінімальною вартістю.
            Phone phone_cheapest = (from p in phones
                                    orderby p.PhonePrice
                                    select p).First();
            Console.WriteLine(phone_cheapest);

            // Знайдіть телефон з максимальною вартістю.
            Phone most_expensive_phone = (from p in phones
                                          orderby p.PhonePrice descending
                                          select p).First();
            Console.WriteLine(most_expensive_phone);

            // Виведіть інформацію про найстарішу модель телефону.
            Phone oldest_phone = (from p in phones
                                  orderby p.ReleaseDate
                                  select p).First();
            Console.WriteLine(oldest_phone);


            // Виведіть інформацію про найновішу модель телефону.
            Phone news_phone = (from p in phones
                                orderby p.ReleaseDate descending
                                select p).First();
            Console.WriteLine(news_phone);

            // Знайдіть середню вартість телефону.
            float avg_price = (from p in phones
                               select p.PhonePrice).Average();
            Console.WriteLine(avg_price);

            Console.ReadLine();
        }
    }
}
