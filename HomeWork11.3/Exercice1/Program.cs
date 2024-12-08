using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1:
//Створіть додаток для менеджменту співробітників та паролів,
//який має зберігати наступну інформацію:
// логіни співробітників;
// паролі співробітників.
//Для зберігання інформації використовуйте Dictionary<T>.
//Додаток має надавати таку функціональність:
// додати логін і пароль співробітника;
// видалити логін співробітника;
// змінити інформацію про логін і пароль співробітника;
// отримати інформацію про пароль за логіном співробітника.

namespace Exercice1
{
    class Workers
    {
        private Dictionary<string, string> _workers;

        public Workers() { 
            _workers = new Dictionary<string, string>();
        }

        public void Add(string username, string password)
        {
            if (_workers.ContainsKey(username))
                throw new ArgumentException();
            _workers.Add(username, password);
        }
        public void Remove(string username)
        {
            if (!_workers.ContainsKey(username))
                throw new ArgumentException();
            _workers.Remove(username);
        }
        public void Replace(string username, string new_username)
        {
            string password = this[username];
            _workers.Remove(username);
            _workers.Add(new_username, password);
        }
        public string this[string username]
        {
            get {
                if (!_workers.ContainsKey(username))
                    throw new ArgumentException();
                return _workers[username];
            }
            set {
                if (!_workers.ContainsKey(username))
                    throw new ArgumentException();
                _workers[username] = value;
            }
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Workers data = new Workers();
            data.Add("Nikita", "12345");
            Console.WriteLine("Nikita: " + data["Nikita"]);
            data["Nikita"] = "54321";
            Console.WriteLine("Nikita: " + data["Nikita"]);
            data.Replace("Nikita", "Nikita Volia");
            Console.WriteLine("Nikita Volia: " + data["Nikita Volia"]);
            Console.ReadLine();
        }
    }
}
