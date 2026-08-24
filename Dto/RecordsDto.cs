using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfGameProject
{
    public class RecordsDto
    {
        public List<Dictionary<string, List<BestResult>>> listLevelRecords { get; set; }

        public RecordsDto() { }

        public RecordsDto(List<Dictionary<string, List<BestResult>>> listLevelRecords)
        {
            this.listLevelRecords = listLevelRecords;
        }

    }
}
