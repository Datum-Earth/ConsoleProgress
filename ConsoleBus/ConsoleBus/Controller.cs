using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProgress
{
    internal class Controller
    {
        public void Run(IEnumerable<ProcessObject> procObjList, ref bool running)
        {
            var procList = procObjList.ToArray<ProcessObject>();
            var analyzerList = new List<ProgressAnalyzer>();

            //start all the jobs
            for (int i = 0; i < procObjList.Count(); i++)
            {
                var t = new Thread(delegate () { analyzerList[i].Analyze(procList[i]); }); //
            }
            
            //update the screen with status of the jobs
            while (running == true)
            {
                Update(analyzerList);
            }
        }

        private void Update(IEnumerable<ProgressAnalyzer> procObjList)
        {
            List<ProgressBar> barList = new List<ProgressBar>();

            foreach (ProgressAnalyzer proc in procObjList)
            {
                barList.Add(ReturnProgressBar(proc.LiveProcessInfo));
            }

            foreach (ProgressBar br in barList)
            {
                Console.WriteLine(br.Output);
            }
        }

        private ProgressBar ReturnProgressBar(ProcessObject proc)
        {
            var ret = new ProgressBar(proc.ProcessInfo.CustomInfo)
            {
                Percent = proc.Percentage,
                DisplayPercentage = proc.DisplayPercentage,
                DisplayStatus = proc.DisplayStatus
            };

            return ret;
        }
    }
}
