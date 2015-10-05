using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkladaniNaPalety
{
    class Couple {
        public int first; // r,t
        public int second; // s,u
        public Couple(int f, int s) {
            first = f;
            second = s;
        }
    }
    class Solution {
        public Couple P1;
        public Couple Q1;
        public Couple P2;
        public Couple Q2;
        public Couple C;
        public bool cRotated;
        public int numberOfBoxes; 
    }
    class BlockHeuristic
    {
        Solution bestOne = null;
        public int BarnesBound(int W,int L, int a, int b) {
            int na;
            int nb;
            if((L%a + W%a )<=a)
                na = (L*W - (L%a)*(W%a))/a;
            else
                na = (L * W - (a- L % a) * (a- W % a)) / a;
            if ((L % b + W % b) <= b)
                nb = (L * W - (L % b) * (W % b) )/ b;
            else
                nb = (L * W - (b - L % b) * (b - W % b)) / b;
            int ub = nb / a;
            int ua = na / b;
            if (ub < ua)
                return ub;
            else
                return ua;
        }
        public void getPattern(Pallet pallet) {
            int W = pallet.width;
            int L = pallet.height;
            int w = Configuration.boxWidth;
            int l = Configuration.boxHeight;
            int lowerBound;
            int upperBound;
            List<Couple> P = new List<Couple>();
            List<Couple> Q = new List<Couple>();
            //get sets
            int stop;
            if(W/w < L/l)
                stop = L/l;
            else
                stop = W/w;
            for(int i = 0; i <= stop;i++)
                for (int j = 0; j <= stop; j++) {
                    if (L - l < i * l + j * w && i * l + j * w <= L) {
                        Couple p = new Couple(i,j);
                        P.Add(p);
                    }
                    if (W - w < i * l + j * w && i * l + j * w <= W)
                    {
                        Couple p = new Couple(i,j);
                        Q.Add(p);
                    }
                }
            stop = 5;
            //get bounds
            upperBound = BarnesBound(W,L,w,l);
            if ((L / l) * (W / w) > (L / w) * (W / l))
                lowerBound = (L / l) * (W / w);
            else
                lowerBound = (L / w) * (W / l);
            if (lowerBound == upperBound) {
                //TODO just put it in
            }
            //get feasible solutions
            int W1,W2,W3,W4,W5;
            int L1,L2,L3,L4,L5;
            int n = 0;
            foreach(Couple p1 in P)
                foreach (Couple q1 in Q)
            foreach(Couple p2 in P)
                foreach (Couple q2 in Q) {
                    n++;
                    if (p2.first * l + p2.second * w >= p1.first * l + p1.second * w && q2.first * l + q2.second * w >= q1.first * l + q1.second * w) { 
                        L1 = p1.first * l;
                        W1 = p1.second * w;
                        L2 = q1.second * w;
                        W2 = q1.first * l;
                        L4 = q2.second * w;
                        W4 = q2.first * l;
                        L5 = p2.first * l;
                        W5 = p2.second * w;
                        if (L1 < L2)
                        {
                            L3 = L - L1 - L5;
                            W3 = W - W2 - W4;
                        }
                        else
                        {
                            L3 = L - L2 - L4;
                            W3 = W - W1 - W5;
                        }
                        //No overlap
                        if(L1+L2 <= L && L4 + L5 <= L && W1 + W4 <= W && W2 + W5 <= W)
                        {
                            //get number of boxes from feasible solutions
                            int boxes = (L1 / l) * (W1 / w) + (L5 / l) * (W5 / w) + (L2 / w) * (W2 / l) + (L4 / w) * (W4 / l);
                            if ((L3 / l) * (W3 / w) > (L3 / l) * (W3 / w))
                            {
                                boxes += (L3 / l) * (W3 / w);
                            }
                            else
                                boxes += (L3 / w) * (W3 / l);
                            if (bestOne == null)
                            {
                                bestOne = new Solution();
                                bestOne.P1 = p1;
                                bestOne.P2 = p2;
                                bestOne.Q1 = q1;
                                bestOne.Q2 = q2;
                                bestOne.numberOfBoxes = boxes;
                                if ((L3 / l) * (W3 / w) > (L3 / l) * (W3 / w))
                                {
                                    bestOne.C = new Couple((L3 / l), (W3 / w));
                                    bestOne.cRotated = false;
                                }
                                else
                                {
                                    bestOne.C = new Couple((W3 / l), (L3 / w));
                                    bestOne.cRotated = true;
                                }
                                
                            }
                            else {
                                if (boxes > bestOne.numberOfBoxes) 
                                {
                                    bestOne.P1 = p1;
                                    bestOne.P2 = p2;
                                    bestOne.Q1 = q1;
                                    bestOne.Q2 = q2;
                                    bestOne.numberOfBoxes = boxes;
                                    if ((L3 / l) * (W3 / w) > (L3 / l) * (W3 / w))
                                    {
                                        bestOne.C = new Couple((L3 / l),(W3 / w));
                                        bestOne.cRotated = false;
                                    }
                                    else
                                    {
                                        bestOne.C = new Couple((W3 / l),(L3 / w));
                                        bestOne.cRotated = true;
                                    }
                                    //TODO boxes == upperbound
                                }
                            }
                        }
                    }
                }
            //P1 block
            for(int i = 0; i < bestOne.P1.first; i ++)
                for (int j = 0; j < bestOne.P1.second; j++) {
                    Box box = new Box();
                    box.height = Configuration.boxWidth;
                    box.width = Configuration.boxHeight;
                    box.coordinates.x = i * box.width;
                    box.coordinates.y = j * box.height;
                    pallet.boxes.Add(box);
                }
            //P2 block
            for (int i = 1; i <= bestOne.P2.first; i++)
                for (int j = 1; j <= bestOne.P2.second; j++)
                {
                    Box box = new Box();
                    box.height = Configuration.boxWidth;
                    box.width = Configuration.boxHeight;
                    box.coordinates.x = pallet.width - i * box.width;
                    box.coordinates.y = pallet.height - j * box.height;
                    pallet.boxes.Add(box);
                }
            // Q1 block
            for (int i = 1; i <= bestOne.Q1.second; i++)
                for (int j = 0; j < bestOne.Q1.first; j++)
                {
                    Box box = new Box();
                    box.height = Configuration.boxHeight;
                    box.width = Configuration.boxWidth;
                    box.coordinates.x = pallet.width - i * box.width;
                    box.coordinates.y = j * box.height;
                    pallet.boxes.Add(box);
                }
            // Q2 block
            for (int i = 0; i < bestOne.Q2.second; i++)
                for (int j = 1; j <= bestOne.Q2.first; j++)
                {
                    Box box = new Box();
                    box.height = Configuration.boxHeight;
                    box.width = Configuration.boxWidth;
                    box.coordinates.x =i * box.width;
                    box.coordinates.y = pallet.height - j * box.height;
                    pallet.boxes.Add(box);
                }
            // C block
            for (int i = 0; i < bestOne.C.first; i++)
                for (int j = 0; j < bestOne.C.second; j++)
                {
                    Box box = new Box();
                    if (bestOne.cRotated)
                    {
                        box.height = Configuration.boxWidth;
                        box.width = Configuration.boxHeight;
                        
                    }
                    else {
                        box.height = Configuration.boxHeight;
                        box.width = Configuration.boxWidth;
                    }
                    if (bestOne.P1.first * Configuration.boxHeight < bestOne.Q2.second * Configuration.boxWidth)
                        box.coordinates.x = bestOne.P1.first*Configuration.boxHeight + i * box.width;
                    else
                        box.coordinates.x = bestOne.Q2.second * Configuration.boxWidth + i * box.width;
                    if (bestOne.Q1.first * Configuration.boxHeight < bestOne.P2.second * Configuration.boxWidth)
                        box.coordinates.y = bestOne.Q1.first * Configuration.boxHeight + j * box.height;
                    else
                        box.coordinates.y = bestOne.P2.second * Configuration.boxWidth + j * box.height;
                    pallet.boxes.Add(box);
                }
        }
    }
}
