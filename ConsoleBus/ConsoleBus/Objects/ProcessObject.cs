using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProgress.Interfaces;

namespace ConsoleProgress
{
    internal class ProcessObject
    {
        private decimal _Percentage;
        public decimal Percentage
        {
            get { return _Percentage; }
            set {
                if (_Percentage >= 100.0m)
                {
                    _Percentage = 100.0m;
                    DisplayPercentage = ">100%";
                }
                else
                {
                    _Percentage = value;
                }

                DisplayStatus = "RUNNING";
            }
        }

        public string DisplayPercentage {get; set;}

        public string DisplayStatus { get; set; }

        private bool _IsFinished;

        public bool IsFinished
        {
            get { return _IsFinished; }
            set
            {
                _IsFinished = value;

                if (_IsFinished == false)
                {
                    DisplayStatus = "RUNNING";
                } else
                {
                    DisplayStatus = "COMPLETE.";
                }
            }
        }


        public IProgressProcess ProcessInfo { get; set; }
    }
}
