using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3:
//Створіть додаток, що емулює чергу в популярне кафе. Відвідувачі
//кафе приходять та потрапляють у чергу, якщо немає вільного
//місця. Коли столик в кафе стає вільним, перший відвідувач з
//черги займає його. Якщо приходить відвідувач, який резервував
//столик на певний час, він отримує зарезервований столик
//позачергово.
//Під час розробки додатка використовуйте клас Queue<T>.

namespace Exercice3
{
    class Personne
    {
        public string FullName { get; set; }

        public Personne(string full_name) 
        {
            FullName = full_name;
        }

        public override string ToString()
        {
            return $"Personne {FullName}";
        }
    }

    class CoffeShop
    {
        Queue<Personne> _tables;
        Queue<Personne> _queue;
        int _table_number;

        public CoffeShop()
        {
            _tables = new Queue<Personne>();
            _queue = new Queue<Personne>();
            _table_number = 3;
        }
        public CoffeShop(int table_number) : this()
        {
            _table_number = table_number;
        }

        public Personne FreeTable()
        {
            MoveQueue();
            if ( _tables.Count == 0 )
                return null;
            return _tables.Dequeue();
        }

        public Personne MoveQueue()
        {
            if (_queue.Count == 0)
                return null;
            Personne tmp = _queue.Dequeue();
            _tables.Enqueue(tmp);
            if (_tables.Count > _table_number)
            {
                return _tables.Dequeue();
            }
            else
                return null;
        }
        public void AddToQueue(Personne person)
        {
            _queue.Enqueue(person);
            if (OccupiedTableNumber < _table_number)
                MoveQueue();
        }
        public void AddToTable(Personne personne)
        {
            if (_tables.Count == _table_number)
                _tables.Dequeue();
            _tables.Enqueue(personne);
        }

        public int QueueSize { get => _queue.Count; }
        public int OccupiedTableNumber { get => _tables.Count; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeShop coffe_shop = new CoffeShop();
            Personne[] perssones = new Personne[] {
                new Personne("Nikita"),
                new Personne("Oleg"),
                new Personne("Anton"),
                new Personne("Sergey")
            };

            foreach (Personne person in perssones)
            {
                coffe_shop.AddToQueue(person);
            }

            Console.WriteLine($"Occupied table number: {coffe_shop.OccupiedTableNumber}");
            Console.WriteLine($"Queue size: {coffe_shop.QueueSize}");

            coffe_shop.AddToTable(new Personne("Zachar"));

            Console.WriteLine($"Occupied table number: {coffe_shop.OccupiedTableNumber}");
            Console.WriteLine($"Queue size: {coffe_shop.QueueSize}");

            coffe_shop.FreeTable();
            coffe_shop.FreeTable();

            Console.WriteLine($"Occupied table number: {coffe_shop.OccupiedTableNumber}");
            Console.WriteLine($"Queue size: {coffe_shop.QueueSize}");

            coffe_shop.FreeTable();
            coffe_shop.FreeTable();

            Console.WriteLine($"Occupied table number: {coffe_shop.OccupiedTableNumber}");
            Console.WriteLine($"Queue size: {coffe_shop.QueueSize}");

            Console.ReadKey();
        }
    }
}
