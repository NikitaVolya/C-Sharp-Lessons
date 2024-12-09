using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//авдання 2:
//Створіть клас «Магазин», який має зберігати таку інформацію:
// назва магазину;
// адреса магазину;
// тип магазину:
//o продовольчий,
//o господарський,
//o одяг,
//o взуття.
//Реалізуйте у класі методи та властивості, необхідні для
//функціонування класу.
//Клас має реалізовувати інтерфейс IDisposable. Напишіть код для
//тестування функціональності класу.
//Напишіть код для виклику методу Dispose.

namespace Exercice2
{
    enum ShopTypes {
        FOOD,
        ECONOMIC,
        CLOTHING,
        FOOTWEAR
    }
    class Shop : IDisposable
    {
        public string ShopName {get; set;}
        public string ShopAdresse { get; set;}
        public ShopTypes ShopType { get; set;}

        public Shop(string shopName, string shopAdresse, ShopTypes shopType)
        {
            ShopName = shopName;
            ShopAdresse = shopAdresse;
            ShopType = shopType;
        }

        public override string ToString() => base.ToString() + $" | {ShopName}";

        public void Dispose()
        {
            Console.WriteLine($"{ToString()} Deleted by user");
            GC.SuppressFinalize(this);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop("Mod Elina", "Normadie Kotans", ShopTypes.CLOTHING);
            shop.Dispose();
            Console.ReadLine();
        }
    }
}
