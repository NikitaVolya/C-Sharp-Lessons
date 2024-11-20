using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть інтерфейс ISort. У ньому мають бути три
//методи:
//■ void SortAsc() — сортування за зростанням;
//■ void SortDesc() — сортування за зменшенням;
//■ void SortByParam(bool isAsc) — сортування залежно
//від переданого параметра. Якщо isAsc дорівнює true,
//сортуємо за зростанням. Якщо isAsc дорівнює false,
//сортуємо за зменшенням.Практичне завдання
//Клас, створений у першому завданні Array, має імпле-
//ментувати інтерфейс ISort.
//Метод SortAsc — сортує масив за зростанням.
//Метод SortDesc — сортує масив за спаданням.
//Спосіб SortByParam — сортує масив залежно від пе-
//реданого параметра. Якщо isAsc дорівнює true, сортуємо
//за зростанням. Якщо isAsc дорівнює false, сортуємо за
//зменшенням.
//Напишіть код для тестування отриманої функціо-
//нальності.

namespace Exercice3
{
    interface ISort
    {
        void Sort(Func<int, int, bool> func);
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }


    class Array : ISort
    {
        private int[] _elements;

        public int Length { get => _elements.Length; }
        public Array(int[] elements)
        {
            _elements = new int[elements.Length];
            elements.CopyTo(_elements, 0);
        }
        public int this[int index] { get => _elements[index]; set => _elements[index] = value; }


        public void Sort(Func<int, int, bool> func)
        {
            for (int i = 0; i < _elements.Length - 1; i++)
            {
                int min_i = i;
                for (int j = i; j < _elements.Length; j++)
                {
                    if (func(_elements[j], _elements[min_i]))
                        min_i = j;
                }
                int tmp = _elements[min_i];
                _elements[min_i] = _elements[i];
                _elements[i] = tmp;
            }
        }
        public void SortAsc() => Sort((a, b) => a < b);
        public void SortDesc() => Sort((a, b) => a > b);
        public void SortByParam(bool isAsc)
        {
            if (isAsc)
                SortAsc();
            else
                SortDesc();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array(new int[] { 7, 13, 2, 11, 3, 1 });
            array.SortByParam(true);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            array.SortByParam(false);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
