using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class Angle
    {
        public Angle() 
        { 
        }

        public Angle(int degree, double minutes, char direction, string latitude)
        {
            this.Degrees = degree;
            this.Minutes = minutes;
            this.Direction = direction;
            this.Latitude = latitude;
        }

        public int Degrees;
        public double Minutes;
        public char Direction;
        public string Latitude;
    }
}
