using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace SkladaniNaPalety
{
    public partial class Form1 : Form
    {
        private Pallet pallet;
        private bool drawingDone = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if (drawingDone)
            {
                drawingDone = true;
            }
            else {
                this.CreateGraphics().Clear(SystemColors.Control);
            }
            Configuration.boxHeight = (int)boxHeightValue.Value; 
            Configuration.boxWidth = (int)boxWidthValue.Value;
            Configuration.palletHeight = (int)palletHeightValue.Value;
            Configuration.palletWidth = (int)palletWidthValue.Value;
            Configuration.chosenAlgo = chosenAlgoValue.SelectedIndex;
           
            pallet = new Pallet(this.CreateGraphics());
            string algo = chosenAlgoValue.SelectedIndex.ToString() ;
            switch(algo){
                case "-1":
                    //TODO warning 
                    return;
                case "0":
                    BlockHeuristic blockHeuristic = new BlockHeuristic();
                    blockHeuristic.getPattern(pallet);
                    break;
                case "1":
                    RecursiveBlockHeuristics recursiveBlockHeuristic = new RecursiveBlockHeuristics();
                    //TODO
                    recursiveBlockHeuristic.getPattern(pallet);
                    break;
                case "2":
                    //TODO genetic
                    break;
            }
            getAreaBound();
            getBarnesBound();
            drawResults();
            pallet.getBorder();
            bool pattern = pallet.getCorrectPattern();
            Console.WriteLine(pattern);
            Console.ReadLine();
            shiftInBoxes.Text = "Shift in boxes: " +  pallet.getStabilityShift().ToString();
        }
        private void getAreaBound() {
            double value = (double)(Configuration.palletHeight * Configuration.palletWidth) / (double)(Configuration.boxHeight * Configuration.boxWidth);
            int intValue = (int)Math.Round(value);
            areaBound.Text = "Area bound: " +  intValue.ToString();
        }
        private void getBarnesBound()
        {
            double value = (double)(Configuration.palletHeight * Configuration.palletWidth) / (double)(Configuration.boxHeight * Configuration.boxWidth);
            int intValue = (int)Math.Round(value);
            BlockHeuristic blockHeuristic = new BlockHeuristic();
            barnesBound.Text = "Barnes bound: " + blockHeuristic.BarnesBound(Configuration.palletWidth,Configuration.palletHeight, Configuration.boxWidth, Configuration.boxHeight).ToString();
        } 

        private void drawPallet(System.Drawing.Graphics canvas, Pallet data)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.SandyBrown, 3);
            canvas.DrawLine(pen, Configuration.startX + data.start.x, Configuration.startY, Configuration.palletWidth + Configuration.startX, Configuration.startY);
            canvas.DrawLine(pen, Configuration.startX, Configuration.startY, Configuration.startX, Configuration.palletHeight + Configuration.startY);
            canvas.DrawLine(pen, Configuration.startX, Configuration.startY + Configuration.palletHeight, Configuration.palletWidth + Configuration.startX, Configuration.startY + Configuration.palletHeight);
            canvas.DrawLine(pen, Configuration.startX + Configuration.palletWidth, Configuration.startY, Configuration.palletWidth + Configuration.startX, Configuration.startY + Configuration.palletHeight);

            pen.Dispose();
        }
        private void drawBox(System.Drawing.Graphics canvas, Box data)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.SkyBlue, 2);
            System.Drawing.Pen pen2 = new System.Drawing.Pen(System.Drawing.Color.Crimson, 2);

            canvas.DrawLine(pen, Configuration.startX + data.coordinates.x, Configuration.startY + data.coordinates.y, Configuration.startX + data.width + data.coordinates.x, Configuration.startY + data.coordinates.y);
            canvas.DrawLine(pen, Configuration.startX + data.coordinates.x, Configuration.startY + data.coordinates.y, Configuration.startX + data.coordinates.x, Configuration.startY + data.height + data.coordinates.y);
            canvas.DrawLine(pen, Configuration.startX + data.coordinates.x, Configuration.startY + data.coordinates.y + data.height, Configuration.startX + data.width + data.coordinates.x, Configuration.startY + data.coordinates.y + data.height);
            canvas.DrawLine(pen, Configuration.startX + data.coordinates.x + data.width, Configuration.startY + data.coordinates.y, Configuration.startX + data.width + data.coordinates.x, Configuration.startY + data.coordinates.y + data.height);
            
            int x = data.coordinates.x + Configuration.startX + data.width / 2;
            int y = data.coordinates.y + Configuration.startY + data.height / 2;
            canvas.DrawLine(pen2, x - 1, y - 1, x + 1, y + 1);
            pen.Dispose();
        }
        private void drawResults()
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            //draw pallet
            drawPallet(formGraphics, pallet);
            //draw boxes
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.MediumPurple , 3);
            foreach (Box b in pallet.boxes) 
            {
                drawBox(formGraphics, b);
            }
            drawCenterOfGravity(formGraphics, pallet);
            formGraphics.Dispose();
        }

        private void drawCenterOfGravity(Graphics canvas, Pallet pallet)
        {
            pallet.getCenterOfGravity();
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red, 3);
            System.Drawing.Pen pen2 = new System.Drawing.Pen(System.Drawing.Color.Green, 3);
            canvas.DrawLine(pen,pallet.perfectCenterOfGravity.x - 1,pallet.perfectCenterOfGravity.y - 1,pallet.perfectCenterOfGravity.x + 1,pallet.perfectCenterOfGravity.y + 1);
            canvas.DrawLine(pen2, pallet.boxesCenterOfGravity.x - 1, pallet.boxesCenterOfGravity.y - 1, pallet.boxesCenterOfGravity.x + 1, pallet.boxesCenterOfGravity.y + 1);

        }

        private void chosenAlgoValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
