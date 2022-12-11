using System;

namespace DummyDB
{
    class Program
    {
        public static void Main()
        {
            Book book1 = new(1, "Гайд по майнкрафту", "Вася", 2022, 1, 1);

            Reader reader1 = new(1, "Лёха");

            Reader reader2 = new(2, "Aleksandr");

            Reader reader3 = new(3, "Светлана");

            BookReader bookReader = new(book1,
                reader2,
                new DateTime(2022, 5, 1, 14, 0, 0),
                new DateTime(2022, 7, 1, 14, 0, 0));

            Console.WriteLine("Книгу " + bookReader.Book.Name
                + "\r\nВзял " + bookReader.Reader.Name
                + "\r\nДата взятия " + bookReader.TakingDate
                + "\r\nДата возврата " + bookReader.ReturnDate);

        }
    }
}