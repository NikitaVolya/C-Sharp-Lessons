using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//Завдання 3:
//Додайте до другого завдання можливість завантажувати масив
//із файлу.

namespace Exercice3
{ 
    internal class Program
    {
        static int[] InputIntArray()
        {
            List<int> list = new List<int>();

            while (true)
            {
                try
                {
                    string num = Console.ReadLine();
                    if (num == "")
                        break;
                    list.Add(Convert.ToInt32(num));
                }
                catch (Exception)
                {
                    break;
                }
            }

            return list.ToArray();
        }

        static void SaveToFile(int[] values, string filepatch)
        {
            using (FileStream fs = new FileStream(filepatch, FileMode.Create))
            using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
            {
                foreach (int i in values)
                    bw.Write(i);
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

        static void Main(string[] args)
        {
            int[] nums = InputIntArray();
            string filepatch = "data";

            foreach (int num in nums)
                Console.Write(num + " ");
            Console.WriteLine();

            SaveToFile(nums, filepatch);
            int[] nums_from_file = LoadFromFile(filepatch);

            foreach (int num in nums_from_file)
                Console.Write(num + " ");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
