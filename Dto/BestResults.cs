using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfGameProject
{
    public class BestResults
    {
        public BestResult bestResult1 { get; set; }
        public BestResult bestResult2 { get; set; }
        public BestResult bestResult3 { get; set; }

        public BestResults() { }

        public BestResults(BestResult bestResult1, BestResult bestResult2, BestResult bestResult3)
        {
            this.bestResult1 = bestResult1;
            this.bestResult2 = bestResult2;
            this.bestResult3 = bestResult3;
        }
    }
}
