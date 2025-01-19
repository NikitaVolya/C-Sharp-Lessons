
//1.Опис завдання:
//Створіть бібліотеку класів.NET, яка моделює каталог книг. Бібліотека має
//включати такі класи:
//o Book: представляє книгу, з полями Title, Author, ISBN, YearPublished і
//методом GetBookInfo(), який повертає інформацію про книгу.
//o Author: представляє автора, з полями Name, Biography, List<Book>
//(список книг автора).
//o Library: управляє колекцією книг, має методи для додавання,
//видалення та пошуку книг за назвою або автором.
//o User: представляє користувача бібліотеки, з полями Name,
//BorrowedBooks (список взятих книг) і методом BorrowBook(Book book).

namespace Exercice1
{
    public class Book
    {
        private string _title;
        private Author _author;
        private string _isbn;
        private DateTime _year_published;

        public Book(string title, Author author, string ISBN, DateTime year_published)
        {
            _title = title;
            _author = author;
            author.AddBook(this);
            _isbn = ISBN;
            _year_published = year_published;
        }

        public string Title { get => _title; }
        public string AuthorName { get => _author.Name; }
        public string ISBN { get => _isbn; }
        public DateTime YearPublished 
        {
            get
            {
                DateTime time = new DateTime();
                time = _year_published;
                return time;
            }
        }

        public string GetBookInfo() => $"{_title}, {_isbn} | {_author.Name} | ({_year_published})";
    }

    public class Author
    {
        private string _name;
        private string _biography;
        private List<Book> _own_books;


        public void AddBook(Book book)
        {
            _own_books.Add(book);
        }
        public Author(string name, string biography)
        {
            _name = name;
            _biography = biography;
            _own_books = new List<Book>();
        }

        public string Name { get => _name; }
        public string Biography { get => _biography; }
        public string[] books { get => (from book in _own_books select book.GetBookInfo()).ToArray(); }
    }

    public class Library
    {
        private List<Book> _books;

        public Library() { _books = new List<Book>(); }

        public void AddBook(Book book) => _books.Add(book);
        public void RemoveBook(Book book) => _books.Remove(book);
        public Book? FindBookByTitle(string title) => _books.Find(book => book.Title == title);
        public Book? FindBookByAuthor(string author_name) => _books.Find(book => book.AuthorName == author_name);

        public string[] Books { get => (from book in _books select book.GetBookInfo()).ToArray(); }
    }

    public class User
    {
        private string _name;
        private List<Book> _borrowed_books;

        public User(string name)
        {
            _name = name;
            _borrowed_books = new List<Book>();
        }

        public void BorrowBook(Book book) => _borrowed_books.Add(book);

        public string Name { get => _name; }
        public string[] BorrowedBooks { get => (from book in _borrowed_books select book.GetBookInfo()).ToArray(); }

    }
}
