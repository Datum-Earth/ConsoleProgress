using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgress
{
    internal class ProgressBar
    {
        public string Output
        {
            get
            {
                var ret = OutputArray.ToString() + "|" + DisplayPercentage;
                var status = "[STATUS]: " + DisplayStatus;
                var customFields = DisplayCustomFields;

                return ret + "\t" + status + "\t" + customFields;
            }
        }

        private char[] OutputArray { get; set; }

        private decimal _Percent;

        public decimal Percent
        {
            get { return _Percent; }
            set
            {
                _Percent = value;

                for (int i = 0; i < 10; i++)
                {
                    if (i < Convert.ToInt32(_Percent))
                        OutputArray[i] = '█';
                    else
                        OutputArray[i] = '-';
                };
            }
        }

        public string DisplayPercentage { get; set; }
        public string DisplayStatus { get; set; }

        private string DisplayCustomFields { get; set; }
        
        private void SetCustomFields(List<Tuple<string, string>> input )
        {
            string ret = "";

            foreach (Tuple<string, string> i in input)
            {
                ret += $"{i.Item1}: {i.Item2}\n";
            }

            DisplayCustomFields = ret;
        }

        public ProgressBar(List<Tuple<string, string>> customFields)
        {
            SetCustomFields(customFields);
            Percent = 0.00m;
            DisplayPercentage = "0%";
            DisplayStatus = "NOT STARTED";
        }

    }
}
