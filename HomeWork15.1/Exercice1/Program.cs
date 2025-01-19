using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

//Завдання 1:
//Створіть програму для роботи з масивом дробів (чисельник і
//знаменник) з такою функціональністю:
//1.Введення масиву дробів з клавіатури.
//2. Серіалізація масиву дробів.
//3. Збереження серіалізованого масиву у файл.
//4. Завантаження серіалізованого масиву з файлу. Після
//завантаження потрібно виконати десеріалізацію.
//Вибір певного формату серіалізації потрібно зробити вам.
//Звертаємо вашу увагу, що вибір має бути обґрунтованим.

namespace Exercice1
{
    [Serializable]
    public class Fraction
    {
        private int _numerator;
        private int _denominator;

        public int Numerator { get => _numerator; }
        public int denominator { get => _denominator; }

        public Fraction()
        {
            _numerator = 0;
            _denominator = 1;
        }
        public Fraction(string value)
        {
            var data = value.Split('/');
            if (data.Length != 2)
                throw new ArgumentException("Fraction: value mast have format like '{numerator}/{denominator}'");

            _numerator = int.Parse(data[0]);
            _denominator = int.Parse(data[1]);
            Reduction();
        }
        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
            Reduction();
        }
        private void Reduction()
        {
            if (_denominator == 0)
                throw new ArgumentException();

            int a = _numerator;
            int b = _denominator;
            while (true)
            {
                int c = a % b;
                if (c == 0)
                    break;
                a = b;
                b = c;
            }

            _numerator /= b;
            _denominator /= b;
        }

        public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a._numerator * a._denominator + b._numerator * b._denominator, a._denominator * b._denominator);
        public static Fraction operator -(Fraction a, Fraction b) => new Fraction(a._numerator * a._denominator - b._numerator * b._denominator, a._denominator * b._denominator);
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a._numerator * b._numerator, a._denominator * b._denominator);
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a._numerator * b._numerator, a._denominator * b._denominator);

        public override string ToString() => $"{_numerator}/{_denominator}";

        public static implicit operator Fraction(string value) => new Fraction(value);
        public static implicit operator Fraction(int value) => new Fraction(value, 1);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fraction> fractions = new List<Fraction>();
            for (int i = 0; i < 5; i++)
                fractions.Add(Console.ReadLine());

            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (Stream stream = File.Create("test.bin"))
                {
                    formatter.Serialize(stream, fractions);
                }

                List<Fraction> read_fractions = null;
                using (Stream stream = File.OpenRead("test.bin"))
                {
                    read_fractions = (List<Fraction>)formatter.Deserialize(stream);
                }
                for (int i = 0; i < read_fractions.Count; i++)
                    Console.WriteLine(read_fractions[i]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
}
