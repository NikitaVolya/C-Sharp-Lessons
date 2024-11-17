using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//В одному з попередніх практичних завдань ви ство-
//рювали клас «Матриця». Виконайте перевантаження +
//(для додавання матриць), – (для віднімання матриць). *
//(множення матриць одна на одну, множення матриці на
//число), == (перевірка матриць на рівність), != і Equals.
//Використовуйте механізм властивостей полів класу і ме-
//ханізм індексаторів.

namespace Exercice2
{
    class Matrix
    {
        private int[,] data;
        public Matrix(int[,] values)
        {
            Values = values;
        }

        public int Height { get { return data.GetLength(0); } }
        public int Width { get { return data.GetLength(1); } }
        public int[,] Values
        {
            get
            {
                int[,] rep = new int[Height, Width];
                for (int i = 0; i < Height; i++)
                    for (int j = 0; j < Width; j++)
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

        public int Filter(Func<int, int, bool> func)
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
                return Filter(func);
            }
        }
        public int Min
        {
            get
            {
                Func<int, int, bool> func = (a, b) => a < b;
                return Filter(func);
            }
        }
        public int this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] |= value; }
        }

        public static bool operator ==(Matrix a, Matrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
                return false;

            for (int i = 0; i <  a.Height; i++) 
                for (int j = 0; j <  a.Width; j++)
                    if (a.data[i, j] != b.data[i, j])
                        return false;
            return true;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
                throw new ArgumentException("The matrix must be of same size");

            Matrix tmp = a;
            for (int i = 0; i < b.Height; i++)
                for (int j = 0; j < b.Width; j++)
                    tmp.data[i, j] += b.data[i, j];
            return tmp;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
                throw new ArgumentException("The matrix must be of same size");

            Matrix tmp = a;
            for (int i = 0; i < b.Height; i++)
                for (int j = 0; j < b.Width; j++)
                    tmp.data[i, j] -= b.data[i, j];
            return tmp;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Width != b.Height)
                throw new ArgumentException("Error");

            int[,] newTable = new int[a.Height, b.Width];

            for (int i = 0; i < a.Height; i++ )
                for (int j = 0; j < b.Width; j++)
                {
                    newTable[i, j] = 0;
                    for (int c = 0; c < a.Width; c++)
                        newTable[i, j] += a.data[i, c] * b.data[c, j];
                }

            return new Matrix(newTable);
        }
        
        public override string ToString()
        {
            string rep = "";
            for (int i = 0; i < Height; i++)
            {
                rep += "| ";
                for (int j = 0; j < Width; j++)
                    rep += data[i, j] + " ";
                rep += "|";
                if (i != Height - 1)
                    rep += '\n';
            }
            return rep;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            Matrix b = new Matrix(new int[,] { { 0, 2 }, { 1, 3} });
            Matrix c = new Matrix(new int[,] { { 3 }, { 1 } });

            Console.WriteLine(a * b);
            Console.WriteLine((a * b)[0, 0]);
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * c);
            Console.ReadLine();
        }
    }
}
