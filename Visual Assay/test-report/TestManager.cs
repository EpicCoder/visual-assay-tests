using System;
using test_report.Model;

namespace test_report
{
    public class TestManager
    {
        private LogStatus _testStatus = LogStatus.Unknown;
        private TestModel _test;

        public void Log(LogStatus status, string stepName)
        {
            LogModel log = new LogModel();
            log.Timestamp = DateTime.Now;
            log.StepName = stepName;
            log.LogStatus = status;
            _test.LogList.Add(log);
            _test.TrackLastRunStatus();
            _testStatus = _test.Status;
        }

        public void Log(LogStatus status, string stepName, string additionalInfo)
        {
            LogModel log = new LogModel();
            log.Timestamp = DateTime.Now;
            log.StepName = stepName;
            log.LogStatus = status;
            log.AdditionalInfo = additionalInfo;
            _test.LogList.Add(log);
            _test.TrackLastRunStatus();
            _testStatus = _test.Status;
        }

        public void Log(LogStatus status, string stepName, Exception ex)
        {
            string exception = string.Format("EXCEPTION: {0}", ex.ToString());
            Log(status, stepName, exception);
            Log(status, "Take a screenshot");
        }

        public DateTime StartTime
        {
            get { return _test.StartTime; }
            set { _test.StartTime = value; }
        }

        public DateTime EndTime
        {
            get { return _test.EndTime; }
            set { _test.EndTime = value; }
        }

        public TestModel GetTest()
        {
            return _test;
        }

        public void StartTest(string name, string testGroup)
        {
            _test = new TestModel();
            _test.Name = name;
            _test.TestGroup = testGroup;
        }

        public void EndTest()
        {
            _test.EndTest();
            //write to report
            ExcelReport.WriteToMainSheet(_test);
            ExcelReport.WriteToGroupSheet(_test);
        }
    }
}
