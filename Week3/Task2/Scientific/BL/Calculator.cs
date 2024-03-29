﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scientific
{
    internal class Calculator
    {
        public float number1;
        public float number2;
        public Calculator(float v1, float v2)
        {
            number1 = v1;
            number2 = v2;


        }
        public void makeObject()
        {
            Calculator calculator1 = new Calculator(number1, number2);

        }
        public void changeAttributes()
        {
            Console.WriteLine("Enter first number: ");
            number1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            number2 = float.Parse(Console.ReadLine());
        }
        public float add()
        {
            return number1 + number2;
        }
        public float subtract()
        {
            return number1 - number2;
        }
        public float multiply()
        {
            return number1 * number2;
        }
        public float division()
        {
            return number1 / number2;
        }
        public float modulo()
        {
            return number1 % number2;
        }
        public double sqrt()
        {
            return Math.Sqrt(number1);
        }
        public double exponenet() 
        {
            return Math.Exp(number1);
        }
        public double Log()
        {
            if (number1 <= 0)
            {
                Console.WriteLine("Error: Cannot calculate logarithm of a non-positive number.");
                return 0;
            }
            return Math.Log(number1);
        }

        public double trignomerticFun()
        {
            int opt;
            Console.WriteLine("Choose function");
            Console.WriteLine("1-Sine");
            Console.WriteLine("2-Cos");
            Console.WriteLine("3-tan");
            Console.WriteLine("Enter your option...");
            opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                return Math.Sin(number1 * Math.PI / 180);
            }
            if (opt == 2)
            {
                return Math.Cos(number1 * Math.PI / 180);
            }
            if (opt == 3)
            {
                return Math.Tan(number1 * Math.PI / 180);
            }
            else
            {
                Console.WriteLine("Invalid option");
                return 0;
            }
        }
    }

}
