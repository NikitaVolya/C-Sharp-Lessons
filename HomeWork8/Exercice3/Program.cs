using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть інтерфейс ICalc2. У ньому мають бути два
//методи:
//■ int CountDistinct() — повертає кількість унікальних
//значень у контейнері даних;
//■ int EqualToValue(int valueToCompare) — повертає кіль-
//кість значень, рівних valueToCompare.
//Клас, створений раніше у практичному завданні Array,
//має імплементувати інтерфейс ICalc2.
//Метод CountDistinct — повертає кількість унікальних
//значень в масив.
//Метод EqualToValue — повертає кількість елементів
//масиву, рівних valueToCompare.
//Напишіть код для тестування отриманої функціо-
//нальності.

namespace Exercice3
{
    interface ICalc
    {
        int Less(int value);

        int Greater(int value);
    }

    interface ICalc2
    {
        int CountDistinct();
        int EqualToValue(int value);
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

    class Array : IMath, IEnumerator, IEnumerable, ICalc, IOutput2, ICalc2
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

        public int CountDistinct()
        {
            int rep = 0;
            foreach (int element in _elements)
                if (EqualToValue(element) == 1)
                    rep++;
            return rep;
        }

        public int EqualToValue(int value)
        {
            int rep = 0;
            foreach (int element in _elements)
                if (element == value)
                    rep++;
            return rep;
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
            Array array = new Array(new int[]{ 2, 7, 2, 1, 3, 5, 1 });
            Console.WriteLine("CountDistinct: " + array.CountDistinct());
            Console.WriteLine("Equal to 1: " + array.EqualToValue(1));
            Console.Read();
        }
    }
}
