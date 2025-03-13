
namespace LibraryManagementSystem
{
    class Program
    {
        
        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public bool IsAvailable { get; set; } = true; 
        }

        static void Main(string[] args)
        {
            List<Book> books = new List<Book>(); //List 

            while (true)
            {
                Console.WriteLine("\nLibrary Book Management System");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Find a Book by ID");
                Console.WriteLine("4. Borrow a Book");
                Console.WriteLine("5. Return a Book");
                Console.WriteLine("6. Remove a Book");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddBook(books);
                        break;
                    case 2:
                        ViewAllBooks(books);
                        break;
                    case 3:
                        FindBookById(books);
                        break;
                    case 4:
                        BorrowBook(books);
                        break;
                    case 5:
                        ReturnBook(books);
                        break;
                    case 6:
                        RemoveBook(books);
                        break;
                    case 7:
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void AddBook(List<Book> books)
        {
            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            books.Add(new Book { BookId = bookId, Title = title, Author = author });
            Console.WriteLine($"Book '{title}' added successfully!");
        }

        static void ViewAllBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Available: {(book.IsAvailable ? "Yes" : "No")}");
            }
        }

        static void FindBookById(List<Book> books)
        {
            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());

            var book = books.Find(b => b.BookId == bookId);
            if (book != null)
            {
                Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Available: {(book.IsAvailable ? "Yes" : "No")}");
            }
            else
            {
                Console.WriteLine($"No book found with ID {bookId}.");
            }
        }

        static void BorrowBook(List<Book> books)
        {
            Console.Write("Enter Book ID to borrow: ");
            int bookId = int.Parse(Console.ReadLine());

            var book = books.Find(b => b.BookId == bookId);
            if (book != null)
            {
                if (book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine($"You have borrowed '{book.Title}'.");
                }
                else
                {
                    Console.WriteLine($"Book '{book.Title}' is already borrowed.");
                }
            }
            else
            {
                Console.WriteLine($"No book found with ID {bookId}.");
            }
        }

        static void ReturnBook(List<Book> books)
        {
            Console.Write("Enter Book ID to return: ");
            int bookId = int.Parse(Console.ReadLine());

            var book = books.Find(b => b.BookId == bookId);
            if (book != null)
            {
                if (!book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.WriteLine($"You have returned '{book.Title}'.");
                }
                else
                {
                    Console.WriteLine($"Book '{book.Title}' was not borrowed.");
                }
            }
            else
            {
                Console.WriteLine($"No book found with ID {bookId}.");
            }
        }

        static void RemoveBook(List<Book> books)
        {
            Console.Write("Enter Book ID to remove: ");
            int bookId = int.Parse(Console.ReadLine());

            var book = books.Find(b => b.BookId == bookId);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Book '{book.Title}' removed successfully!");
            }
            else
            {
                Console.WriteLine($"No book found with ID {bookId}.");
            }
        }
    }
}



