using System;
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
    }

}
