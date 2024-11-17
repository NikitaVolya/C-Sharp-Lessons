using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть класи для відображення різних геометричних
//фігур: трикутника, прямокутника, квадрата. Використо-
//вуйте механізми просторів імен.


namespace Triangle
{

    class Figure
    {
        private int[] _sides;
        public int[] Sides
        {
            set
            {
                
                if (value.Length != 3)
                    throw new ArgumentException("Size of sides is 3");

                foreach (int number in value)
                    if (number <= 0)
                        throw new ArgumentException();
                if (_sides == null)
                    _sides = new int[3];
                value.CopyTo(_sides, 0);
            }
            get
            {
                int[] rep = new int[3];
                _sides.CopyTo(rep, 0);
                return rep;
            }
        }
        public Figure()
        {
            _sides = null;
        }
        public Figure(int[] pSides)
        {
            Sides = pSides;
        }

        public int Perimetr
        {
            get
            {
                if (_sides == null)
                    return 0;
                return _sides[0] + _sides[1] + _sides[2];
            }
        }
    }    
}

namespace Square
{
    class Figure
    {
        private int _side;
        
        public int Side
        {
            get { return _side; }
            set { 
                if (value <= 0)
                    throw new ArgumentException();
                _side = value; 
            }
        }

        public Figure() { _side = 0; }
        public Figure(int sides)
        {
            Side = sides;
        }

        public int Perimetr
        {
            get
            {
                return _side * 4;
            }
        }
    }
}

namespace Rectangle
{
    class Figure
    {
        private int[] _sides;
        public int[] Sides
        {
            get
            {
                int[] result = new int[2];
                _sides.CopyTo(result, 0);
                return result;
            }
            set
            {
                if (value.Length != 2)
                    throw new ArgumentException();
                foreach (int number in value)
                    if (number <= 0)
                        throw new ArgumentException();
                if (_sides == null)
                    _sides = new int[2];
                value.CopyTo(_sides, 0);
            }

        }

        public int Perimetr
        {
            get
            {
                if (_sides == null)
                    return 0;
                return _sides[0] * 2 + _sides[1] * 2;
            }
        }

        public Figure() { _sides = null; }
        public Figure(int[] sides)
        {
            Sides = sides;
        }
    }
}

namespace Exercice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle.Figure a = new Triangle.Figure(new int[] {2, 3, 4 });
            Square.Figure b = new Square.Figure(4);
            Rectangle.Figure c = new Rectangle.Figure(new int[] { 10, 2});
            Console.WriteLine(a.Perimetr);
            Console.WriteLine(b.Perimetr);
            Console.WriteLine(c.Perimetr);
            Console.Read();
        }
    }
}
