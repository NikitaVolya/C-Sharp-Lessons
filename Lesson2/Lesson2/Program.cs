using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PrintArr(args);
            Console.ReadKey();
        }

        static void PrintArr(string[] arr) {
            foreach (var item in arr)
            {
                Console.Write(item);
                Console.Write(' ');
            }
        }
    }
}
