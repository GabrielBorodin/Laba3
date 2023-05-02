using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication6
{
    public class AirportClass
    {
        private string name;
        private double seat;
        private double ticket;
        private double cost;

        public string Name
        {
            get { return name; }
            set 
            { 
                name = value; 
            }
        }

        public double Seat
        {
            get { return seat; }
            set 
            { 
                seat = value; 
            }
        }

        public double Ticket
        {
            get { return ticket; }
            set 
            { 
                ticket = value; 
            }
        }

        public double Cost
        {
            get { return cost; }
            set
            {
                cost = value;
            }
        }

        public double Info()
        {
            string test = Convert.ToString(name);
            double numS = seat;
            double numT = ticket;
            double CCost = cost;
            string s = Convert.ToString(numS);
            string t = Convert.ToString(numT);
            string c = Convert.ToString(CCost);
            string name2 = name;

            if (numS > 0 && numT >= 0 && (numS - Math.Floor(numS) == 0) && (numT - Math.Floor(numT) == 0) && numS >= numT && CCost > 0 && test != "")
            {

                double ress = numT * CCost;
                return ress;
            }
            else
            {
                return -3;
            }

        }
    }

    public class Class1
    {
    }
}


