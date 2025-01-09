using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

//Завдання 1:
//Створіть програму для роботи з масивом цілих чисел з такою
//функціональністю:
//1.Введення масиву цілих чисел з клавіатури.
//2. Фільтр масиву. Залежно від вибору користувача, прибираємо прості числа або числа Фібоначчі.
//3. Серіалізація масиву.
//4. Збереження серіалізованого масиву у файл.
//5. Завантаження серіалізованого масиву з файлу. Після завантаження потрібно виконати десеріалізацію.
//Вибір певного формату серіалізації потрібно зробити вам.
//Звертаємо вашу увагу, що вибір має бути обґрунтованим.

namespace Exercice1
{
    [Serializable]
    class SerializableList<T> where T : struct
    {
        private List<T> _data;

        public SerializableList()
        {
            _data = new List<T>();
        }
        public SerializableList(T[] data)
        {
            _data = new List<T>(data);
        }

        public void Add(T item)
        {
            _data.Add(item);
        }

        public override string ToString()
        {
            string rep = "";
            foreach (T item in _data)
                rep += item.ToString();
            return rep;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SerializableList<int> nums = new SerializableList<int>(new int[] { 2, 3, 4, 5, 1});

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream fStream = File.Create("nums.bin"))
            {
                binaryFormatter.Serialize(fStream, nums);
            }

            Console.WriteLine("BinarySerialize OK");

            SerializableList<int> out_nunms= null;
            using (Stream fStream = File.OpenRead("nums.bin"))
            {
                out_nunms = (SerializableList<int>)binaryFormatter.Deserialize(fStream);
            }
            Console.WriteLine(out_nunms);
            Console.ReadLine();
        }
    }
}
