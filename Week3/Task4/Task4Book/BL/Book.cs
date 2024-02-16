using System;
using System.Collections.Generic;

namespace Task4Book
{
    class Book
    {
        public string Title;
        public string Author;
        public int PublicationYear;
        public double Price;
        public int QuantityInStock;

        public Book(string title, string author, int publicationYear, double price, int quantityInStock)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            Price = price;
            QuantityInStock = quantityInStock;
        }

        public string GetTitle()
        {
            return $"Title: {Title}";
        }

        public string GetAuthor()
        {
            return $"Author: {Author}";
        }

        public string GetPublicationYear()
        {
            return $"Publication Year: {PublicationYear}";
        }

        public string GetPrice()
        {
            return $"Price: {Price}";
        }

        public void SellCopies(int numberOfCopies)
        {
            if (QuantityInStock >= numberOfCopies)
            {
                QuantityInStock -= numberOfCopies;
                Console.WriteLine($"{numberOfCopies} copies sold. Remaining stock: {QuantityInStock}");
            }
            else
            {
                Console.WriteLine($"Error: Not enough copies in stock. Available: {QuantityInStock}");
            }
        }

        public void Restock(int additionalCopies)
        {
            QuantityInStock += additionalCopies;
            Console.WriteLine($"{additionalCopies} copies added to stock. Total stock: {QuantityInStock}");
        }

        public string BookDetails()
        {
            return $"Title: {Title}, Author: {Author}, Publication Year: {PublicationYear}, Price: {Price:C}, Quantity in Stock: {QuantityInStock}";
        }
    }
}