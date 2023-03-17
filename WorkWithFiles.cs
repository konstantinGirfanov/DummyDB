using System.Text;

namespace DummyDB
{
    static class WorkWithFiles
    {
        public static Book[] GetBooks(string path)
        {
            string[] uncheckedData = File.ReadAllLines(path);

            List<string> correcData = new();
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                string correctness = GetInformationCorrectnessBookData(uncheckedData[i].Split(';'));

                Console.WriteLine($"Информация о {i} строке данных книг: {correctness}");
                if (correctness == "Данные в порядке.")
                {
                    correcData.Add(uncheckedData[i]);
                }
            }

            Book[] books = new Book[correcData.Count];
            for (int i = 0; i < correcData.Count; i++)
            {
                string[] lineData = correcData[i].Split(';');
                books[i] = new Book(
                    int.Parse(lineData[0]),
                    lineData[1],
                    lineData[2],
                    int.Parse(lineData[3]),
                    int.Parse(lineData[4]),
                    int.Parse(lineData[5]));
            }

            return books;
        }

        public static Reader[] GetReaders(string path)
        {
            string[] uncheckedData = File.ReadAllLines(path);

            List<string> correctData = new();
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                string correctness = GetInformationCorrectnessReaderData(uncheckedData[i].Split(';'));

                Console.WriteLine($"Информация о {i} строке данных читателей: {correctness}");
                if (correctness == "Данные в порядке.")
                {
                    correctData.Add(uncheckedData[i]);
                }
            }

            Reader[] readers = new Reader[correctData.Count];
            for (int i = 0; i < correctData.Count; i++)
            {
                string[] line = correctData[i].Split(";");
                readers[i] = new Reader(int.Parse(line[0]), line[1]);
            }

            return readers;
        }

        public static BookReader[] GetBookReaders(string path,
            Book[] books, Reader[] readers)
        {
            string[] uncheckedData = File.ReadAllLines(path);

            List<string> correctData = new();
            for (int i = 1; i < uncheckedData.Length; i++)
            {
                string correctness = GetInformationCorrectnessBookReaderData(uncheckedData[i].Split(';'));

                Console.WriteLine($"Информация о {i} строке данных читателей книг: {correctness}");
                if (correctness == "Данные в порядке.")
                {
                    correctData.Add(uncheckedData[i]);
                }
            }

            BookReader[] bookReaders = new BookReader[correctData.Count];
            for (int i = 0; i < correctData.Count; i++)
            {
                string[] lineData = correctData[i].Split(';');

                bookReaders[i] = new BookReader(FindBook(books, int.Parse(lineData[0])),
                    FindReader(readers, int.Parse(lineData[1])),
                    DateTime.Parse(lineData[2]),

                    lineData.Length == 3 ? null : DateTime.Parse(lineData[3]));
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
                return "Количество столбцов данных не совпадает с требуемым количеством.";
            }
            else
            {
                List<int> wrongColumns = new();

                if (!int.TryParse(line[0], out _))
                {
                    wrongColumns.Add(0);
                }

                for (int i = 1; i < 3; i++)
                {
                    if (line[i] == "")
                    {
                        wrongColumns.Add(i);
                    }
                }

                for (int i = 3; i < line.Length; i++)
                {
                    if (!int.TryParse(line[i], out _))
                    {
                        wrongColumns.Add(i);
                    }
                }

                if (wrongColumns.Count > 0)
                {
                    StringBuilder result = new();
                    result.Append("Данные не соответствуют требуемому формату в: ");

                    for (int i = 0; i < wrongColumns.Count; i++)
                    {
                        if (i == wrongColumns.Count - 1)
                        {
                            result.Append((wrongColumns[i] + 1).ToString());
                        }
                        else
                        {
                            result.Append((wrongColumns[i] + 1).ToString() + ", ");
                        }
                    }

                    result.Append(" столбцах(-це).");
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
                return "Количество столбцов данных не совпадает с требуемым количеством.";
            }
            else
            {
                List<int> wrongColumns = new();

                if (!int.TryParse(line[0], out _))
                {
                    wrongColumns.Add(1);
                }

                if (line[1] == "")
                {
                    wrongColumns.Add(2);
                }

                if (wrongColumns.Count > 0)
                {
                    StringBuilder result = new();
                    result.Append("Данные не соответствуют требуемому формату в: ");

                    for (int i = 0; i < wrongColumns.Count; i++)
                    {
                        if (i == wrongColumns.Count - 1)
                        {
                            result.Append(wrongColumns[i]);
                        }
                        else
                        {
                            result.Append(wrongColumns[i] + ", ");
                        }
                    }

                    result.Append(" столбцах(-це).");
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
            if (line.Length < 3 || line.Length > 4)
            {
                return "Количество столбцов данных не совпадает с требуемым количеством.\r\n";
            }
            else
            {
                List<int> wrongColumns = new();

                for (int i = 0; i < 2; i++)
                {
                    if (!int.TryParse(line[i], out _))
                    {
                        wrongColumns.Add(i);
                    }
                }

                for (int i = 2; i < line.Length; i++)
                {
                    if (!DateTime.TryParse(line[i], out _))
                    {
                        wrongColumns.Add(i);
                    }
                }

                if (wrongColumns.Count > 0)
                {
                    StringBuilder result = new();

                    result.Append("Данные не соответствуют требуемому формату в: ");
                    for (int i = 0; i < wrongColumns.Count; i++)
                    {
                        if (i == wrongColumns.Count - 1)
                        {
                            result.Append(wrongColumns[i] + 1);
                        }
                        else
                        {
                            result.Append(wrongColumns[i] + 1 + ", ");
                        }
                    }

                    result.Append(" столбцах(-це).");
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