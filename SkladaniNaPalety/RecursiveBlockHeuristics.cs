
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladaniNaPalety
{
    class RecursiveBlockHeuristics:BlockHeuristic
    {
        public List<Pallet> pallets = new List<Pallet>();
        public void getRecursivePattern(Pallet pallet) {
            int level = 1;
            int Lstar;
            int Wstar;
            Pallet smallerArea;
            BlockHeuristic blockHeuristic = new BlockHeuristic();
            while (true) {
                if (level == 1) {
                    blockHeuristic.getPattern(pallet);

 
                }

                else
                {
                }

            }
        }
    }
}
