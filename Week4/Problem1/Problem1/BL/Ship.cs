using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class Ship
    {
        public Ship()
        {
            this.latitude = new Angle();
            this.longitude = new Angle();
        }

        public Ship(string shipName,Angle latitude, Angle longitude)
        {
            this.ShipName = shipName;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public string ShipName;
        public Angle latitude;
        public Angle longitude;

        public string angleValue()
        {
            char degreeSign = '\u00b0';
            return "Ship is at "+ this.latitude.Degrees.ToString() + degreeSign + this.latitude.Minutes.ToString()+"'"+ this.latitude.Direction+" and " + this.longitude.Degrees.ToString() + degreeSign + this.longitude.Minutes.ToString() + "'" + this.longitude.Direction;
        }

        public string returnShipName()
        {
            return this.ShipName;
        }

        public void updateShip(Angle latitude, Angle longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

    }
}
