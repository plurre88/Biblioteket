using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteket
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = CreateBooks();
            while (true)
            {
                UserInput(books);
            }
        }
        private static List<Book> CreateBooks()
        {
            List<Book> books = new List<Book>();

            books.Add(new Faktabok("Bilar","Sven Svensson",250,"teknik",3));
            books.Add(new Faktabok("Europas karta genom historien", "Åke Åkesson", 160, "geografi", 1));
            books.Add(new Barnbok("Bert", "Anders Jacobsson och Sören Olsson", 115, true, false));
            books.Add(new Barnbok("Mumin", "Tove Jansson", 98, false, true));
            books.Add(new Underhållning("Små Sagor", "Karl Karlsson", 195, "fantasy", false));
            books.Add(new Underhållning("WOOW", "Britta Brittasdotter", 485, "krälek", true));

            return books;
        }
        private static void PrintAllBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Titel: {book.titel}. Författare: {book.author}. Sidor: {book.pages}. {book.ToString()}");
            }
        }
        private static void UserInput(List<Book> books)
        {
            Console.Clear();

            Console.WriteLine("MENY: Vilken genre till du skriva ut? [A]LLA. [F]AKTABÖCKER. [B]ARNBÖCKER. [U]NDERHÅLLNING. [Q]UIT.");

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case 'f':
                    PrintFBooks(books);
                    break;
                case 'b':
                    PrintBBooks(books);
                    break;
                case 'u':
                    PrintUBooks(books);
                    break;
                case 'a':
                    PrintAllBooks(books);
                    break;
                case 'q':
                    Environment.Exit(0);
                    break;
            }
            Console.ReadKey();
        }
        private static void PrintFBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                if (book is Faktabok)
                {
                    Console.WriteLine($"Titel: {book.titel}. Författare: {book.author}. Sidor: {book.pages}. {book.ToString()}");
                }
            }
        }
        private static void PrintBBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                if (book is Barnbok)
                {
                    Console.WriteLine($"Titel: {book.titel}. Författare: {book.author}. Sidor: {book.pages}. {book.ToString()}");
                }
            }
        }
        private static void PrintUBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                if (book is Underhållning)
                {
                    Console.WriteLine($"Titel: {book.titel}. Författare: {book.author}. Sidor: {book.pages}. {book.ToString()}");
                }
            }
        }
    }
    class Book
    {
        public string titel;
        public string author;
        public int pages;

        public Book(string titelName, string authorName, int numberOfPages)
        {
            titel = titelName;
            author = authorName;
            pages = numberOfPages;
        }
    }
    class Faktabok : Book
    {
        public string subject;
        public int difficultyLevel;

        public Faktabok(string titelName, string authorName, int numberOfPages, string subjektName, int diffLvl) :base(titelName,authorName,numberOfPages)
        {
            subject = subjektName;
            difficultyLevel = diffLvl;
        }
        public override string ToString()
        {
            return $"Ämne: {subject}. Svårighetsgrad: {difficultyLevel}";
        }
    }
    class Barnbok : Book
    {
        public bool teenageBook;
        public bool pictureBook;

        public Barnbok(string titelName, string authorName, int numberOfPages, bool teenageBook, bool pictureBook) : base(titelName, authorName, numberOfPages)
        {
            this.teenageBook = teenageBook;
            this.pictureBook = pictureBook;
        }
        public override string ToString()
        {
            return $"Tonårsbok/Barnbok: {(teenageBook ? "Tonårsbok" : "Barnbok")}. Bilderbok: {(pictureBook ? "JA" : "NEJ")}.";
        }
    }
    class Underhållning : Book
    {
        public string genre;
        public bool novell;

        public Underhållning(string titelName, string authorName, int numberOfPages, string genreName, bool novell) : base(titelName, authorName, numberOfPages)
        {
            genre = genreName;
            this.novell = novell;
        }
        public override string ToString()
        {
            return $"Genre: {genre}, Roman/Antologi: {(novell ? "Roman":"Antologi")}";
        }
    }
}
