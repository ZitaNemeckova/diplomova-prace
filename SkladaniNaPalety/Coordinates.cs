using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladaniNaPalety
{
    class Coordinates
    {
        public int x;
        public int y;
        public Coordinates()
        {
            this.x = 0;
            this.y = 0;
        }
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double distanceFrom(Coordinates original)
        {
            
            double x = Math.Pow((original.x - this.x),2);
            double y = Math.Pow((original.y - this.y),2);
            double xy = x + y;
            return (Math.Pow(xy,0.5));
        }
    }
}
