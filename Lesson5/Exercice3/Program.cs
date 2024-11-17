using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 3
//Створіть гру «Вгадай число». Комп’ютер вгадує число,
//яке загадав користувач у вказаному діапазоні. Використо-
//вуйте механізми просторів імен.

namespace GuessNumber
{
    class Game
    {
        private int _number;
        private int _min_number;
        private int _max_number;

        public int MinNumber
        {
            get { return _min_number; }
            set
            {
                if (value < 0 || value > _max_number)
                    return;
                _min_number = value;
            }
        }

        public int MaxValue
        {
            get { return _max_number; }
            set
            {
                if (value < 0 || value < _min_number)
                    return;
                _max_number = value;
            }
        }


        public Game()
        {
            _min_number = 0;
            _max_number = 100;
            InitGame();
        }

        public Game(int min_number, int max_number)
        {
            if (min_number < 0 || max_number < 0 || min_number > max_number)
                throw new ArgumentException();
            _min_number = min_number;
            _max_number = max_number;
        }

        public void InitGame()
        {
            Random random = new Random();
            _number = _min_number + random.Next() % (_max_number - _min_number);
        }

        public void Run()
        {
            int user_number;

            do
            {
                Console.WriteLine($"Input number [{_min_number}-{_max_number}]: ");
                user_number = Convert.ToInt32(Console.ReadLine());

                if (user_number < _min_number || user_number > _max_number)
                    Console.WriteLine("Out of range");
                else if (user_number < _number)
                    Console.WriteLine("To smole");
                else if (user_number > _number)
                    Console.WriteLine("To much");
            } while (user_number != _number);

            Console.WriteLine("You win!");
        }

    }
}

namespace Exercice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuessNumber.Game game = new GuessNumber.Game();
            game.MinNumber = 50;
            game.InitGame();
            game.Run();

            Console.ReadKey();
        }
    }
}
