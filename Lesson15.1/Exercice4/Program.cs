using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercice4
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
        static public void SaveToXML(List<Album> objects, string file_name)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Album>));
            try
            {
                using (Stream fStream = File.Create(file_name))
                {
                    ser.Serialize(fStream, objects);
                }
                Console.WriteLine($"Album successfully saved to {file_name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to XML: {ex.Message}");
            }
        }

        static public List<Album> LoadFromXML(string file_name)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Album>));
            List<Album> rep = null;
            try
            {
                using (Stream fStream = File.OpenRead(file_name))
                {
                    rep = (List<Album>)ser.Deserialize(fStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rep;
        }

        static void Main(string[] args)
        {
            List<Album> albums = new List<Album>()
            {
                new Album
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
                },
                new Album
                {
                    AlbumName = "Echoes of Eternity",
                    AlbumAuthor = "Luna Harmony",
                    AlbumRelise = new DateTime(2018, 9, 25),
                    AlbumStudio = "DreamSound Records",
                    AlbumMusics = new List<Music>
                    {
                        new Music { MusicName = "Moonlight Serenade", MusicDuration = 4.3f, style = "Classical" },
                        new Music { MusicName = "Stars in the Night", MusicDuration = 5.1f, style = "Ambient" },
                        new Music { MusicName = "Eternal Echoes", MusicDuration = 3.8f, style = "Instrumental" },
                        new Music { MusicName = "Harmony of Dreams", MusicDuration = 4.5f, style = "New Age" },
                        new Music { MusicName = "Celestial Waves", MusicDuration = 6.2f, style = "Electronic" }
                    }
                }
            };


            SaveToXML(albums, "test.xml");

            List<Album> read_albums = LoadFromXML("test.xml");

            foreach (Album album in read_albums)
                Console.WriteLine(album);
            Console.ReadLine();

        }
    }
}
