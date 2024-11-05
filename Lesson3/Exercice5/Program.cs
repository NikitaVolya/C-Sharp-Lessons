using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice5
{
    internal class Program
    {
        class Employer
        {
            private string birthday;
            private string telephoneNumber;
            private string email;

            public Employer(string fullname, string birthday, string telephoneNumber, string email, string workDescription)
            {
                Fullname = fullname;
                Birthday = birthday;
                TelephoneNumber = telephoneNumber;
                Email = email;
                WorkDescription = workDescription;
            }

            public string Fullname { get; set; }
            public string Birthday {
                get {
                    return birthday;
                }
                set {
                    if (value.Length < 7)
                        return;

                    short day = Convert.ToInt16(value.Substring(0, 2));
                    if (day <= 0 || day > 31)
                        return;

                    short month = Convert.ToInt16(value.Substring(3, 2));
                    if (month <= 0 || month > 12)
                        return;
                    birthday = value;
                }
            }
            public string TelephoneNumber
            {
                get { return telephoneNumber; }
                set
                {
                    if (value.Length < 10)
                        return;
                    int number;
                    if (!int.TryParse(value, out number))
                        return;

                    telephoneNumber = value;
                }
            }
            public string Email
            {
                get { return email; }
                set
                {
                    if (value.IndexOf('@') == -1)
                        return;
                    email = value;
                }
            }
            public string WorkDescription {get; set;}

            public void Print()
            {
                Console.WriteLine($"[Full name: {Fullname}, birthday: {birthday}, telephoneNumber: {telephoneNumber}, email: {email}, work description: {WorkDescription}]");
            }
        }
        static void Main(string[] args)
        {
            Employer employer = new Employer("Nikita Voliankyi Oleksandr", "13-03-2006", "0981132029", "volianskyinikita@gmail.com", "Back end");
            employer.Print();

            Console.ReadLine();
        }
    }
}
