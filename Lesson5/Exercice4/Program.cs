using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//Завдання 4
//Створіть додаток для генерації псевдотексту. Користувач
//вводить кількість голосних і приголосних, максимальну
//довжину слова. Додаток генерує текст на основі вибраних
//параметрів. Використовуйте механізми просторів імен

namespace TextGeearator
{
    
    class Generator
    {
        private char[] vowls = new char[]{ 'a', 'e', 'i', 'e', 'u', 'y'};
        private char[] consonant = new char[]{ 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 'r', 'v', 'w', 'x', 'z'};
        private int _spaces_chance;
        private int _vowels_chance;
        private int _consonant_chance;

        public Generator()
        {
            _spaces_chance = 5;
            _vowels_chance =  10;
            _consonant_chance = 20;
        }
        public Generator(int vowels_number, int consonant_number)
        {
            VowelsChance = vowels_number;
            ConsonantChance = consonant_number;
            _spaces_chance = (vowels_number + consonant_number) / 8;
        }

        public int SpacesChance
        {
            get { return _spaces_chance; }
            set { if (value < 0) throw new ArgumentOutOfRangeException(); _spaces_chance = value; }
        }
        public int VowelsChance
        {
            get { return _vowels_chance; }
            set { if (value < 0) throw new ArgumentOutOfRangeException(); _vowels_chance = value; }
        }
        public int ConsonantChance
        {
            get { return _consonant_chance; }
            set { if (value < 0) throw new ArgumentOutOfRangeException(); _consonant_chance = value; }
        }

        private int Size
        {
            get { return _spaces_chance + _vowels_chance + _consonant_chance; }
        }

        public string Generate()
        {
            Random rand = new Random();
            string response = "";

            while (Size > 0) {
                int tmp_chance = rand.Next() % (Size + 1);
                if (tmp_chance <= _spaces_chance)
                {
                    if (Size - _spaces_chance == 0)
                        return response;
                    if (response.Length != 0 && response[response.Length - 1] == ' ')
                        continue;
                    response += ' ';
                    _spaces_chance--;
                    continue;
                }
                tmp_chance -= _spaces_chance;
                if (tmp_chance <  _vowels_chance)
                {
                    response += vowls[rand.Next(vowls.Length)];
                    _vowels_chance--;
                    continue;
                }

                response += consonant[rand.Next(consonant.Length)];
                _consonant_chance--;
            }
            return response;
        }
    }
}

namespace Exercice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextGeearator.Generator generator = new TextGeearator.Generator(5, 25);
            Console.WriteLine(generator.Generate());
            Console.ReadLine();
        }
    }
}
