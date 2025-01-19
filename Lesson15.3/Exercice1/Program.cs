using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1:
//Створіть додаток для пошуку інформації у файлі за текстовим шаблоном. Варіанти підтримуваних шаблонів:
// Відобразити всі речення, в яких міститься хоча б одна маленька, англійська літера.
// Відобразити всі речення, в яких міститься хоча б одна цифра.
// Відобразити всі речення, в яких міститься хоча б одна велика, англійська літера.
//В програмі налаштуйте логування з використанням NLog.

namespace Exercice1
{
    public class FileParser
    {
        private string[] data;

        public void LoadFile(string file_path)
        {
            try
            {
                string rep = File.ReadAllText(file_path);
                data = rep.Split(new char[] { '.' });
            }
            catch { 
                data = new string[0];
                Program.logger.Error("File open fail");
            }
        }

        public bool HaveLowerLetter(string line)
        {
            for (char i = 'a'; i < 'z'; i++)
                if (line.Any(e => e == i))
                    return true;
            return false;
        }
        public bool HaveUpperLetter(string line)
        {
            for (char i = 'A'; i < 'Z'; i++)
                if (line.Any(e => e == i))
                    return true;
            return false;
        }
        public bool HaveNumber(string line)
        {
            for (char c = '0'; c < '9'; c++)
                if (line.Any( e => e == c))
                    return true;
            return false;
        }

        public string[] GetLines(Predicate<string> predicate)
        {
            Program.logger.Info($"Start filter line: {predicate.ToString()}");
            List<string> rep = new List<string>();
            foreach (string line in data) 
                if (predicate(line)) 
                    rep.Add(line);
            return rep.ToArray();
        }

        public string[] GetLinesWithLowerLetter() => data.Where(l => HaveLowerLetter(l)).ToArray();
        public string[] GetLinesWithUpperLetter() => data.Where(l => HaveUpperLetter(l)).ToArray();
        public string[] GetLinesWithNumber() => data.Where(l => HaveNumber(l)).ToArray();
    }

    internal class Program
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            FileParser parser = new FileParser();
            parser.LoadFile("test.txt");

            foreach (var line in parser.GetLinesWithLowerLetter())
                Console.WriteLine(line);

            foreach (var line in parser.GetLinesWithUpperLetter())
                Console.WriteLine(line);

            foreach (var line in parser.GetLinesWithNumber())
                Console.WriteLine(line);

            Console.ReadLine();
        }
    }
}
