using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientific
{
    internal class Program
    {
            static void Main(string[] args)
            {

                float v1 = 0;
                float v2 = 0;
                Calculator calculator = new Calculator(v1, v2);
                while (true)
                {
                    Console.Clear();
                    int a = menu();

                    if (a == 1)
                    {
                        Console.Clear();
                        calculator = new Calculator(10, 10);
                        Console.WriteLine("Object created successfully");
                    }
                    if (a == 2)
                    {
                        Console.Clear();
                        calculator.changeAttributes();
                    }
                    if (a == 3)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.add());
                    }
                    if (a == 4)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.subtract());
                    }
                    if (a == 5)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.division());
                    }
                    if (a == 6)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.multiply());
                    }
                    if (a == 7)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.modulo());
                    }
                    if (a == 8)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.sqrt());
                    }
                    if(a == 9)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.exponenet());
                    }
                    if (a == 10)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.Log());
                    }
                    if(a == 11)
                    {
                        Console.Clear();
                        Console.WriteLine(calculator.trignomerticFun());
                    }
                    if(a == 12)
                    {
                        Console.Clear();
                    }
                    Console.ReadKey();

                }
            }
            static int menu()
            {
                int option;
                Console.WriteLine("1-Create a Single Object of Calculator");
                Console.WriteLine("2-Change values of Attributes");
                Console.WriteLine("3-ADD");
                Console.WriteLine("4-Subtract");
                Console.WriteLine("5-Division");
                Console.WriteLine("6-Multiplication");
                Console.WriteLine("7-Modulo");
                Console.WriteLine("8-Square Root");
                Console.WriteLine("9-Exponential Function");
                Console.WriteLine("10-Logarthim");
                Console.WriteLine("11-Trignometric functions");
                Console.WriteLine("12-Exit");
                Console.Write("Enter any option: ");
                option = int.Parse(Console.ReadLine());
                if (option > 0 && option < 14)
                {
                    return option;
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                    return 0;
                }
            }
        }
    }



