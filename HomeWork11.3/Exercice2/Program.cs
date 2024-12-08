using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Завдання 2:
//Створіть додаток «Англо-французький словник», який має
//зберігати наступну інформацію:
// слово англійською мовою;
// варіанти перекладу французькою.
//Для зберігання інформації використовуйте Dictionary<T>.
//Додаток має надавати таку функціональність:
// додати слово і варіанти перекладу;
// видалити слово;
// видалити варіанти перекладу;
// зміна слова;
// зміна варіанта перекладу;
// пошук перекладу слова.

class EnglishFrenchDictionary
{
    private Dictionary<string, List<string>> _dictionary; 

    public EnglishFrenchDictionary()
    {
        _dictionary = new Dictionary<string, List<string>>();
    }

    public List<string> GetTranslate(string english)
    {
        if (!_dictionary.ContainsKey(english))
            throw new ArgumentException();
        return _dictionary[english];
    }

    public void AddTranslate(string english, string franche)
    {
        if (_dictionary.ContainsKey(english))
            _dictionary[english].Add(franche);
        else
            _dictionary.Add(english, new List<string> { franche });
    }

    public void AddTranslate(string english, string[] franche)
    {
        if (_dictionary.ContainsKey(english))
            throw new ArgumentException();
        _dictionary[english] = new List<string>(franche);
    }

    public void RemoveTranslate(string english)
    {
        if (! _dictionary.ContainsKey(english))
            throw new ArgumentException();
        _dictionary.Remove(english);
    }

    public void RemoveTranslate(string english, string franche)
    {
        if (!_dictionary.ContainsKey(english))
            throw new ArgumentException();
        _dictionary[english].Remove(franche);
        if (_dictionary[english].Count == 0)
            _dictionary.Remove(english);
    }

    public void ChangeTranslate(string english, string new_english)
    {
        if (!_dictionary.ContainsKey(english))
            throw new ArgumentException();
        List<string> tmp = _dictionary[english];
        _dictionary.Remove(english);
        _dictionary.Add(new_english, tmp);
    }
}

namespace Exercice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnglishFrenchDictionary dict = new EnglishFrenchDictionary();
            dict.AddTranslate("say", new string[] { "dire"});
            dict.AddTranslate("say", "penser");
            Console.WriteLine("Say translate: ");
            foreach ( string translate in dict.GetTranslate("say"))
                Console.WriteLine(translate);
            Console.ReadLine();
        }
    }
}
