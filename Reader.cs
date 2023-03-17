namespace DummyDB
{
    class Reader
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public Reader(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}