using System;

namespace DummyDB
{
    class Program
    {
        public static void Main()
        {

            Book[] books = WorkWithFiles.GetBooks("Books.csv");
            Reader[] readers = WorkWithFiles.GetReaders("Readers.csv");
            BookReader[] bookReaders = WorkWithFiles.GetBookReaders(
                "BookReaders.csv", books, readers);

            Console.WriteLine("Книги: ");
            foreach (var book in books)
            {
                Console.WriteLine(book.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Читатели: ");
            foreach (var e in readers)
            {
                Console.WriteLine(e.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Читатели книг: ");
            foreach (var e in bookReaders)
            {
                Console.WriteLine(e.Reader.Name);
            }
        }
    }
}