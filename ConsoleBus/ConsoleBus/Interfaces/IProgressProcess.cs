using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgress.Interfaces
{
    public interface IProgressProcess
    {
        /// <summary>
        /// Custom name for process.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Process to start and analyze.
        /// </summary>
        ProcessStartInfo ProcessInfo { get; set; } 

        /// <summary>
        /// List of criteria. Any criteria specified here will be what is used to determine process completion percentage.
        /// </summary>
        List<IProgressCriteria> ProcessCriteria { get; set; }

        List<Tuple<string, string>> CustomInfo { get; set; }
    }
}
