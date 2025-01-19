using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//Завдання 3:
//Додайте до попереднього завдання список статей з журналу.
//Потрібно зберігати наступну інформацію про кожну статтю:
//1.Назва статті.
//2.Кількість символів.
//3.Анонс статті.
//Змініть функціональність з попереднього завдання таким чином,
//щоб вона враховувала список статей.
//Вибір певного формату серіалізації потрібно зробити вам.
//Звертаємо вашу увагу, що вибір має бути обґрунтованим.

namespace Exercice3
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
            Magazine magazine =
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
                };


            Serializebject<Magazine>.SaveToXML(magazine, "test.xml");

            Magazine read_data = Serializebject<Magazine>.LoadFromXML("test.xml");
            Console.WriteLine(read_data);
            Console.ReadLine();
        }
    }
}
