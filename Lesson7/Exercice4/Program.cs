using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Створіть абстрактний базовий клас «Фігура» з аб-
//страктним методом для підрахунку площі. Створіть по-
//хідні класи: прямокутник, коло, прямокутний трикутник,
//трапеція зі своїми реалізаціями методу для підрахунку
//площі. Для перевірки, визначте масив посилань на аб-
//страктний клас, за яким надаються адреси різних об'єктів
//класів-нащадків.

namespace Exercice4
{
    abstract class Shape
    {
        public abstract float Perimeter();
    }

    class Circle : Shape
    {
        private float _radius;
        public Circle(float radius)
        {
            _radius = radius;
        }
        public override float Perimeter()
        {
            return 2 * 3.14159f * _radius;
        }
    }

    class Rectangle : Shape
    {
        private float _width;
        private float _height;
        public Rectangle(float width, float height)
        {
            _width = width;
            _height = height;
        }
        public override float Perimeter() 
        { 
            return _width * 2 + _height * 2;
        }
    }

    class RightTriangle : Shape
    {
        private float _a;
        private float _b;
        private float _c;
        public RightTriangle(float a, float b, float c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        public override float Perimeter()
        {
            return _a + _b + _c;
        }
    }
    class Trapeze : Shape
    {
        private float _a;
        private float _b;
        private float _c;
        private float _d;
        public Trapeze(float a, float b, float c, float d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }
        public override float Perimeter()
        {
            return _a + _b + _c + _d;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[] { 
                new Circle(4.0f), 
                new Rectangle(10, 3),
                new RightTriangle(10, 7, 8),
                new Trapeze(10, 2, 5, 11)
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Perimeter());
            }
            Console.ReadLine();
        }
    }
}
