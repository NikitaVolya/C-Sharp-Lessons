using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть інтерфейс IOutput2. У ньому мають бути
//два методи:
//■ void ShowEven() — відображає парні значення контей-
//нера з даними;
//■ void ShowOdd() — відображає непарні значення кон-
//тейнера з даними.
//Клас, створений раніше у практичному завданні Array,
//має імплементувати інтерфейс IOutput2.
//Метод ShowEven — відображає парні значення з
//ма сиву.
//Метод ShowOdd — відображає непарні значення
//ма сиву.
//Напишіть код для тестування отриманої функціо-
//нальності.

namespace Exercice2
{

    interface ICalc
    {
        int Less(int value);

        int Greater(int value);
    }

    interface IMath
    {
        int Max();
        int Min();
        int Sum();
        float Avg();
        bool Search(int value);
    }

    interface IOutput2
    {
        void ShowEven();
        void ShowOdd();
    }

    class Array : IMath, IEnumerator, IEnumerable, ICalc, IOutput2
    {
        private int[] _elements;
        private int _position = -1;

        public int Length { get => _elements.Length; }
        public Array(int[] elements)
        {
            _elements = new int[elements.Length];
            elements.CopyTo(_elements, 0);
        }

        public int Max()
        {
            int max_number = _elements[0];
            foreach (int element in _elements)
            {
                if (element > max_number)
                    max_number = element;
            }
            return max_number;
        }
        public int Min()
        {
            int min_number = _elements[0];
            foreach (int element in _elements)
            {
                if (element < min_number)
                    min_number = element;
            }
            return min_number;
        }
        public int Sum()
        {
            int sum = 0;
            foreach (int element in _elements)
            {
                sum += element;
            }
            return sum;
        }
        public float Avg()
        {
            return (float)Sum() / Length;
        }
        public bool Search(int value)
        {
            foreach (int element in _elements)
                if (element == value)
                    return true;
            return false;
        }

        public int Less(int value)
        {
            int rep = 0;
            foreach (int i in _elements)
                if (i < value)
                    rep++;
            return rep;
        }
        public int Greater(int value)
        {
            int rep = 0;
            foreach (int i in _elements)
                if (i > value)
                    rep++;
            return rep;
        }

        public void ShowEven()
        {
            foreach (int element in _elements)
                if (element % 2 == 0)
                    Console.Write(element + " ");
            Console.WriteLine();
        }
        public void ShowOdd()
        {
            foreach (int element in _elements)
                if (element % 2 != 0)
                    Console.Write(element + " ");
            Console.WriteLine();
        }

        public int this[int index] { get => _elements[index]; set => _elements[index] = value; }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)_elements.GetEnumerator();
        }
        public bool MoveNext()
        {
            _position++;
            return (_position < _elements.Length);
        }
        public void Reset()
        {
            _position = -1;
        }
        public object Current
        {
            get { return _elements[_position]; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array(new int[] { 10, 5, 3, 4, 11, 65, 25, 14 });
            array.ShowEven();
            array.ShowOdd();
            Console.Read();
        }
    }
}
