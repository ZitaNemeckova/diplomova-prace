using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladaniNaPalety
{
    class Box
    {
        public int width;
        public int height;
        public Coordinates coordinates; // x and y of left upper corner
        public bool rotated;

        public Box() {
            width = Configuration.palletWidth;
            height = Configuration.palletHeight;
            coordinates = new Coordinates(Configuration.startX,Configuration.startY);
            rotated = false;
       }
        public Box(int x, int y, bool rotated) {
            if (rotated)
            {
                width = Configuration.palletWidth;
                height = Configuration.palletHeight;
            }
            else
            {
                width = Configuration.palletHeight;
                height = Configuration.palletWidth;
            }
            coordinates = new Coordinates(Configuration.startX + x, Configuration.startY + y);
            this.rotated = rotated;
        }

    }
}
