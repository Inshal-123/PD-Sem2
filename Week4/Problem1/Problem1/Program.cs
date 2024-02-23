using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            Angle latitude = new Angle();
            Angle longitude = new Angle();
            string shipNumber, option;
            while (true)
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option=="1")
                {
                    Console.Write("Enter the ship number:- ");                  
                    shipNumber = Console.ReadLine();
                    Console.WriteLine("Enter the ship latitude: ");
                    latitude = angleInput("latitude");
                    Console.WriteLine("Enter the ship longitude: ");
                    longitude = angleInput("longitude");
                    Ship ship = new Ship(shipNumber, latitude, longitude);
                    addShip(ships, ship);
                }
                else if(option=="2")
                {
                    Console.Write("Enter the ship number:- ");
                    shipNumber = Console.ReadLine();
                    if(shipExists(ships, shipNumber)!=-1)
                    {
                        Console.WriteLine(ships[shipExists(ships, shipNumber)].angleValue());
                        Console.ReadKey();
                    }
                    else
                    {
                        continue;
                    }    
                }
                else if (option == "3")
                {
                    Console.WriteLine("Enter the ship latitude: ");
                    latitude = angleInput("latitude");
                    Console.WriteLine("Enter the ship longitude: ");
                    longitude = angleInput("longitude");
                    int x = findShip(ships, latitude, longitude);
                    if (x!=-1)
                    {
                        Console.WriteLine("Ship name: "+ships[x].ShipName);
                        Console.ReadKey();
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (option == "4")
                {
                    Console.Write("Enter the ship number:- ");
                    shipNumber = Console.ReadLine();
                    if (shipExists(ships, shipNumber) != -1)
                    {
                        Console.WriteLine("Enter the ship latitude: ");
                        latitude = angleInput("latitude");
                        Console.WriteLine("Enter the ship longitude: ");
                        longitude = angleInput("longitude");
                        ships[shipExists(ships, shipNumber)].updateShip(latitude, longitude);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (option == "5")
                {
                    Environment.Exit(0);
                }
                else
                {
                    continue;
                }
            }
        }

        static string menu()
        {
            Console.Write("1. Add Ship\r\n2. View Ship Position\r\n3. View Ship Serial Number\r\n4. Change Ship Position\r\n5. Exit\r\nChoose one of the option: ");
            string option = Console.ReadLine();
            return option;
        }


        static Angle angleInput(string type)
        {

            Console.Write("Enter the degree: ");
            int degree = int.Parse(Console.ReadLine());
            Console.Write("Enter the minutes: ");
            double minutes = double.Parse(Console.ReadLine());
            Console.Write("Enter the direction: ");
            char direction = Convert.ToChar(Console.ReadLine());
            Angle angle = new Angle(degree, minutes, direction, type);
            return angle;
        }

        static void addShip(List <Ship> ships, Ship ship)
        {
            ships.Add(ship);
        }

        static int shipExists(List<Ship> ships, string ship)
        {
            for(int i = 0; i < ships.Count; i++)
            {

                if (ship == ships[i].ShipName)
                {
                    return i;
                }
            }
            return -1;
        }
   
        static int findShip(List<Ship>ships,Angle latitude, Angle longitude)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].latitude.Minutes == latitude.Minutes && ships[i].latitude.Degrees == latitude.Degrees && ships[i].latitude.Direction == latitude.Direction && ships[i].longitude.Degrees == longitude.Degrees && ships[i].longitude.Minutes == longitude.Minutes && ships[i].longitude.Direction == longitude.Direction)
                {
                    return i;
                }
            }
            return -1;
        }
        
    }
}
