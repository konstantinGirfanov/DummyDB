using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using DummyDB;

namespace DummyDB
{
    class WorkWithFiles
    {
        public static Book[] GetBooks(string path)
        {
            string[] lines = File.ReadAllLines(path);

            List<string> result = new();

            for (int i = 1; i < lines.Length; i++)
            {
                Console.WriteLine($"Информация о {i} строке данных книг: {GetInformationCorrectnessBookData(lines[i].Split(';'))}");
                if (GetInformationCorrectnessBookData(lines[i].Split(';')) == "Данные в порядке.")
                {
                    result.Add(lines[i]);
                }
            }

            string[] res = result.ToArray();
            Book[] books = new Book[res.Length];

            for (int i = 0; i < res.Length; i++)
            {
                books[i] = new Book(int.Parse(res[i].Split(';')[0]),
                    res[i].Split(';')[1],
                    res[i].Split(';')[2],
                    int.Parse(res[i].Split(';')[3]),
                    int.Parse(res[i].Split(';')[4]),
                    int.Parse(res[i].Split(';')[5]));
            }
            return books;
        }

        public static Reader[] GetReaders(string path)
        {
            string[] lines = File.ReadAllLines(path);

            List<string> result = new();
            for (int i = 1; i < lines.Length; i++)
            {
                Console.WriteLine($"Информация о {i} строке данных читателей: {GetInformationCorrectnessReaderData(lines[i].Split(';'))}");
                if (GetInformationCorrectnessReaderData(lines[i].Split(';')) == "Данные в порядке.")
                {
                    result.Add(lines[i]);
                }
            }

            string[] res = result.ToArray();
            Reader[] readers = new Reader[res.Length];
            for (int i = 0; i < res.Length; i++)
            {
                readers[i] = new Reader(int.Parse(res[i].Split(';')[0]),
                    res[i].Split(';')[1]);
            }
            return readers;
        }

        public static BookReader[] GetBookReaders(string path,
            Book[] books, Reader[] readers)
        {
            string[] lines = File.ReadAllLines(path);

            List<string> result = new();
            for (int i = 1; i < lines.Length; i++)
            {
                Console.WriteLine($"Информация о {i} строке данных читателей книг: {GetInformationCorrectnessBookReaderData(lines[i].Split(';'))}");
                if (GetInformationCorrectnessBookReaderData(lines[i].Split(';')) == "Данные в порядке.")
                {
                    result.Add(lines[i]);
                }
            }

            string[] res = result.ToArray();
            BookReader[] bookReaders = new BookReader[res.Length];
            for (int i = 0; i < res.Length; i++)
            {
                bookReaders[i] = new BookReader(FindBook(books, int.Parse(res[i].Split(';')[0])),
                    FindReader(readers, int.Parse(res[i].Split(';')[1])),
                    DateTime.Parse(res[i].Split(';')[2]),
                    DateTime.Parse(res[i].Split(';')[3]));
            }

            return bookReaders;
        }

        public static Reader FindReader(Reader[] readers, int id)
        {
            for (int i = 0; i < readers.Length; i++)
            {
                if (readers[i].Id == id)
                {
                    id = i;
                    break;
                }
            }

            return readers[id];
        }

        public static Book FindBook(Book[] books, int id)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Id == id)
                {
                    id = i;
                    break;
                }
            }

            return books[id];
        }

        public static string GetInformationCorrectnessBookData(string[] line)
        {
            // Если данные не совпадают в некотором столбце или количество 
            // столбцов не совпадает с нужным, то эта строчка данных не записывается
            // в конечный массив данных. Также и с остальными данными.

            if (line.Length != 6)
            {
                return "Количество столбцов данных не совпадает с требуемым количеством.\r\n";
            }
            else
            {
                List<int> columns = new();

                if (!int.TryParse(line[0], out _))
                {
                    columns.Add(1);
                }

                for (int i = 1; i < 3; i++)
                {
                    if (line[i] is not string || double.TryParse(line[i], out _))
                    {
                        columns.Add(i);
                    }
                }

                for (int i = 3; i < line.Length; i++)
                {
                    if (!int.TryParse(line[i], out _))
                    {
                        columns.Add(i);
                    }
                }

                if (columns.Count > 0)
                {
                    StringBuilder result = new();
                    result.Append("Данные не соответствуют требуемому формату в: ");

                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (i == columns.Count - 1)
                        {
                            result.Append(i + 1 + " ");
                        }
                        else
                        {
                            result.Append(i + 1 + ", ");
                        }
                    }

                    result.Append("столбцах(-це).");
                    return result.ToString();
                }
                else
                {
                    return "Данные в порядке.";
                }
            }
        }

        public static string GetInformationCorrectnessReaderData(string[] line)
        {
            if (line.Length != 2)
            {
                return "Количество столбцов данных не совпадает с требуемым количеством.\r\n";
            }
            else
            {
                List<int> columns = new();

                if (!int.TryParse(line[0], out _))
                {
                    columns.Add(1);
                }

                if (line[1] is not string || double.TryParse(line[1], out _))
                {
                    columns.Add(2);
                }

                if (columns.Count > 0)
                {
                    StringBuilder result = new();
                    result.Append("Данные не соответствуют требуемому формату в: ");

                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (i == columns.Count - 1)
                        {
                            result.Append(columns[i] + " ");
                        }
                        else
                        {
                            result.Append(columns[i] + ", ");
                        }
                    }

                    result.Append("столбцах(-це).");
                    return result.ToString();
                }
                else
                {
                    return "Данные в порядке.";
                }
            }
        }

        public static string GetInformationCorrectnessBookReaderData(string[] line)
        {
            if (line.Length != 4)
            {
                return "Количество столбцов данных не совпадает с требуемым количеством.\r\n";
            }
            else
            {
                List<int> columns = new();

                for (int i = 0; i < 2; i++)
                {
                    if (!int.TryParse(line[i], out _))
                    {
                        columns.Add(i);
                    }
                }

                for (int i = 2; i < 4; i++)
                {
                    if (!DateTime.TryParse(line[i],  out _))
                    {
                        columns.Add(i);
                    }
                }

                if (columns.Count > 0)
                {
                    StringBuilder result = new();
                    result.Append("Данные не соответствуют требуемому формату в: ");

                    for (int i = 0; i < columns.Count; i++)
                    {
                        if (i == columns.Count - 1)
                        {
                            result.Append(columns[i] + 1 + " ");
                        }
                        else
                        {
                            result.Append(columns[i] + 1 + ", ");
                        }
                    }

                    result.Append("столбцах(-це).");
                    return result.ToString();
                }
                else
                {
                    return "Данные в порядке.";
                }
            }
        }
    }
}