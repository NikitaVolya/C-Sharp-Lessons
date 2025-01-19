using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Завдання 4:
//Додайте до попереднього завдання можливість створення
//масиву журналів.
//Змініть функціональність з другого завдання таким чином, щоб
//вона враховувала масив журналів.
//Вибір певного формату серіалізації потрібно зробити вам.
//Звертаємо вашу увагу, що вибір має бути обґрунтованим.

namespace Exercice4
{
    public class Article
    {
        public string ArticleName { get; set; }
        public UInt32 CharactersNumber { get; set; }
        public string ArticleAnnouncement { get; set; }

        public override string ToString() => $"{ArticleName} {ArticleAnnouncement} [{CharactersNumber}]";
    }

    public class Magazine
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Relise { get; set; }
        public UInt32 PageNumber { get; set; }

        public List<Article> articles { get; set; }

        public Magazine()
        {
            Name = "";
            Author = "";
            Relise = DateTime.MinValue;
            PageNumber = 0;
            articles = new List<Article>();
        }

        public override string ToString()
        {
            string articles_text = "";
            foreach (var article in articles)
                articles_text += article.ToString() + "\n";
            return $"{Name}, {Author} ({PageNumber}) [{Relise}]\n{articles_text}";
        }
    }

    class Serializebject<T> where T : class
    {
        static public void SaveToXML(T obj, string file_name)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (Stream stream = File.Create(file_name))
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

        static public void SaveListToXML(List<T> objs, string file_name) => Serializebject<List<T>>.SaveToXML(objs, file_name);
        static public List<T> LoadListFromXML(string file_name) => Serializebject<List<T>>.LoadFromXML(file_name);
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Magazine> magazines = new List<Magazine>
            {
                new Magazine
                {
                    Name = "Science Today",
                    Author = "Dr. Emily Watson",
                    Relise = new DateTime(2023, 4, 15),
                    PageNumber = 120,
                    articles = new List<Article>
                    {
                        new Article
                        {
                            ArticleName = "The Future of Quantum Physics",
                            CharactersNumber = 5000,
                            ArticleAnnouncement = "Exploring the advancements in quantum computing."
                        },
                        new Article
                        {
                            ArticleName = "Climate Change: The Real Impact",
                            CharactersNumber = 4000,
                            ArticleAnnouncement = "Understanding how global warming affects our planet."
                        }
                    }
                },
                new Magazine
                {
                    Name = "Traveler's Paradise",
                    Author = "Michael Brown",
                    Relise = new DateTime(2022, 11, 5),
                    PageNumber = 85,
                    articles = new List<Article>
                    {
                        new Article
                        {
                            ArticleName = "Top 10 Beaches to Visit",
                            CharactersNumber = 3500,
                            ArticleAnnouncement = "Discover the most breathtaking beaches around the world."
                        },
                        new Article
                        {
                            ArticleName = "Hidden Gems in Europe",
                            CharactersNumber = 4200,
                            ArticleAnnouncement = "Unveiling lesser-known destinations in Europe."
                        }
                    }
                },
                new Magazine
                {
                    Name = "Tech Innovators",
                    Author = "Sophia Martinez",
                    Relise = new DateTime(2024, 6, 20),
                    PageNumber = 100,
                    articles = new List<Article>
                    {
                        new Article
                        {
                            ArticleName = "AI in Everyday Life",
                            CharactersNumber = 4800,
                            ArticleAnnouncement = "How artificial intelligence is shaping our daily routines."
                        },
                        new Article
                        {
                            ArticleName = "The Rise of Electric Vehicles",
                            CharactersNumber = 5200,
                            ArticleAnnouncement = "Examining the evolution of the electric car industry."
                        }
                    }
                }
            };

            Serializebject<Magazine>.SaveListToXML(magazines, "test.xml");

            List<Magazine> read_data = Serializebject<Magazine>.LoadListFromXML("test.xml");
            foreach (var magazine in read_data)
                Console.WriteLine(magazine);
            Console.ReadLine();
        }
    }
}
