using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length: ");
            int length = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter symbl: ");
            string symbl = Console.ReadLine();

            Console.Write("Draw a line vertically? If not, horizontally [y / n]: ");
            string rep = Console.ReadLine();
            bool vertically;
            switch (rep)
            {
                case "yes": case "y":
                    vertically = true; 
                    break;
                case "no": case "n":
                    vertically = false;
                    break;
                default:
                    Console.WriteLine("Error");
                    return;
            }

            for (int i = 0; i < length; i++)
            {
                Console.Write(symbl);
                if (vertically)
                    Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
