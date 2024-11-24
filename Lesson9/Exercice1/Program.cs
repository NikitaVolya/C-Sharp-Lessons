using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 1
//Створіть додаток, який відображає текстове повідом-
//лення. Використовуйте механізми делегатів. Делегат має
//повертати void та приймати один параметр типу string
//(текст повідомлення). Для тестування додатка створіть
//різні методи виклику через делегат

namespace Exercice1
{
    public delegate void MessageDelegate(string message);

    class ProgramMessages
    {
        public static void ErrorMessage(string message)
        {
            Console.WriteLine($"!!! Error: \"{message}\" !!!");
        }
        public static void DebugMessage(string message)
        {
            Console.WriteLine($"Debug: \"{message}\"");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Main function";
            MessageDelegate del = new MessageDelegate(ProgramMessages.ErrorMessage);
            del(text);
            del = ProgramMessages.DebugMessage;
            del(text);
            Console.ReadLine();
        }
    }
}
