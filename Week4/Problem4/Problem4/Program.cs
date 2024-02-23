using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Product> products = new List<Product>();
            string path = "..\\..\\Users.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Error : File not found");
                Console.ReadKey();
                Environment.Exit(0);
            }
            readUsersFromFile(path, users);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.Write("Input: ");
                string option = Console.ReadLine();
                Console.Clear();
                if (option == "1")
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    Console.Write("Enter role: ");
                    string role = Console.ReadLine();
                    if (username.Length != 0 && password.Length != 0 && (role == "admin" || role == "customer"))
                    {
                        User newUser = new User(username, password, role);
                        addUserToList(users, newUser);
                        addUserToFile(path, newUser);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Console.ReadKey();
                    }
                }
                else if (option == "2")
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    Console.Write("Enter role: ");
                    string role = Console.ReadLine();
                    User user = new User(username, password, role);
                    if (user.SignIn(users, user))
                    {
                        Console.WriteLine("Sign in successful");
                        Console.ReadKey();
                        if (role == "admin")
                        {
                            while (true)
                            {
                                Console.Clear();
                                string option2 = productMenu();
                                Console.Clear();
                                if (option2 == "c")
                                {
                                    createProduct(products);
                                }
                                else if (option2 == "r")
                                {
                                    retrieveProducts(products);
                                }
                                else if (option2 == "u")
                                {
                                    updateProduct(products);
                                }
                                else if (option2 == "d")
                                {
                                    Console.Write("Enter product's name: ");
                                    string name = Console.ReadLine();
                                    Product product = new Product();
                                    if (product.validProduct(products, name) != 0)
                                    {
                                        product.deleteProduct(products, product.validProduct(products, name));
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else if (role == "customer")
                        {

                        }
                    }
                    else
                    {
                        Console.WriteLine("Sign in failed");
                        Console.ReadKey();
                    }
                }
            }
        }

        static void addUserToList(List<User> users, User user)
        {
            users.Add(user);
        }

        static void addUserToFile(string path, User user)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(user.username + "," + user.password + "," + user.role);
            writer.Flush();
            writer.Close();
        }

        static void readUsersFromFile(string path, List<User> users)
        {
            StreamReader reader = new StreamReader(path);
            string line, username, role, password;
            while ((line = reader.ReadLine()) != null)
            {
                username = getField(line, 1);
                password = getField(line, 2);
                role = getField(line, 3);
                User user = new User(username, password, role);
                addUserToList(users, user);
            }
            reader.Close();
        }

        static string getField(string record, int index)
        {
            int commaCount = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                    continue;
                }
                if (commaCount == index)
                {
                    item += record[i];
                }
            }
            return item;
        }

        static string productMenu()
        {
            Console.WriteLine("Create Product");
            Console.WriteLine("Retrieve Product");
            Console.WriteLine("Update Product");
            Console.WriteLine("Delete Product");
            Console.Write("Your option: ");
            string option = Console.ReadLine();
            return option;
        }

        static void createProduct(List<Product> products)
        {
            Console.Write("Enter Prodcut's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product's price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter Product's quantity: ");
            double quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Product's brand name: ");
            string brandName = Console.ReadLine();
            Product product = new Product(name, price, quantity, brandName);
            products.Add(product);
        }

        static void retrieveProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine(product.name + " " + product.price + " " + product.quantity + " " + product.brandName);
            }
            Console.ReadKey();
        }

        static void updateProduct(List<Product> products)
        {
            Product product = new Product();
            Console.Write("Which product you want to change (name): ");
            string name = Console.ReadLine();
            int index = product.validProduct(products, name);
            if (index != 0)
            {
                Console.Write("Which attribute you want to change (n, p, q, b): ");
                string attribute = Console.ReadLine();
                Console.Write($"Enter new {attribute} for {name}: ");
                conditions(products, attribute, index);
                products.RemoveAt(index);
                products.Insert(index, product);
            }
        }

        static void conditions(List<Product> products, string attribute, int index)
        {
            Product product = new Product();
            if (attribute == "n")
            {
                product.name = Console.ReadLine();
                product.price = products[index].price;
                product.quantity = products[index].quantity;
                product.brandName = products[index].brandName;
            }
            else if (attribute == "b")
            {
                product.name = products[index].name;
                product.price = products[index].price;
                product.quantity = products[index].quantity;
                product.brandName = Console.ReadLine();
            }
            else if (attribute == "p")
            {
                product.name = products[index].name;
                product.price = double.Parse(Console.ReadLine());
                product.quantity = products[index].quantity;
                product.brandName = products[index].brandName;
            }
            else if (attribute == "q")
            {
                product.name = products[index].name;
                product.price = products[index].quantity;
                product.quantity = double.Parse(Console.ReadLine());
                product.brandName = products[index].brandName;
            }
        }
    }
}
