namespace DummyDB
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Cupboard { get; set; }
        public int Shelf { get; set; }

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