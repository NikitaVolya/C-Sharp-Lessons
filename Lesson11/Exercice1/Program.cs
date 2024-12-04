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
    internal class Program
    {
        class EmployersManager
        {

            private Dictionary<string, string> _employers_data;

            public EmployersManager() 
            { 
                _employers_data = new Dictionary<string, string> { };
            }

            public string this[string username] 
            {
                get
                {
                    if (!FindEmployer(username))
                        throw new IndexOutOfRangeException("Employer not found");
                    return _employers_data[username];
                }
                set
                {
                    if (!FindEmployer(username))
                        throw new IndexOutOfRangeException("Employer not found");
                    _employers_data[username] = value;
                }
            }

            public bool FindEmployer(string username)
            {
                return _employers_data.ContainsKey(username);
            }

            public void AddEmployer(string username, string password)
            {
                if (FindEmployer(username))
                    throw new IndexOutOfRangeException("Employer already existe");
                _employers_data.Add(username, password);
            }

            public void RemoveEmployer(string username)
            {
                if (!FindEmployer(username))
                    throw new IndexOutOfRangeException("Employer not found");
                _employers_data.Remove(username);
            }

            public void ChangeEmployerUsername(string username, string new_username)
            {
                AddEmployer(new_username, this[username]);
                RemoveEmployer(username);
            }

        }
        static void Main(string[] args)
        {
            EmployersManager employers = new EmployersManager();
            employers.AddEmployer("Nikita", "1234");
            employers.AddEmployer("Oleg", "5432");

            Console.WriteLine("Nikita: " + employers["Nikita"]);
            Console.WriteLine("Oleg: " + employers["Oleg"]);

            employers["Oleg"] = "2343";

            Console.WriteLine("Nikita: " + employers["Nikita"]);
            Console.WriteLine("Oleg: " + employers["Oleg"]);

            employers.ChangeEmployerUsername("Nikita", "NikitaVolia");

            Console.WriteLine("NikitaVolia: " + employers["NikitaVolia"]);
            Console.WriteLine("Oleg: " + employers["Oleg"]);

            Console.ReadLine();
        }
    }
}
