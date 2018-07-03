using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProgress.Interfaces;
using System.Diagnostics;
using System.IO;

namespace ConsoleProgress
{
    internal class ProgressAnalyzer
    {
        public ProcessObject LiveProcessInfo { get; set; }

        private void Analyze()
        {
            LiveProcessInfo.Percentage = 0.00m;
            LiveProcessInfo.IsFinished = false;

            using (Process runningProcess = Process.Start(LiveProcessInfo.ProcessInfo.ProcessInfo))
            {
                using (StreamReader strm = runningProcess.StandardOutput)
                {
                    string line;

                    while ((line = strm.ReadLine()) != null)
                    {
                        foreach (IProgressCriteria criteria in LiveProcessInfo.ProcessInfo.ProcessCriteria)
                        {
                            if (line.Contains(criteria.Value))
                                LiveProcessInfo.Percentage += criteria.ProgressAmount;
                        }
                    }
                }
            }

            LiveProcessInfo.IsFinished = true;
        }

        public void Analyze(ProcessObject procObj)
        {
            LiveProcessInfo = procObj;

            Analyze();
        }
    }
}
