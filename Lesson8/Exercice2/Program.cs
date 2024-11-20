using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створіть інтерфейс IMath. У ньому мають бути чотири
//методи:
//■ int Max() — повертає максимум;
//■ int Min() — повертає мінімум; Практичне завдання
//■ float Avg() — повертає середньоарифметичне;
//■ bool Search(int valueToSearch) — шукає valueSearch
//всередині контейнера даних. Повертає true, якщо
//значення знайдено. Повертає false, якщо значення
//не знайдено.
//Клас, створений у першому завданні Array, має імпле-
//ментувати інтерфейс IMath.
//Метод Max — повертає максимум серед елементів
//масиву.
//Метод Min — повертає мінімум серед елементів масиву.
//Метод Avg — повертає середньоарифметичне серед
//елементів масиву.
//Метод Search — шукає значення всередині масиву.
//Повертає true, якщо значення знайдено. Повертає false,
//якщо значення не знайдено.
//Напишіть код для тестування отриманої функціональ-
//ності

namespace Exercice2
{

    interface IMath
    {
        int Max();
        int Min();
        int Sum();
        float Avg();
        bool Search(int value);
    }
   
    class Array : IMath, IEnumerator, IEnumerable
    {
        private int[] _elements;
        private int position = -1;

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
                if (element <  min_number)
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
            return (float) Sum() / Length;
        }
        public bool Search(int value)
        {
            foreach (int element in _elements)
                if (element == value)
                    return true;
            return false;
        }
        public int this[int index] { get => _elements[index]; set => _elements[index] = value; }

        public IEnumerator GetEnumerator() {
            return (IEnumerator) _elements.GetEnumerator();
        }
        public bool MoveNext()
        {
            position++;
            return (position < _elements.Length);
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get { return _elements[position]; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array(new int[] { 7, 13, 2, 11, 3, 1 });
            Console.WriteLine(array.Max());
            Console.WriteLine(array.Min());
            Console.WriteLine(array.Sum());
            Console.WriteLine(array.Avg());
            Console.WriteLine(array.Search(11));
            Console.WriteLine(array.Search(12));
            Console.ReadKey();
        }
    }
}