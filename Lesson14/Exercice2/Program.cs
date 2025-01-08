using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2:
//Користувач вводить значення елементів масиву з клавіатури.
//Додаток надає можливість зберігати вміст масиву у файл.

namespace Exercice2
{
    internal class Program
    {
        static int[] InputIntArray()
        {
            List<int> list = new List<int>();

            while (true) {
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
            Console.WriteLine("Data saved!!!");
        }



        static void Main(string[] args)
        {
            int[] nums = InputIntArray();
            string filepatch = "data";

            foreach (int num in nums) 
                Console.Write(num + " ");

            SaveToFile(nums, filepatch);


            Console.ReadLine();
        }
    }
}
