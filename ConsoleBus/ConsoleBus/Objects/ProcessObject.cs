using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgress
{
    internal class ProcessObject
    {
        public decimal Percentage { get; set; }

        public string ProcessName { get; set; }

        public List<Tuple<string, string>> CustomDetails { get; set; } 
    }
}
