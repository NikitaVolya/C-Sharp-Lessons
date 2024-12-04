using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Створіть клас «Алфавіт», в якому мають міститися
//літери англійського алфавіту. Реалізуйте підтримку іте-
//ратора. Протестуйте можливість використання foreach
//для класу «Алфавіт»

namespace Exercice1
{
    class Alpahabet
    {
        char _start;
        char _end;

        public Alpahabet()
        {
            _start = 'a';
            _end = 'z';
        }

        public Alpahabet(char start, char end) : this()
        {
            Start = start;
            End = end;
        }

        public char Start
        {
            get => _start;
            set
            {
                if (value > _end)
                    throw new ArgumentException();
                _start = value;
            }
        }
        public char End
        {
            get => _end;
            set
            {
                if (value < _start)
                    throw new ArgumentException();
                _end = value;
            }
        }
        public IEnumerator<char> GetEnumerator()
        {
            for (char i = _start; i <= _end; i++)
            {
                yield return i;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (char i in new Alpahabet('b', 'w'))
                Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
