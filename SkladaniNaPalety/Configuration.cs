using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladaniNaPalety
{
    static class Configuration
    {
        public static int palletWidth = 0;
        public static int palletHeight = 0;
        public static int boxWidth = 0;
        public static int boxHeight = 0;
        public static int chosenAlgo = 0;
        public static int startX =  200;
        public static int startY = 20;

        public static void allValues() {
            Console.WriteLine("X = " + palletWidth + " Y = " + palletHeight + " a = " + boxHeight + " b = " + boxWidth + " chosenAlgo = " + chosenAlgo);
            Console.ReadLine();
        }
    }
}
