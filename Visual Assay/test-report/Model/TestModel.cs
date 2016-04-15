using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_report.Model
{
    public class TestModel
    {
        public string Name { get; set; }
        public string TestGroup { get; set; }
        public DateTime StartTime { get; internal set; }

        public DateTime EndTime { get; internal set; }

        public string RunTime
        {
            get
            {
                TimeSpan diff = EndTime.Subtract(StartTime);

                return String.Format("{0}h {1}m {2}s+{3}ms", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
            }
        }
        public LogStatus Status { get; private set; }
        public List<LogModel> LogList { get; set; }

        public void TrackLastRunStatus()
        {
            LogList.ForEach(x =>
            {
                FindStatus(x.LogStatus);
            });

            Status = Status == LogStatus.Info ? LogStatus.Pass : Status;
        }

        public void EndTest()
        {
            if (EndTime.Equals(DateTime.MinValue))
                EndTime = DateTime.Now;
        }

        private void FindStatus(LogStatus logStatus)
        {
            if (Status == LogStatus.Fail) return;

            if (logStatus == LogStatus.Fail)
            {
                Status = logStatus;
                return;
            }

            if (Status == LogStatus.Pass) return;

            if (logStatus == LogStatus.Pass)
            {
                Status = LogStatus.Pass;
                return;
            }

            if (Status == LogStatus.Info) return;

            if (logStatus == LogStatus.Info)
            {
                Status = LogStatus.Info;
                return;
            }

            Status = LogStatus.Unknown;
        }

        public TestModel()
        {
            Status = LogStatus.Unknown;

            StartTime = DateTime.Now;
            LogList = new List<LogModel>();
        }
    }
}
