using System;

//Створіть клас «Фільм», який має зберігати таку інформацію:
// назва фільму;
// назва кіностудії;
// жанр;
// тривалість;
// рік.
//Реалізуйте у класі методи та властивості, необхідні для
//функціонування класу.
//Додайте до класу деструктор. Напишіть код для тестування
//функціональності класу.
//Напишіть код для деструктора.

namespace Exercice1
{
    class Film
    {
        public string FilmName { get; set; }
        public string FilmStudio { get; set; }
        public string FilmGeners { get; set; }
        public string FilmYear { get; set; }
        public int FilmDuration { get; set; }

        public Film(string filmName, string filmStudio, string filmGeners, string filmYear, int filmDuration)
        {
            FilmName = filmName;
            FilmStudio = filmStudio;
            FilmGeners = filmGeners;
            FilmYear = filmYear;
            FilmDuration = filmDuration;
        }
        ~Film() 
        {
            Console.WriteLine($"{ToString()} Cleaning by GC");
            Console.ReadKey();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Film a = new Film("Shaw", "Paramaunt", "Horor", "2007", 120);

        }
    }
}
