using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_report.Model
{
    public class LogModel
    {
        public DateTime Timestamp { get; set; }
        public LogStatus LogStatus { get; set; }
        public string StepName { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
