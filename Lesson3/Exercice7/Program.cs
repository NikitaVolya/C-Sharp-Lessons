using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exercice7
{
    class Matrix
    {
        private int[,] data;
        public Matrix(int[,] values)
        {
            Values = values;
        }

        public int[,] Values
        {
            get
            {
                int[,] rep = new int[data.GetLength(0), data.GetLength(1)];
                for (int i = 0; i < data.GetLength(0); i++)
                    for (int j = 0; j < data.GetLength(1); j++)
                        rep[i, j] = data[i, j];
                return rep;
            }
            set
            {
                data = new int[value.GetLength(0), value.GetLength(1)];
                for (int i = 0; i < value.GetLength(0); i++)
                    for (int j = 0; j < value.GetLength(1); j++)
                        data[i, j] = value[i, j];
            }
        }
        public int filter(Func<int, int, bool> func)
        {
            int rep = data[0, 0];
            for (int i = 0; i < data.GetLength(0); i++)
                for (int j = 0; j < data.GetLength(1); j++)
                    if (func(data[i, j], rep))
                        rep = data[i, j];
            return rep;
        }
        public int Max
        {
            get
            {
                Func<int, int, bool> func = (a, b) => a > b;
                return filter(func);
            }
        }
        public int Min
        {
            get
            {
                Func<int, int, bool> func = (a, b) => a < b;
                return filter(func);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix ( new int[,]{ { 1, 2 }, { 3, 4 } });
            Console.WriteLine($"Max: {a.Max}\nMin: {a.Min}");
            Console.ReadLine();
        }
    }
}
