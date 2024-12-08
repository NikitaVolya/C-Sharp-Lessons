using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2:
//Створіть клас «Вистава», який має зберігати таку інформацію:
// назва спектаклю;
// назва театру;
// жанр;
// тривалість;
// список акторів.
//Реалізуйте у класі методи та властивості, необхідні для
//функціонування класу.
//Клас має реалізовувати інтерфейс IDisposable. Напишіть код для
//тестування функціональності класу.
//Напишіть код для виклику методу Dispose.

namespace Exercice2
{
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
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Performance a = new Performance("Romeo and Juliet", "Theathr de Saint-Etienne", "Musical", "2h30", new string[] { "Thaïs", "Athanaël" });
            Performance b = new Performance("Ghost of opera", "Grand Lyon", "Musical", "3h30", new string[] { "Myrtale", "La charmeuse", "Dancer" });
            a.Dispose();
            Console.ReadLine();
        }
    }
}
