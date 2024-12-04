using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть набір методів:
//■ Метод відображення поточного часу;
//■ Метод відображення поточної дати;
//■ Метод відображення поточного дня тижня;
//■ Метод для підрахунку площі трикутника;
//■ Метод для підрахунку площі прямокутника.
//Для реалізації проєкту використовуйте делегати: Ac
//tion, Predicate, Func.

namespace Exercice2
{
    abstract class Shape
    {
        public abstract float Perimeter();
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
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Action<DateTime>> timeMthods = new List<Action<DateTime>> 
            { 
                (DateTime time) => Console.WriteLine(time.ToString("T")),
                (DateTime time) => Console.WriteLine(time.ToString("d")),
                (DateTime time) => Console.WriteLine(time.ToString("ddd"))
            };
            List<Func<Shape, float>> shapeMethods = new List<Func<Shape, float>>
            {
                (Shape shape) => (shape as Rectangle).Perimeter(),
                (Shape shape) => (shape as RightTriangle).Perimeter()
            };

            DateTime now = DateTime.Now;
            foreach (Action<DateTime> action in timeMthods)
                action(now);

            Rectangle a = new Rectangle(10, 4);
            RightTriangle b = new RightTriangle(4, 5, 3);

            Console.WriteLine(shapeMethods[0](a));
            Console.WriteLine(shapeMethods[1](b));

            Console.ReadLine();
        }
    }
}
