using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Завдання 2:
//Створіть програму для роботи з інформацією про журнал, в якій
//зберігатиметься таку інформація:
//1.Назва журналу.
//2.Назва видавництва.
//3.Дата видання.
//4.Кількість сторінок.

//Програма має бути з такою функціональністю:
//1.Введення інформації про журнал.
//2. Виведення інформації про журнал.
//3. Серіалізація журналу.
//4. Збереження серіалізованого журналу у файл.
//5.Завантаження серіалізованого журналу з файлу. Після
//завантаження потрібно виконати десеріалізацію журналу.
//Вибір певного формату серіалізації потрібно зробити вам.
//Звертаємо вашу увагу, що вибір має бути обґрунтованим.

namespace Exercice2
{

    public class Magazine
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Relise { get; set; }
        public UInt32 PageNumber { get; set; }

        public Magazine()
        {
            Name = "";
            Author = "";
            Relise = DateTime.MinValue;
            PageNumber = 0;
        }

        public override string ToString() => $"{Name}, {Author} ({PageNumber}) [{Relise}]";
    }

    class Serializebject<T> where T : class
    {
        static public void SaveToXML(T obj, string file_name)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (Stream stream = File.Create("test.xml"))
                {
                    xmlSerializer.Serialize(stream, obj);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static public T LoadFromXML(string file_name)
        {
            T rep = null;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (Stream stream = File.OpenRead(file_name))
                {
                    rep = (T)xmlSerializer.Deserialize(stream);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return rep;
        }
    }
        
    internal class Program
    {
        static void Main(string[] args)
        {
            Magazine magazine = new Magazine();

            Console.Write("Magazine name: ");
            magazine.Name = Console.ReadLine();

            Console.Write("Magazine Author: ");
            magazine.Author = Console.ReadLine();

            Console.Write("Magazine Relise [day/month/year]: ");
            magazine.Relise = DateTime.Parse(Console.ReadLine());

            Console.Write("Page number: ");
            magazine.PageNumber = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine(magazine);

            Serializebject<Magazine>.SaveToXML(magazine, "test.xml");

            Magazine read_magazine = Serializebject<Magazine>.LoadFromXML("test.xml");
            Console.WriteLine(read_magazine);

            Console.ReadLine();
        }
    }
}
