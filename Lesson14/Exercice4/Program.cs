using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 4:
//Додаток генерує випадковим чином 10000 цілих чисел.
//Збережіть парні числа в один файл, непарні – в інший. За
//підсумками роботи додатка потрібно відобразити статистику на
//екрані.

namespace Exercice4
{
    internal class Program
    {
        static int[] GenarateNumbers(int size)
        {
            int[] numbers = new int[size];
            Random rd = new Random();
            for (int i = 0; i < size; i++)
                numbers[i] = rd.Next(1, size);

            return numbers;
        }

        static void SaveToFile(int[] values, string filepatch)
        {
            using (FileStream fs = new FileStream(filepatch, FileMode.Create))
            using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
            {
                foreach (int i in values)
                    bw.Write(i);
                Console.WriteLine($"Save {fs.Length / 4} numbers");
            }
        }

        static int[] LoadFromFile(string filename)
        {
            int[] rep;

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                {
                    rep = new int[fs.Length / 4];
                    for (int i = 0; i < rep.Length; i++)
                        rep[i] = br.ReadInt32();
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                rep = new int[0];
            }
            return rep;
        }

        static int[] Filter(int[] values, Predicate<int> predicate) 
        {
            List<int> list = new List<int>();
            foreach (int i in values) 
                if (predicate(i))
                    list.Add(i);
            return list.ToArray();
        }

        static void Main(string[] args)
        {
            int nums_size = 10000;
            int[] nums = GenarateNumbers(nums_size);

            SaveToFile(Filter(nums, (x) => x % 2 == 0), "EvenData");
            SaveToFile(Filter(nums, (x) => x % 2 != 0), "OddData");
            Console.ReadLine();
        }
    }
}
