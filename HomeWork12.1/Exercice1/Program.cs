using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1:
//Створіть клас «П'єса», який має зберігати таку інформацію:
// назва п'єси;
// П.І.Б. автора;
// жанр;
// рік.
//Реалізуйте у класі методи та властивості, необхідні для
//функціонування класу.
//Додайте до класу деструктор. Напишіть код для тестування
//функціональності класу.
//Напишіть код для деструктора.

namespace Exercice1
{
    class Piece
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
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Piece piece = new Piece("Musical in Vegas", "xxx", "musical", 2020);
            Console.ReadLine();
        }
    }
}
