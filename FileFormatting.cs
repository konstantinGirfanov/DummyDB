using System.Text;

namespace DummyDB
{
    class FileFormatting
    {
        public static string[] GetFormattedBooksData(Book[] books, string columnsName)
        {
            int[] columnsWidth = GetBookColumnsWidth(books, columnsName);
            string[] unformattedData = MakeStringFormatBooks(books, columnsName);

            return FormatColumns(unformattedData, columnsWidth);
        }

        public static string[] GetFormattedReadersData(Reader[] readers, string columnsName)
        {
            int[] columnsWidth = GetReaderColumnsWidth(readers, columnsName);
            string[] unformattedData = MakeStringFormatReaders(readers, columnsName);

            return FormatColumns(unformattedData, columnsWidth);
        }

        public static string[] GetFormattedBookReadersData(BookReader[] bookReaders, string columnsName)
        {
            int[] columnsWidth = GetBookReaderColumnsWidth(bookReaders, columnsName);
            string[] unformattedData = MakeStringFormatBookReaders(bookReaders, columnsName);

            return FormatColumns(unformattedData, columnsWidth);
        }

        public static int[] GetBookColumnsWidth(Book[] books, string columnsName)
        {
            string[] unformattedData = MakeStringFormatBooks(books, columnsName);

            int[] columnsWidth = new int[6];
            for (int i = 0; i < unformattedData.Length; i++)
            {
                columnsWidth[0] = Math.Max(columnsWidth[0], unformattedData[i].Split(';')[0].Length);
                columnsWidth[1] = Math.Max(columnsWidth[1], unformattedData[i].Split(';')[1].Length);
                columnsWidth[2] = Math.Max(columnsWidth[2], unformattedData[i].Split(';')[2].Length);
                columnsWidth[3] = Math.Max(columnsWidth[3], unformattedData[i].Split(';')[3].Length);
                columnsWidth[4] = Math.Max(columnsWidth[4], unformattedData[i].Split(';')[4].Length);
                columnsWidth[5] = Math.Max(columnsWidth[5], unformattedData[i].Split(';')[5].Length);
            }

            return columnsWidth;
        }

        public static int[] GetReaderColumnsWidth(Reader[] readers, string columnsName)
        {
            string[] unformattedData = MakeStringFormatReaders(readers, columnsName);

            int[] columnsWidth = new int[2];
            for (int i = 0; i < readers.Length; i++)
            {
                columnsWidth[0] = Math.Max(columnsWidth[0], unformattedData[i].Split(';')[0].Length);
                columnsWidth[1] = Math.Max(columnsWidth[1], unformattedData[i].Split(';')[1].Length);
            }

            return columnsWidth;
        }

        public static int[] GetBookReaderColumnsWidth(BookReader[] booksReaders, string columnsName)
        {
            string[] unformattedData = MakeStringFormatBookReaders(booksReaders, columnsName);

            int[] columnsWidth = new int[4];
            for (int i = 0; i < unformattedData.Length; i++)
            {
                columnsWidth[0] = Math.Max(columnsWidth[0], unformattedData[i].Split(';')[0].Length);
                columnsWidth[1] = Math.Max(columnsWidth[1], unformattedData[i].Split(';')[1].Length);
                columnsWidth[2] = Math.Max(columnsWidth[2], unformattedData[i].Split(';')[2].Length);
                columnsWidth[3] = Math.Max(columnsWidth[3], unformattedData[i].Split(';')[3].Length);
            }

            return columnsWidth;
        }

        public static string[] MakeStringFormatBooks(Book[] books, string columnsName)
        {
            string[] unformattedData = new string[books.Length + 1];

            unformattedData[0] = columnsName;
            for (int i = 0; i < books.Length; i++)
            {
                unformattedData[i + 1] = books[i].Id.ToString() + ";" +
                    books[i].Name + ";" +
                    books[i].Author + ";" +
                    books[i].Year.ToString() + ";" +
                    books[i].Cupboard.ToString() + ";" +
                    books[i].Shelf.ToString();
            }

            return unformattedData;
        }

        public static string[] MakeStringFormatReaders(Reader[] readers, string columnsName)
        {
            string[] unformattedData = new string[readers.Length + 1];

            unformattedData[0] = columnsName;
            for (int i = 0; i < readers.Length; i++)
            {
                unformattedData[i + 1] = readers[i].Id.ToString() + ";" +
                    readers[i].Name;
            }

            return unformattedData;
        }

        public static string[] MakeStringFormatBookReaders(BookReader[] bookReaders, string columnsName)
        {
            string[] unformattedData = new string[bookReaders.Length + 1];

            unformattedData[0] = columnsName;
            for (int i = 0; i < bookReaders.Length; i++)
            {
                unformattedData[i + 1] = bookReaders[i].Book.Name + ";" +
                    bookReaders[i].Reader.Name + ";" +
                    bookReaders[i].TakingDate.ToString() + ";" +
                    bookReaders[i].ReturnDate.ToString();
            }

            return unformattedData;
        }

        public static string[] FormatColumns(string[] unformattedData, int[] columnsWidth)
        {
            string[] formattedData = new string[unformattedData.Length];

            for (int i = 0; i < unformattedData.Length; i++)
            {
                formattedData[i] = "| ";
                for (int j = 0; j < columnsWidth.Length; j++)
                {
                    formattedData[i] += $"{AddSpace(unformattedData[i].Split(';')[j], columnsWidth[j])} | ";
                }
            }

            return formattedData;
        }

        public static string AddSpace(string text, int width)
        {
            StringBuilder sb = new();
            sb.Append(text);

            for (int i = text.Length; i < width; i++)
            {
                sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}