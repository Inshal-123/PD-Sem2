using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>();

            Console.WriteLine("Welcome to Book Inventory Management System!");

            int choice;
            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books Information");
                Console.WriteLine("3. Get Author Details of a Specific Book");
                Console.WriteLine("4. Sell Copies of a Specific Book");
                Console.WriteLine("5. Restock a Specific Book");
                Console.WriteLine("6. See the Count of the Books");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBook(bookList);
                        break;
                    case 2:
                        ViewAllBooks(bookList);
                        break;
                    case 3:
                        GetAuthorDetails(bookList);
                        break;
                    case 4:
                        SellCopiesOfBook(bookList);
                        break;
                    case 5:
                        RestockBook(bookList);
                        break;
                    case 6:
                        Console.WriteLine($"Total books in inventory: {bookList.Count}");
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 7);
        }

        static void AddBook(List<Book> bookList)
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Publication Year: ");
            int publicationYear = int.Parse(Console.ReadLine());
            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter Quantity in Stock: ");
            int quantityInStock = int.Parse(Console.ReadLine());

            Book newBook = new Book(title, author, publicationYear, price, quantityInStock);
            bookList.Add(newBook);

            Console.WriteLine("Book added successfully!");
        }

        static void ViewAllBooks(List<Book> bookList)
        {
            Console.WriteLine("All Books Information:");
            foreach (Book book in bookList)
            {
                Console.WriteLine(book.BookDetails());
            }
        }

        static void GetAuthorDetails(List<Book> bookList)
        {
            Console.Write("Enter Title of the book: ");
            string title = Console.ReadLine();

            Book book = bookList.Find(b => b.Title == title);
            if (book != null)
            {
                Console.WriteLine(book.GetAuthor());
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void SellCopiesOfBook(List<Book> bookList)
        {
            Console.Write("Enter Title of the book: ");
            string title = Console.ReadLine();
            Console.Write("Enter Number of Copies to Sell: ");
            int numberOfCopies = int.Parse(Console.ReadLine());

            Book book = bookList.Find(b => b.Title == title);
            if (book != null)
            {
                book.SellCopies(numberOfCopies);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void RestockBook(List<Book> bookList)
        {
            Console.Write("Enter Title of the book: ");
            string title = Console.ReadLine();
            Console.Write("Enter Number of Copies to Restock: ");
            int additionalCopies = int.Parse(Console.ReadLine());

            Book book = bookList.Find(b => b.Title == title);
            if (book != null)
            {
                book.Restock(additionalCopies);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}
