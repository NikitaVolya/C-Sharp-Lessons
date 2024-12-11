using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2
//Створити клас «Рюкзак». Характеристики рюкзака:
//■ Колір рюкзака;
//■ Марка і виробник;
//■ Тканина рюкзака;
//■ Вага рюкзака;
//■ Об’єм рюкзака;
//■ Вміст рюкзака(список об’єктів у кожного об’єкта, крім
//назви, потрібно враховувати займаємий об’єм).
//Створіть методи для заповнення характеристик. Ство-
//ріть подію для додавання об’єкта в рюкзак. Реалізуйте
//анонімний метод як обробник події додавання об’єкта.
//Якщо при спробі додавання може бути перевищено обсяг
//рюкзака, потрібно генерувати виняток.

namespace Exercice2
{

    class Object
    {
        public string Name { get; set; }
        public float Weight { get; set; }

        public Object(string name, float weight)
        {
            Name = name;
            Weight = weight;
        }
    }


    class Backpack
    {

        public delegate void BackpackCallBack(Backpack backpack, Object message);
        event BackpackCallBack AddObjectEvent;

        private List<Object> _objects;


        public string BackpackName { get; set; }
        public string BackpackColor { get; set; }
        public string BackpackFabrick { get; set; }
        public float BackpackWeight {
            get
            {
                float weight = 0.0f;
                foreach (Object obj in _objects)
                {
                    weight += obj.Weight;
                }
                return weight;
            }
        }
        public int BackpackObjectNumber { get { return _objects.Count; } }
        public List<Object> BackpackObjects
        {
            get => _objects;
            set => _objects = value;
        }
        public int BackpackSize { get; set; }

        public void SetAddEvent(BackpackCallBack ev)
        {
            AddObjectEvent = ev;
        }

        public void AddEvent(Object obj)
        {
            AddObjectEvent?.Invoke(this, obj);
        }

        public Backpack(string backpack_name, string backpack_color, string backpack_fabrick, int backpack_size)
        {
            BackpackName = backpack_name;
            BackpackColor = backpack_color;
            BackpackFabrick = backpack_fabrick;
            BackpackSize = backpack_size;
            _objects = new List<Object>();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Backpack backpack = new Backpack( "Adventure Pack", "Blue", "Nylon", 3);

            backpack.SetAddEvent(
                (Backpack bckp, Object obj) =>
                {
                    if (obj == null || bckp == null)
                        throw new ArgumentNullException();
                    if (bckp.BackpackObjectNumber >= bckp.BackpackSize)
                        throw new Exception("Backpack is full!");

                    bckp.BackpackObjects.Add(obj);
                });

            backpack.AddEvent(new Object("flashlight", 0.2f));
            backpack.AddEvent(new Object("botle", 0.6f));
            backpack.AddEvent(new Object("ball", 0.4f));

            Console.WriteLine(backpack.BackpackWeight);
            Console.Read();


            backpack.AddEvent(new Object("knife", 0.15f));
        }
    }
}
