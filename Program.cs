using System;
using System.Collections.Generic;

namespace Library
{
    // abstract class Person (only used for inheritance)
    abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string name, int age, string phoneNumber)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }

        public Book(string title, string author, string publishDate)
        {
            Title = title;
            Author = author;
            PublishDate = publishDate;
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book added: {book.Title} by {book.Author} (Published: {book.PublishDate})");
        }

        public void RemoveBook(string title)
        {
            Book? book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Book removed: {book.Title} by {book.Author}");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        public void ShowBooks()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("\nBooks available in the library:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} (Published: {book.PublishDate})");
                }
            }
            else
            {
                Console.WriteLine("\nNo books in the library yet.");
            }
        }
    }

    class LibraryManager : Person
    {
        public Library Library { get; private set; }

        public LibraryManager(string name, int age, string phoneNumber, Library library)
            : base(name, age, phoneNumber)
        {
            Library = library;
        }
    }

    class User : Person
    {
        public string LibraryCard { get; set; }

        public User(string name, int age, string phoneNumber, string libraryCard)
            : base(name, age, phoneNumber)
        {
            LibraryCard = libraryCard;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();

            Console.WriteLine("Welcome to the Library System!");
            Console.WriteLine("Select your role:");
            Console.WriteLine("1. Library Manager");
            Console.WriteLine("2. User");
            Console.Write("Enter choice (1 or 2): ");
            string roleChoice = Console.ReadLine();

            if (roleChoice == "1")
            {
                Console.WriteLine("\nEnter your details as Library Manager.");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Age: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.Write("Please enter a valid age: ");
                }
                Console.Write("Phone Number: ");
                string phone = Console.ReadLine();

                LibraryManager manager = new LibraryManager(name, age, phone, lib);
                Console.WriteLine($"\nLogged in as Library Manager: {manager.Name}, Age: {manager.Age}, Phone: {manager.PhoneNumber}");

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nAvailable commands: add, remove, show, exit");
                    Console.Write("Enter command: ");
                    string command = Console.ReadLine().ToLower();

                    switch (command)
                    {
                        case "add":
                            Console.Write("Enter book title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter publish date: ");
                            string publishDate = Console.ReadLine();
                            Book book = new Book(title, author, publishDate);
                            lib.AddBook(book);
                            break;
                        case "remove":
                            Console.Write("Enter book title to remove: ");
                            string removeTitle = Console.ReadLine();
                            lib.RemoveBook(removeTitle);
                            break;
                        case "show":
                            lib.ShowBooks();
                            break;
                        case "exit":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Unknown command. Please try again.");
                            break;
                    }
                }
            }
            else if (roleChoice == "2")
            {
                Console.WriteLine("\nEnter your details as User.");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Age: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.Write("Please enter a valid age: ");
                }
                Console.Write("Phone Number: ");
                string phone = Console.ReadLine();
                Console.Write("Library Card Number: ");
                string card = Console.ReadLine();

                User user = new User(name, age, phone, card);
                Console.WriteLine($"\nLogged in as User: {user.Name}, Age: {user.Age}, Phone: {user.PhoneNumber}, Library Card: {user.LibraryCard}");

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nAvailable commands: show, exit");
                    Console.Write("Enter command: ");
                    string command = Console.ReadLine().ToLower();

                    switch (command)
                    {
                        case "show":
                            lib.ShowBooks();
                            break;
                        case "exit":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Unknown command. Please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid role selected. Exiting...");
            }

            Console.WriteLine("\nThank you for using the Library System. Press any key to exit...");
        }
    }
}
