using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladaniNaPalety
{
    class Individual {
        public List<bool> boxes = new List<bool>();
        public double fitness = 0;
        public Pallet pallet;
        //TODO define good fitness function
        public void getFitness() {
            //TODO numberOfBoxes - shiftInBoxes + border - centerOfGravity
            pallet.getBorder();
            if (pallet.unifiedBorder)
                fitness++;
            fitness += pallet.boxes.Count + pallet.getStabilityShift() ;
        }
        public void getPattern() {
            //TODO left corner fit
            pallet = new Pallet();
            int x = 0;
            int y = 0;
            foreach (bool b in boxes) {
                Box newBox = new Box(x,y,b);
                //in pallet
                if (!pallet.inPallet(newBox)) {
                    //TODO shift
                }
                pallet.boxes.Add(newBox);
                //no overlap
                if (!pallet.getCorrectPattern())
                {
                    //TODO shift right
                }
                else 
                {
                    //TODO shift left
                }
                x += newBox.height;
                if (x + Configuration.boxHeight > pallet.height && x + Configuration.boxWidth > pallet.height) {
                    // new line
                    if(Configuration.boxWidth < Configuration.boxHeight)
                        y += Configuration.boxWidth;
                    else
                        y += Configuration.boxHeight;
                    // no space left, end 
                    if (y + Configuration.boxHeight > pallet.height && y + Configuration.boxWidth > pallet.height)
                        return;
                }
            }
        }
    }
    class GeneticPrograming
    {
        public List<Individual> solutions = new List<Individual>();
        public Individual bestOne;
        //final pallet
        public Pallet pallet; 
        Random r = new Random();
        public GeneticPrograming(Pallet p) {
            pallet = p;
        }
        public void generateFirstGeneration() {
            BlockHeuristic blockHeuristic = new BlockHeuristic();
            int idealNumber = blockHeuristic.BarnesBound(pallet.width, pallet.height, Configuration.boxWidth,Configuration.boxHeight);
            for (int i = 0; i <= 100; i++) {
                Individual newOne = new Individual();
                for (int j = 0; j <= idealNumber; j++) {
                    if (r.NextDouble() >= 0.5)
                        newOne.boxes.Add(true);
                    else
                        newOne.boxes.Add(false);
                }
                solutions.Add(newOne);
            }
        }
        public void getBestOnes() {
            foreach (Individual i in solutions) {
                i.getFitness();
            }
            solutions = (from a in solutions
                     orderby (a.fitness)
                     select a).ToList();
            solutions = solutions.GetRange(0,50);
        }
        public void Mutation() {
            List<Individual> mutants = new List<Individual>();
            foreach (Individual i in solutions) { 
               Individual m = new Individual();
                for(int j = 0; j < i.boxes.Count;j ++){
                    if (r.NextDouble() < 0.1)
                    {
                        if (i.boxes[j])
                            m.boxes[j] = false;
                        else
                            m.boxes[j] = true;
                    }
                    else {
                        if (i.boxes[j])
                            m.boxes[j] = true;
                        else
                            m.boxes[j] = false;
                    }
                    mutants.Add(m);
                }
            }
        }
        public void getBestSolution() {
            generateFirstGeneration();
            for (int i = 0; i < 20; i++)
            {
                getBestOnes();
                Mutation();
            }
        }

    }
}
