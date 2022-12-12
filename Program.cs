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

            string bookColumnsName = File.ReadAllLines("Books.csv")[0];
            string readerColumnsName = File.ReadAllLines("Readers.csv")[0];
            string bookReaderColumnsName = File.ReadAllLines("BookReaders.csv")[0];

            Console.WriteLine("\r\nСписок всех книг: ");
            foreach (var e in FileFormatting.GetFormattedBooksData(books, bookColumnsName))
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\r\nСписок всех читателей: ");
            foreach(var e in FileFormatting.GetFormattedReadersData(readers, readerColumnsName))
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\r\nСписок читаемых книг: ");
            foreach (var e in FileFormatting.GetFormattedBookReadersData(bookReaders, bookReaderColumnsName))
            {
                Console.WriteLine(e);
            }
        }
    }
}