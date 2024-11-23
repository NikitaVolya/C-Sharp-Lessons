using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Створити базовий клас «Тварина» і похідні класи:
//«Тигр», «Крокодил», «Кенгуру». За допомогою конструк-
//тора, надати ім'я до кожної тварини та її характеристики.
//Створіть для кожного класу необхідні методи і поля.

namespace Exercice3
{
    class Animal
    {
        public Animal() { }
        public virtual string Name { get => "None"; }
        public virtual void Sound() => Console.WriteLine("None");
    }

    class Tiger : Animal
    {
        public Tiger() { }
        public string Name { get => "Tiger"; }
        public override void Sound()
        {
            Console.WriteLine($"{Name}: roars");
        }
    }

    class Crocodile : Animal
    {
        public Crocodile() { }
        public string Name { get => "Crocodile"; }
        public override void Sound()
        {
            Console.WriteLine($"{Name}: clicks with a tentacle");
        }
    }

    class Kangaroo : Animal
    {
        public Kangaroo() { }
        public string Name { get => "Kangaroo"; }
        public override void Sound()
        {
            Console.WriteLine($"{Name}: hisses");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Animal tiger = new Tiger();
            tiger.Sound();

            Animal crocodile = new Crocodile();
            crocodile.Sound();

            Animal kangaroo = new Kangaroo();
            kangaroo.Sound();

            Console.Read();
        }
    }
}
