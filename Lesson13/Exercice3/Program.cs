using System;

//Завдання 3:
//Додайте до першого завдання реалізацію інтерфейсу IDisposable.
//Додайте до другого завдання реалізацію деструктора. Напишіть
//код для тестування нових можливостей.

namespace Exercice3
{
    class Film : IDisposable
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

        public void Dispose()
        {
            Console.WriteLine($"{ToString()} Cleaning by user");
            GC.SuppressFinalize(this);
        }
        ~Film()
        {
            Console.WriteLine($"{ToString()} Cleaning by GC");
            Console.ReadKey();
        }
    }

    class Performance : IDisposable
    {
        public string PerfomanceName { get; set; }
        public string TheaterName { get; set; }
        public string PerfomanceGenre { get; set; }
        public string PerfomanceDuration { get; set; }
        public string[] AcrtorNames { get; set; }

        public Performance(string perfomanceName, string theaterName, string perfomanceGenre, string perfomanceDuration, string[] acrtorNames)
        {
            PerfomanceName = perfomanceName;
            TheaterName = theaterName;
            PerfomanceGenre = perfomanceGenre;
            PerfomanceDuration = perfomanceDuration;
            AcrtorNames = acrtorNames;
        }

        public override string ToString()
        {
            return base.ToString() + " | " + PerfomanceName;
        }

        public void Dispose()
        {
            Console.WriteLine($"{ToString()} Cleaning by user");
            GC.SuppressFinalize(this);
        }

        ~Performance()
        {
            Console.WriteLine($"{ToString()} Cleaning by program");
            Console.ReadLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Film a = new Film("Shaw", "Paramaunt", "Horor", "2007", 120);
            Film b = new Film("The last of us", "HBO", "Adventure", "2023", 360);
            b.Dispose();
            Performance a_p = new Performance("Romeo and Juliet", "Theathr de Saint-Etienne", "Musical", "2h30", new string[] { "Thaïs", "Athanaël" });
            Performance b_p = new Performance("Ghost of opera", "Grand Lyon", "Musical", "3h30", new string[] { "Myrtale", "La charmeuse", "Dancer" });
            a_p.Dispose();
        }
    }
}
