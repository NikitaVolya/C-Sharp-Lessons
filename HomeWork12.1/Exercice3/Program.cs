using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3:
//Додайте до першого завдання реалізацію інтерфейсу IDisposable.
//Додайте до другого завдання реалізацію деструктора. Напишіть
//код для тестування нових можливостей.

namespace Exercice3
{
    class Piece : IDisposable
    {
        public string PieceName { get; set; }
        public string AuthorFullName { get; set; }
        public string PieceGenre { get; set; }
        public int PieceYear { get; set; }

        public Piece(string piece_name, string author_full_name, string piece_genre, int piece_year)
        {
            PieceName = piece_name;
            AuthorFullName = author_full_name;
            PieceGenre = piece_genre;
            PieceYear = piece_year;
        }

        public override string ToString()
        {
            return base.ToString() + $" | {PieceName}";
        }

        ~Piece()
        {
            Console.WriteLine(ToString() + " destructor!");
        }

        public void Dispose()
        {
            Console.WriteLine($"{ToString()} Deleted by user");
            GC.SuppressFinalize(this);
        }
    }

    enum ShopTypes
    {
        FOOD,
        ECONOMIC,
        CLOTHING,
        FOOTWEAR
    }

    class Shop : IDisposable
    {
        public string ShopName { get; set; }
        public string ShopAdresse { get; set; }
        public ShopTypes ShopType { get; set; }

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
        ~Shop()
        {
            Console.WriteLine(ToString() + " destructor!");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Piece piece = new Piece("Musical in Vegas", "xxx", "musical", 2020);
            piece.Dispose();
            Shop shop = new Shop("Mod Elina", "Normadie Kotans", ShopTypes.CLOTHING);
            Console.ReadLine();
        }
    }
}
