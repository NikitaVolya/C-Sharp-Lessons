using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Завдання 2:
//Створіть програму для роботи з інформацією про музичний
//альбом, яка зберігатиме таку інформацію:
//1.Назва альбому.
//2.Назва виконавця.
//3.Рік випуску.
//4.Тривалість.
//5.Студія звукозапису.
//Програма має бути з такою функціональністю:
//1.Введення інформації про альбом.
//2. Виведення інформації про альбом.
//3. Серіалізація альбому.
//4. Збереження серіалізованого альбому у файл.
//5. Завантаження серіалізованого альбому з файлу. Після
//завантаження потрібно виконати десеріалізацію альбому.
//Вибір певного формату серіалізації потрібно зробити вам.
//Звертаємо вашу увагу, що вибір має бути обґрунтованим.

namespace Exercice2
{
    public class Album
    {
        public string AlbumName { get; set; }
        public string AlbumAuthor { get; set; }
        public DateTime AlbumRelise { get; set; }
        public float AlbumDuration { get; set; }
        public string AlbumStudio { get; set; }

        public Album() { }

        public override string ToString() => $"{AlbumName}, {AlbumAuthor} ({AlbumStudio}) | {AlbumRelise} [{AlbumDuration}]";

        public void SaveToXML(string file_name)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Album));
            try
            {
                using (Stream fStream = File.Create(file_name))
                {
                    ser.Serialize(fStream, this);
                }
                Console.WriteLine($"Album successfully saved to {file_name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to XML: {ex.Message}");
            }
        }

        static public Album LoadFromXML(string file_name)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Album));
            Album rep = null;
            try
            {
                using (Stream fStream = File.OpenRead(file_name))
                {
                    rep = (Album)ser.Deserialize(fStream);
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rep;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Album randomAlbum = new Album
            {
                AlbumName = "Random Access Memories",
                AlbumAuthor = "Daft Punk",
                AlbumRelise = new DateTime(2013, 5, 17),
                AlbumDuration = 74.0f, // в минутах
                AlbumStudio = "Columbia Records"
            };

            randomAlbum.SaveToXML("test.xml");

            Album read_object = Album.LoadFromXML("test.xml");
            Console.WriteLine(read_object);
            Console.ReadLine(); 
        }
    }
}
