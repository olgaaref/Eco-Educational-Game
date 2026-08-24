using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfGameProject
{
    public class BestResult
    {
        public string name { get; set; }
        public long result { get; set; }

        public BestResult() { }

        public BestResult(string name, long result)
        {
            this.name = name;
            this.result = result;
        }

        
    }
}
