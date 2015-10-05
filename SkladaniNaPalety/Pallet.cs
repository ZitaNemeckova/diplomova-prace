using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladaniNaPalety
{
    class Pallet
    {
        public List<Box> boxes = new List<Box>();
        public Graphics formGraphics;
        
        public void addBox(Box b){
            boxes.Add(b);
        }
        
        public Coordinates perfectCenterOfGravity = new Coordinates();
        public Coordinates start = new Coordinates();
        public Coordinates boxesCenterOfGravity = new Coordinates();
        public int width = 0;
        public int height = 0;
        public bool unifiedBorder = false;
        public Coordinates borderLimits = new Coordinates();

        public Pallet(Graphics canvas) {
            width = Configuration.palletWidth;
            height = Configuration.palletHeight;
            perfectCenterOfGravity.x = Configuration.startX + width / 2;
            perfectCenterOfGravity.y = Configuration.startY + height / 2;
            formGraphics = canvas;
        }
        public Pallet(int W, int L) {
            width = W;
            height = L;
           
        }
        public Pallet() {
            width = Configuration.palletWidth;
            height = Configuration.palletHeight;
            perfectCenterOfGravity.x = Configuration.startX + width / 2;
            perfectCenterOfGravity.y = Configuration.startY + height / 2;
        }
        public void getCenterOfGravity() {
            Coordinates coordinates = new Coordinates();
            double x = 0;
            double y = 0;
            foreach (Box box in boxes) {
                x = x + (box.width) / 2 + box.coordinates.x;
                y = y + (box.height) / 2 + box.coordinates.y;
            }
            x = x / boxes.Count;
            y = y / boxes.Count;
            //TODO some control would be nice
            coordinates.x = Configuration.startX + (int)Math.Round(x);
            coordinates.y = Configuration.startY + (int)Math.Round(y);
            boxesCenterOfGravity = coordinates;
        }
        //TODO any graphical show
        public void getBorder()
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.MediumOrchid, 1);
            boxes = (from a in boxes
                            orderby (a.coordinates.y), (a.coordinates.x)
                            select a).ToList();
            bool border = true;
            int minX = boxes[0].coordinates.x;
            int minY = boxes[0].coordinates.y;
            int maxX = boxes[boxes.Count - 1].coordinates.x;
            int maxY = boxes[boxes.Count - 1].coordinates.y;
            int upperBorderline = minX;
            int lowerBorderline = maxY;
            int leftBorderline = minY;
            int rightBorderline = maxX;
            foreach (Box box in boxes)
            {
                if (box.coordinates.y == minY)
                {
                    if (upperBorderline == box.coordinates.x)
                    {
                        upperBorderline += box.width;
                    }
                    else
                    {
                        //TODO any graphical show
                    }
                }
                //TODO orientation
                if (box.coordinates.y == maxY)
                {
                    if (lowerBorderline == box.coordinates.x)
                    {
                        lowerBorderline += box.width;
                    }
                    else
                    {
                        //TODO any graphical show
                    }
                }
                if (box.coordinates.x == minX)
                {
                    if (leftBorderline == box.coordinates.y)
                    {
                        leftBorderline += box.height;
                    }
                    else
                    {
                        //TODO any graphical show
                    }
                }
                //TODO orientation
                if (box.coordinates.x == maxX)
                {
                    if (rightBorderline == box.coordinates.x)
                    {
                        rightBorderline += box.height;
                    }
                    else
                    {
                        //TODO any graphical show
                    }
                }
            }
            if (lowerBorderline != maxX + Configuration.boxWidth || upperBorderline != maxX + Configuration.boxWidth || leftBorderline != maxY + Configuration.boxHeight || rightBorderline != maxY + Configuration.boxHeight)
                border = false;
            unifiedBorder = border;
            if (border)
                borderLimits = new Coordinates(upperBorderline, leftBorderline);
            else
                borderLimits = new Coordinates(Configuration.palletWidth, Configuration.palletHeight);

            minX += Configuration.startX;
            minY += Configuration.startY;
            maxX += Configuration.startX + boxes[boxes.Count - 1].width;
            maxY += Configuration.startY + boxes[boxes.Count - 1].height;

            formGraphics.DrawLine(pen, minX, minY, minX, maxY);
            formGraphics.DrawLine(pen, minX, minY, maxX, minY);
            formGraphics.DrawLine(pen, maxX, minY, maxX, maxY);
            formGraphics.DrawLine(pen, minX, maxY, maxX, maxY);
        }
        public bool inPallet(Box box)
        {
            Rectangle rPallet = new Rectangle(0, 0, borderLimits.x, borderLimits.y);
            Point leftUpperCorner = new Point(box.coordinates.x, box.coordinates.y);
            Point leftLowerCorner = new Point(box.coordinates.x, box.coordinates.y + box.height);
            Point rightUpperCorner = new Point(box.coordinates.x + box.width, box.coordinates.y);
            Point rightLowerCorner = new Point(box.coordinates.x + box.width, box.coordinates.y + box.height);
            if (rPallet.Contains(leftLowerCorner) && rPallet.Contains(leftUpperCorner) && rPallet.Contains(rightLowerCorner) && rPallet.Contains(rightUpperCorner))
                return true;
            else
                return false;
        }
        public bool getCorrectPattern()
        {
            List<Box> pom = (from a in boxes
                             orderby (a.coordinates.y), (a.coordinates.x)
                             select a).ToList();
            for (int i = 0; i < pom.Count; i++)
            {
                for (int j = 0; j < pom.Count; j++)
                {
                    if (i == j)
                        continue;
                    Rectangle r = new Rectangle(pom[i].coordinates.x, pom[i].coordinates.y, pom[i].width, pom[i].height);
                    if (r.Contains(pom[j].coordinates.x, pom[j].coordinates.y))
                    {
                        if (pom[i].coordinates.x + pom[i].width == pom[j].coordinates.x)
                            continue;
                        if (pom[i].coordinates.y + pom[i].height == pom[j].coordinates.y)
                            continue;
                        Console.WriteLine("a " + i + "  " + j);
                        return false;
                    }
                    if (r.Contains(pom[j].coordinates.x + pom[j].width, pom[j].coordinates.y))
                    {
                        if (pom[i].coordinates.x == pom[j].coordinates.x + pom[j].width)
                            continue;
                        if (pom[i].coordinates.y + pom[i].height == pom[j].coordinates.y)
                            continue;
                        Console.WriteLine("b " + i + "  " + j);
                        return false;
                    }
                    if (r.Contains(pom[j].coordinates.x, pom[j].coordinates.y + pom[j].height))
                    {
                        if (pom[i].coordinates.x + pom[i].width == pom[j].coordinates.x)
                            continue;
                        if (pom[i].coordinates.y == pom[j].coordinates.y + pom[j].height)
                            continue;
                        Console.WriteLine("c " + i + "  " + j);
                        return false;
                    }
                    if (r.Contains(pom[j].coordinates.x + pom[j].width, pom[j].coordinates.y + pom[j].height))
                    {
                        if (pom[i].coordinates.x == pom[j].coordinates.x + pom[j].width)
                            continue;
                        if (pom[i].coordinates.y == pom[j].coordinates.y + pom[j].height)
                            continue;
                        Console.WriteLine("d " + i + "  " + j);
                        return false;
                    }
                }
            }
            return true;
        }
        //compute stability regarding movements of boxes
        public double getStabilityShift()
        {
            double shiftOfCenterOfGravity = 0;
            getCenterOfGravity();
            Coordinates original = boxesCenterOfGravity;
            //down
            bool shift = true;
            while (shift)
            {
                shift = false;
                for (int i = 0; i < boxes.Count; i++)
                {
                    boxes[i].coordinates.y++;
                    if (getCorrectPattern() && inPallet(boxes[i]))
                    {
                        shift = true;
                        Console.WriteLine("True for " + i);
                    }
                    else
                    {
                        boxes[i].coordinates.y--;
                        Console.WriteLine("False for " + i);
                    }
                }
            }
            getCenterOfGravity();
            shiftOfCenterOfGravity = shiftOfCenterOfGravity + boxesCenterOfGravity.distanceFrom(original);

            //up
            shift = true;
            while (shift)
            {
                shift = false;
                for (int i = 0; i <  boxes.Count; i++)
                {
                     boxes[i].coordinates.y--;
                    if (getCorrectPattern() && inPallet(boxes[i]))
                    {
                        shift = true;
                        Console.WriteLine("True for " + i);
                    }
                    else
                    {
                         boxes[i].coordinates.y++;
                        Console.WriteLine("False for " + i);
                    }
                }
            }
             getCenterOfGravity();
            shiftOfCenterOfGravity = shiftOfCenterOfGravity +  boxesCenterOfGravity.distanceFrom(original);

            //left
            shift = true;
            while (shift)
            {
                shift = false;
                for (int i = 0; i <  boxes.Count; i++)
                {
                     boxes[i].coordinates.x--;
                    if (getCorrectPattern() && inPallet(boxes[i]))
                    {
                        shift = true;
                        Console.WriteLine("True for " + i);
                    }
                    else
                    {
                         boxes[i].coordinates.x++;
                        Console.WriteLine("False for " + i);
                    }
                }
            }
             getCenterOfGravity();
            shiftOfCenterOfGravity = shiftOfCenterOfGravity +  boxesCenterOfGravity.distanceFrom(original);

            //right
            shift = true;
            while (shift)
            {
                shift = false;
                for (int i = 0; i <  boxes.Count; i++)
                {
                     boxes[i].coordinates.x++;
                    if (getCorrectPattern() && inPallet(boxes[i]))
                    {
                        shift = true;
                        Console.WriteLine("True for " + i);
                    }
                    else
                    {
                         boxes[i].coordinates.x--;
                        Console.WriteLine("False for " + i);
                    }
                }
            }
             getCenterOfGravity();
            shiftOfCenterOfGravity = shiftOfCenterOfGravity +  boxesCenterOfGravity.distanceFrom(original);
            return shiftOfCenterOfGravity;
        }
        
        
    }
}
