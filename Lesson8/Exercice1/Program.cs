using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Створіть інтерфейс IOutput. У ньому мають бути два
//методи:
//■ void Show() — відображає інформацію;
//■ void Show(string info) — відображає інформацію та
//інформаційне повідомлення, зазначене у параметрі
//info.
//Створіть клас Array (масив цілого типу) із необхід-
//ними методами. Цей клас має імплементувати інтерфейс
//IOutput.
//Метод Show() — відображає на екран елементи масиву.
//Метод Show(string info) — відображає на екрані еле-
//менти масиву та інформаційне повідомлення, зазначене
//у параметрі info.
//Напишіть код для тестування отриманої функціо-
//нальності.

namespace Exercice1
{
    interface IOutput
    {
        void Show();
        void Show(string info);
    }

    class Array : IOutput
    {
        int[] _elements;

        public int Length { get => _elements.Length; }
        public Array(int[] elements)
        {
            _elements = new int[elements.Length];
            elements.CopyTo(_elements, 0);
        }

        public int this[int index] { get => _elements[index]; set => _elements[index] = value; }

        public void Show()
        {
            Console.Write("[");
            foreach (var element in _elements)
            {
                Console.Write(element.ToString() + " ");
            }
            Console.WriteLine("]");
        }
        public void Show(string info)
        {
            Show();
            Console.WriteLine(info);
        }
    }
       
    internal class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array(new int[] { 1, 2, 3, 7, 11, 13 });
            array.Show();
            array.Show("Test message!");
            Console.ReadKey();
        }
    }
}
