using System;
using System.IO;

//Завдання 1:
//Додаток дозволяє користувачеві переглядати вміст файлу.
//Користувач вводить шлях до файлу. Якщо файл існує, його вміст
//відображається на екрані. Якщо файл не існує, виведіть
//повідомлення про помилку.

namespace Exercice1
{
    internal class Program
    {
        static void ConsoleWriteFile(string filepatch)
        {
            try
            {   
                using (FileStream f = new FileStream(filepatch, FileMode.Open, FileAccess.Read))
                {
                    byte[] readBytes = new byte[f.Length];
                    f.Read(readBytes, 0, readBytes.Length);

                    foreach (byte b in readBytes)
                        Console.Write((char)b);
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("File not found");
            }
        }
        static void Main(string[] args)
        {
            string filepatch = Console.ReadLine();
            Program.ConsoleWriteFile(filepatch);
            Console.ReadLine();
        }
    }
}
