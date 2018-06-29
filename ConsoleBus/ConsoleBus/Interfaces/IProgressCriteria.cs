using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgress.Interfaces
{
    public interface IProgressCriteria
    {
        /// <summary>
        /// String phrase that triggers process completion percentage increase.
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Amount to increase process completion percentage by.
        /// </summary>
        decimal ProgressAmount { get; set; }
    }
}
