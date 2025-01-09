using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Завдання 3:
//Додайте до попереднього завдання список пісень в альбомі.
//Потрібно зберігати таку інформацію про кожну пісню:
//1.Назва пісні.
//2.Тривалість пісні.
//3.Стиль пісні.
//Змініть функціональність з попереднього завдання таким чином,
//щоб вона враховувала перелік пісень.
//Вибір певного формату серіалізації потрібно зробити вам.
//Звертаємо вашу увагу, що вибір має бути обґрунтованим.

namespace Exercice3
{
    public class Music
    {
        public string MusicName;
        public float MusicDuration;
        public string style;
    }
    public class Album
    {
        public string AlbumName { get; set; }
        public string AlbumAuthor { get; set; }
        public DateTime AlbumRelise { get; set; }
        public float AlbumDuration { get => AlbumMusics.Sum(x => x.MusicDuration); }
        public string AlbumStudio { get; set; }
        public List<Music> AlbumMusics { get; set; }

        public Album() { }

        public override string ToString()
        {
            string musics_text = "{";
            foreach (var music in AlbumMusics)
                musics_text += music.MusicName + " ";
            musics_text += '}';
            return $"{AlbumName}, {AlbumAuthor} ({AlbumStudio}) | {AlbumRelise} [{AlbumDuration}]\n{musics_text}";
        } 

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
            }
            catch (Exception ex)
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
            Album exampleAlbum = new Album
            {
                AlbumName = "The Greatest Hits",
                AlbumAuthor = "Various Artists",
                AlbumRelise = new DateTime(2021, 11, 15),
                AlbumStudio = "Universal Music",
                AlbumMusics = new List<Music>
                {
                    new Music { MusicName = "Hit Song 1", MusicDuration = 3.5f, style = "Pop" },
                    new Music { MusicName = "Hit Song 2", MusicDuration = 4.2f, style = "Rock" },
                    new Music { MusicName = "Hit Song 3", MusicDuration = 5.0f, style = "Jazz" },
                    new Music { MusicName = "Hit Song 4", MusicDuration = 2.8f, style = "Electronic" }
                }
            };

            exampleAlbum.SaveToXML("test.xml");
            Album load_album = Album.LoadFromXML("test.xml");
            Console.WriteLine(load_album);

            Console.Read();
        }
    }
}
