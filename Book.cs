namespace DummyDB
{
    class Book
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Author { get; init; }
        public int Year { get; init; }
        public int Cupboard { get; init; }
        public int Shelf { get; init; }

        public Book(int id, string name, string author, int year, int cupboard, int shelf)
        {
            Id = id;
            Name = name;
            Author = author;
            Year = year;
            Cupboard = cupboard;
            Shelf = shelf;
        }
    }
}