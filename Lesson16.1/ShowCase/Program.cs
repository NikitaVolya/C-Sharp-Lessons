using System;
using Exercice1;

//Завдання:
//o Створіть бібліотеку класів .NET, реалізуйте всі вищезазначені класи та
//методи.
//o У консольному додатку протестуйте створену бібліотеку:
//▪ Додайте кілька книг до бібліотеки.
//▪ Створіть користувача, який бере одну з книг.
//▪ Виведіть інформацію про книги в бібліотеці та у користувача.

class Program
{
    static void Main(string[] args)
    {

        Author author1 = new Author("J.K. Rowling",
            "J.K. Rowling is a British author, best known for writing the Harry Potter series, one of the best-selling book series in history.");

        Author author2 = new Author("George R.R. Martin",
            "George R.R. Martin is an American novelist and short-story writer, best known for his series 'A Song of Ice and Fire', which was adapted into the hit TV show 'Game of Thrones'.");


        Book book1 = new Book("Harry Potter and the Sorcerer's Stone", author1, "978-0439708180", new DateTime(1997, 6, 26));
        Book book2 = new Book("A Game of Thrones", author2, "978-0553103540", new DateTime(1996, 8, 6));
        Book book3 = new Book("Harry Potter and the Chamber of Secrets", author1, "978-0439064873", new DateTime(1998, 7, 2));

        Library library = new Library();
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        User user = new User("Alice Johnson");

        Book? borrow_book = library.FindBookByTitle(book1.Title);
        if (borrow_book == null)
            return;

        library.RemoveBook(borrow_book);
        user.BorrowBook(borrow_book);

        Console.WriteLine("Library books: ");
        foreach (string book_info in library.Books)
            Console.WriteLine(book_info);

        Console.WriteLine("\nUser books:");
        foreach (string book_info in user.BorrowedBooks)
            Console.WriteLine(book_info);

        Console.ReadLine();
    }
}