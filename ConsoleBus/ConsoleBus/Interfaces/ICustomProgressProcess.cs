using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgress.Interfaces
{
    interface ICustomProgressProcess : IProgressProcess
    {
        List<Tuple<string, string>> CustomDetails { get; set; }
    }
}
