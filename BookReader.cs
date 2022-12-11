namespace DummyDB
{
    class BookReader
    {
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime TakingDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public BookReader(Book book, Reader reader, DateTime takingDate, DateTime returnDate)
        {
            Book = book;
            Reader = reader;
            TakingDate = takingDate;
            ReturnDate = returnDate;
        }
    }
}