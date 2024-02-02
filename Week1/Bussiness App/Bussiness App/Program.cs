using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bussiness_App
{
    internal class Program
    {
        static int y = 10;
        static int size = 100;
        static void Main(string[] args)
        {
            int userCount = 0;
            const int arrSize = 1000;
            string []users=new string[arrSize];
            string []passwords=new string[arrSize];
            string []roles=new string[arrSize];
            string[] bikeName = new string[100];
            string[] price = new string[100];
            string[] engine = new string[100];
            string[] milage = new string[100];
            string[] quantity = new string[100];
            int count1 = 0;
            ReadData(users, passwords, roles, ref userCount);
            LoadBikeDataFromFile(bikeName, price, engine, milage, quantity,ref count1);
            int value = 0;
            while (value != 3)
            {
                Header();
                SubHeader("login");
                value = loginMenu();
                if (value == 1)
                {
                   Console.Clear();
                    Header();
                    SubHeader("signIn");
                    string name, password;

                    name = inputName();
                    Console.Write("Enter user Password: ");
                    password = Console.ReadLine();
                    string role = signIn(name, password,  users, passwords, roles, ref userCount);
                    if (role == "Admin" || role == "admin")
                    {
                        AdminInterface(bikeName, price, engine, milage, quantity, ref count1);

                    }
                    if (role == "User" || role == "Coustmer" || role == "user" || role == "coustmer")
                    {
                        UserInterface(bikeName, price, engine, milage, quantity, ref count1);
                    }
                    if (role == "Undefined")
                    {
                        Console.WriteLine("You have entered wrong Username or Password.");
                    }
                }
                if (value == 2) 
                {
                    Console.Clear();
                    Header();
                    SubHeader("signUp");
                    string name, password, role;
                    name = inputName();
                    while (true)
                    {
                        Console.Write("Enter Password:");
                        password = Console.ReadLine(); 
                        int length = password.Length;
                        if (length >= 6)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password");
                        }
                    }
                    while (true)
                    {
                        Console.Write("Enter your role: ");
                         role = Console.ReadLine();
                        if (role == "Admin" || role == "admin" || role == "User" || role == "Coustmer" || role == "user" || role == "coustmer")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Role");
                        }
                    }
                    bool isValid = signUp(name, password, role, users, passwords, roles,ref userCount, arrSize);
                    if (isValid)
                    {
                        Console.WriteLine( "SignedUp Succcessfully") ;
                    }
                    if (!isValid)
                    {
                        Console.WriteLine ( "Sorry! Not Successfully SignedUp \n  User already exist");
                    }
                    

                }
                ClearScreen();

            }
        }
        static int loginMenu()
        {
            string a;
            int option;
            Console.WriteLine("1- Sign IN");
            Console.WriteLine("2- Sign UP");
            Console.WriteLine("3- Exit");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Enter any option...");
                a = Console.ReadLine();
                option = int.Parse(a);

                if (option == 1 || option == 2 || option == 3)
                {
                    return option;
                    
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }
        }
        static string inputName()
        {
            string name;

            while (true)
            {

                Console.Write("Enter user name: ");
               name = Console.ReadLine();
               

                if (checkString(name) && isNameValid(name))
                {
                    return name;
                   
                }
                else
                {
                    Console.WriteLine("Invalid user name");
                }

                Console.WriteLine("                                      ");
            }
        }
        static bool checkString(string name)
        {
            int length = name.Length;

            for (int i = 0; i < length; i++)
            {

                if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') || (name[i] >= '0' && name[i] <= '9') || name[i] == '_'))
                {
                    return false;
                }
            }
            return true;

        }
        static bool isNameValid(string name)
        {
            int length = name.Length;
            if (length >= 3)
            {
                return true;
            }
            return false;
        }
        static bool signUp(string name, string password, string role, string []users, string[] passwords, string[] roles,ref int userCount, int arrSize)
        {
            bool isPresent = false;
            for (int i = 0; i < userCount; i++)
            {
                if (users[i] == name && passwords[i] == password)
                {
                    return isPresent;
                }
            }
                users[userCount] = name;
                passwords[userCount] = password;
                roles[userCount] = role;
                userCount++;
                return true;
        }
         static string signIn(string name, string password, string[] users, string[] passwords, string[] roles, ref int userCount)
        {
            for (int i = 0; i < userCount; i++)
            {
                if (users[i] == name && passwords[i] == password)
                {
                    return roles[i];
                }
            }
            return "Undefined";
        }
        static int adminMenu()
        {
            
            Console.WriteLine( "Select one of the following options number..." );
            Console.WriteLine("1-View detail of bikes ");
            Console.WriteLine("2-Add new data ");
            Console.WriteLine("3-Remove data  ");
            Console.WriteLine ("4-Change the price ");
            Console.WriteLine("5-Change the quantity ");
            Console.WriteLine("6-Discount data ");
            Console.WriteLine("7- Exit ");
            while (true)
            {
                string option;
                Console.WriteLine("Your Option..");
                option = Console.ReadLine();

                if (option == "1" || option == "2" || option == "3" || option == "4" || option == "5" || option == "6" || option == "7")
                {
                    return Convert.ToInt32(option);
                }
                else
                {
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("Invalid Option");
                }

                Console.WriteLine("                                 ");

            }
        }
        static void AdminInterface(string[] bikeName, string[] price, string[] engine, string[] milage, string[] quantity, ref int count1)
        {
            int adminOption = 0;

            while (adminOption != 7)
            {
                Console.Clear();
                Header();
                SubMenu("");
                adminOption = adminMenu();

                if (adminOption == 1)
                {
                    int y = 10;
                    Console.Clear();
                    Header();
                    SubMenu("View");
                    Console.WriteLine("NO.\tName\t\tPrice(PKR)\tEngine(CC)\tMilage(kmpl)\tQuantity");

                    for (int i = 0; i < count1; i++)
                    {
                        Console.WriteLine($"{i + 1}\t{bikeName[i]}\t\t{price[i]}\t\t{engine[i]}\t\t{milage[i]}\t\t{quantity[i]}");
                        y++;
                    }
                }
                else if (adminOption == 2)
                {
                    AddNewBike(bikeName, price, engine, milage, quantity, ref count1, size);
                    StoreBikeDataToFile(bikeName, price, engine, milage, quantity, count1);
                }
                else if (adminOption == 3)
                {
                     RemoveBike(bikeName, price, engine, milage, quantity, ref count1);
                     StoreBikeDataToFile(bikeName, price, engine, milage, quantity, count1);
                }
                else if (adminOption == 4)
                {
                    ChangePrice(bikeName, price, count1);
                }
                else if (adminOption == 5)
                {
                    ChangeQuantity(bikeName, quantity, count1);
                }
                else if (adminOption == 6)
                {
                    Discount();
                }

                ClearScreen();
            }
        }
        static void AddNewBike(string[] bikeName, string[] price, string[] engine, string[] milage, string[] quantity, ref int count1, int size)
        {
            if (count1 < size)
            {
                Console.Clear();
                Header();
                SubMenu("Add New Bike");

                Console.Write("Enter Bike Name: ");
                string newName = Console.ReadLine();

                Console.Write("Enter Price (PKR): ");
                string newPrice = Console.ReadLine();

                Console.Write("Enter Engine (CC): ");
                string newEngine = Console.ReadLine();

                Console.Write("Enter Milage (kmpl): ");
                string newMilage = Console.ReadLine();

                Console.Write("Enter Quantity: ");
                string newQuantity = Console.ReadLine();

                bikeName[count1] = newName;
                price[count1] = newPrice;
                engine[count1] = newEngine;
                milage[count1] = newMilage;
                quantity[count1] = newQuantity;

                count1++;

                Console.WriteLine("Bike added successfully!");
            }
            else
            {
                Console.WriteLine("Cannot add more bikes. Array size exceeded.");
            }
        }
        static void RemoveBike(string[] bikeName, string[] price, string[] engine, string[] milage, string[] quantity, ref int count1)
        {
            Console.Clear();
            Header();
            SubMenu("Remove Bike");

            Console.Write("Enter the index of the bike you want to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index = index - 1;

                if (index >= 0 && index < count1)
                {
                    for (int i = index; i < count1 - 1; ++i)
                    {
                        bikeName[i] = bikeName[i + 1];
                        price[i] = price[i + 1];
                        engine[i] = engine[i + 1];
                        milage[i] = milage[i + 1];
                        quantity[i] = quantity[i + 1];
                    }

                    count1--;
                    Console.WriteLine("Bike removed successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid index. Please enter a valid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid index.");
            }
        }
        static string ChangePrice(string[] bikeName, string[] price, int count1)
        {
            Console.Clear();
            Header();
            SubMenu("Change price");

            Console.Write("Enter the index of the bike whose price you want to change: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index = index - 1;

                if (index >= 0 && index < count1)
                {
                    while (true)
                    {
                        Console.SetCursorPosition(0, 11);
                        Console.Write("Enter the new price (PKR): ");
                        string newPrice = Console.ReadLine();

                        if (CheckPrice(newPrice))
                        {
                            price[index] = newPrice;
                            Console.WriteLine("Price updated successfully!");
                            return price[index];
                        }
                        else
                        {
                            Console.WriteLine("Invalid Price");
                        }

                        Console.SetCursorPosition(0, 11);
                        Console.Write(new string(' ', 31));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index. Please enter a valid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid index.");
            }

            return null;
        }

        static bool CheckPrice(string price)
        {
            foreach (char c in price)
            {
                if (!(char.IsDigit(c) || c == '.')) 
                {
                    return false;
                }
            }
            return true;
        }
        static bool CheckQuantity(string quantity)
        {
            foreach (char c in quantity)
            {
                if ((char.IsLetter(c) || c == '_'))
                {
                    return false;
                }
            }
            return true;
        }

        static string ChangeQuantity(string[] bikeName, string[] quantity, int count1)
        {
            Console.Clear();
            Header();
            SubMenu("Change Quantity");

            Console.Write("Enter the index of the bike whose quantity you want to change: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index = index - 1;

                if (index >= 0 && index < count1)
                {
                    while (true)
                    {
                        Console.SetCursorPosition(0, 11);
                        Console.Write("Enter the new quantity: ");
                        string newQuantity = Console.ReadLine();

                        if (CheckQuantity(newQuantity))
                        {
                            quantity[index] = newQuantity;
                            Console.WriteLine("Quantity updated successfully!");
                            return quantity[index];
                        }
                        else
                        {
                            Console.WriteLine("Invalid Quantity");
                        }

                        Console.SetCursorPosition(0, 11);
                        Console.Write(new string(' ', 28));
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index. Please enter a valid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid index.");
            }

            return null;
        }
        static void Discount()
        {
            Console.Clear();
            Header();
            SubMenu("Discount detail");

            Console.WriteLine("Following is the detail of discount." + Environment.NewLine);
            Console.WriteLine("1-   If you are a regular customer, you will get 5% discount on any bike you purchase and 4% for new customers.");
            Console.WriteLine("2-   For regular customers, there will be 12% discount on buying two bikes at a time and 18% on buying three bikes at a time. For new customers, it's 8% and 12%, respectively.");
            Console.WriteLine("3-   20% discount on buying more than three bikes at a time.");
        }
        static void UserInterface(string[] bikeName, string[] price, string[] engine, string[] milage, string[] quantity, ref int count1)
        {
            int userOption = 0;

            while (userOption != 6)
            {
                Console.Clear();
                Header();
                SubMenu("");
                userOption = UserMenu();

                if (userOption == 1)
                {
                    ViewBikes(bikeName, price, engine, milage, quantity, count1);
                }
                else if (userOption == 2)
                {
                    BuyBike(bikeName, price, engine, milage, quantity, count1);
                    StoreBikeDataToFile(bikeName, price, engine, milage, quantity, count1);
                }
                else if (userOption == 3)
                {
                    CheckDiscountList();
                }
                else if (userOption == 4)
                {
                    CheckPriceAfterDiscount(bikeName, price, quantity, count1);
                }
                else if (userOption == 5)
                {
                    LeaveComment();
                }

                ClearScreen();
            }
        }

        static int UserMenu()
        {
            string option;
            Console.WriteLine("Select one of the following options number...");
            Console.WriteLine("1-View detail of bikes ");
            Console.WriteLine("2-Buy new bike ");
            Console.WriteLine("3-Check the discount list ");
            Console.WriteLine("4-Check the price after discount ");
            Console.WriteLine("5-Leave a Comment");
            Console.WriteLine("6- Exit");

            while (true)
            {

                Console.SetCursorPosition(0, 18);
                Console.Write("Your Option..");
                option = Console.ReadLine();

                if (option == "1" || option == "2" || option == "3" || option == "4" || option == "5" || option == "6")
                {
                    return Convert.ToInt32(option);
                }
                else
                {
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("Invalid Option");
                }

                Console.SetCursorPosition(0, 18);
                Console.Write(new string(' ', 15));
            }
        }

        static void ViewBikes(string[] bikeName, string[] price, string[] engine, string[] milage, string[] quantity, int count1)
        {
            int y = 10;

            Console.Clear();
            Header();
            SubMenu("View");
            Console.WriteLine("NO.\tName\t\tPrice(PKR)\tEngine(CC)\tMilage(kmpl)\tQuantity");

            for (int i = 0; i < count1; i++)
            {
                Console.WriteLine($"{i + 1}\t{bikeName[i]}\t\t{price[i]}\t\t{engine[i]}\t\t{milage[i]}\t\t{quantity[i]}");
                y++;
            }
        }

        static void BuyBike(string[] bikeName, string[] price, string[] engine, string[] milage, string[] quantity, int count1)
        {
            Console.Clear();
            Header();
            SubMenu("Buy Bike");

            Console.Write("Enter the index of the bike you want to buy: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index = index - 1;

                if (index >= 0 && index < count1)
                {
                    Console.Write("Enter the quantity you want to buy: ");
                    if (int.TryParse(Console.ReadLine(), out int quantityToBuy))
                    {
                        if (quantityToBuy <= Convert.ToInt32(quantity[index]))
                        {
                            int totalPrice = Convert.ToInt32(price[index]) * quantityToBuy;

                            Console.WriteLine($"Total Price: PKR {totalPrice}");
                            Console.WriteLine("Thank you for your purchase!");

                            quantity[index] = (Convert.ToInt32(quantity[index]) - quantityToBuy).ToString();
                        }
                        else
                        {
                            Console.WriteLine("Sorry, the requested quantity is not available.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid quantity.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index. Please enter a valid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid index.");
            }
        }

        static void CheckDiscountList()
        {
            Console.Clear();
            Header();
            SubMenu("Discount List");

            Console.WriteLine("Following is the detail of the discounts available:" + Environment.NewLine);
            Console.WriteLine("1. Regular customers get a 5% discount on any purchased bike.");
            Console.WriteLine("2. New customers get a 4% discount on their bike purchases.");
            Console.WriteLine("3. Additional discounts for regular customers buying multiple bikes.");
            Console.WriteLine("4. Special discount of 20% on buying more than three bikes at a time.");
        }

        static void CheckPriceAfterDiscount(string[] bikeName, string[] price, string[] quantity, int count1)
        {
            Console.Clear();
            Header();
            SubMenu("Price After Discount");

            Console.Write("Enter the index of the bike you want to check the price for: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index = index - 1;

                if (index >= 0 && index < count1)
                {
                    int regularCustomerDiscount = 5;
                    int newCustomerDiscount = 4;

                    int bikePrice = Convert.ToInt32(price[index]);
                    int totalPrice;

                    Console.Write("Are you a 'Regular' or 'New' customer? ");
                    string userType = Console.ReadLine();

                    if (userType == "Regular")
                    {
                        totalPrice = bikePrice - (bikePrice * regularCustomerDiscount / 100);
                    }
                    else if (userType == "New")
                    {
                        totalPrice = bikePrice - (bikePrice * newCustomerDiscount / 100);
                    }
                    else
                    {
                        Console.WriteLine("Invalid customer type entered!");
                        return;
                    }

                    Console.WriteLine($"The price after discount for {bikeName[index]} is PKR {totalPrice}");
                }
                else
                {
                    Console.WriteLine("Invalid index. Please enter a valid index.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid index.");
            }
        }

        static void LeaveComment()
        {
            Console.Clear();
            Header();
            SubMenu("Leave a Comment");

            Console.Write("Enter your comment: ");
            string newComment = Console.ReadLine();

            Console.WriteLine("Comment added successfully!");
        }
        static void Header()
        {
            Console.WriteLine("/================================================================\\ ");
            Console.WriteLine("|| _  _   _  _   _            _____  _____  _____  ___    ___   ||");
            Console.WriteLine("||(_)( ) ( )( ) ( )   /'\\_/`\\(  _  )(_   _)(  _  )|  _`\\ (  _`\\ ||");
            Console.WriteLine("||| || |_| || |_| |   |     || ( ) |  | |  | ( ) || (_) )| (_(_)||");
            Console.WriteLine("||| ||  _  ||  _  |   | (_) || | | |  | |  | | | || ,  / `\\__ \\ ||");
            Console.WriteLine("||| || | | || | | |   | | | || (_) |  | |  | (_) || |\\ \\ ( )_) |||");
            Console.WriteLine("||(_)(_) (_)(_) (_)   (_) (_)(_____)  (_)  (_____)(_) (_)`\\____)||");
            Console.WriteLine("\\================================================================/");
        }

        static void SubMenu(string submenu)
        {
            string message = "Main Menu > " + submenu + " Menu";
            Console.WriteLine(message);
            Console.WriteLine("---------------------");
        }

        static void SubMenu1(string subMenu1)
        {
            string message = "Main Menu > View > " + subMenu1;
            Console.WriteLine(message);
            Console.WriteLine("-------------------------");
        }
        static void SubHeader(string submenu)
        {
            string message = submenu + " Menu";
            Console.WriteLine(message);
            Console.WriteLine("---------------------");
        }
        static void ClearScreen()
        {
            Console.WriteLine("Press Any Key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }
        static void LoadBikeDataFromFile(string[] bikeName, string[] price, string[] engine, string[] milage, string[] quantity, ref int count)
        {
            string filePath = "bike_data.txt";

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int index = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("Bike Name: "))
                        {
                            bikeName[index] = line.Substring(11);
                        }
                        else if (line.Contains("Price: "))
                        {
                            price[index] = line.Substring(7);
                        }
                        else if (line.Contains("Engine: "))
                        {
                            engine[index] = line.Substring(8);
                        }
                        else if (line.Contains("Milage: "))
                        {
                            milage[index] = line.Substring(8);
                        }
                        else if (line.Contains("Quantity: "))
                        {
                            quantity[index] = line.Substring(10);
                            index++;
                        }
                    }

                    count = index;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }
        static void ReadData(string[] usernames, string[] passwords, string[] roles, ref int userCount)
        {
            string filePath = "Users.txt";

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string record;

                    while ((record = reader.ReadLine()) != null)
                    {
                        if (record.Count(c => c == ',') != 2)
                        {
                            continue;
                        }

                        usernames[userCount] = GetField(record, 1);
                        passwords[userCount] = GetField(record, 2);
                        roles[userCount] = GetField(record, 3);

                        userCount++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
        }

        static void StoreData(string[] usernames, string[] passwords, string[] roles, int userCount)
        {
            string filePath = "Users.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    for (int i = 0; i < userCount; i++)
                    {
                        writer.WriteLine($"{usernames[i]},{passwords[i]},{roles[i]}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error writing to file: {e.Message}");
            }
        }

        static string GetField(string record, int field)
        {
            int commaCount = 1;
            string item = "";

            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[x];
                }
            }

            return item;
        }
        static void StoreBikeDataToFile(string[] bikeName, string[] price, string[] engine, string[] milage, string[] quantity, int count)
        {
            string filePath = "bike_data.txt";

            try
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    for (int i = 0; i < count; ++i)
                    {
                        file.WriteLine($"Bike Name: {bikeName[i]}");
                        file.WriteLine($"Price: {price[i]}");
                        file.WriteLine($"Engine: {engine[i]}");
                        file.WriteLine($"Milage: {milage[i]}");
                        file.WriteLine($"Quantity: {quantity[i]}");
                        file.WriteLine("---------------------------------------");
                    }
                }

                Console.WriteLine("Data written to file successfully.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error writing to file: {e.Message}");
            }
        }

    }
}

   

