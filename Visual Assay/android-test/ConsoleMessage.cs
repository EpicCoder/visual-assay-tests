using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using test_report;
using test_report.Model;

namespace android_test
{
    class ConsoleMessage
    {
        private static string _testName;
        private static TestManager _testManager;
        public static void StartTest(string testName, string testCategory)
        {
            _testName = testName;
            Console.WriteLine("--- Test start: {0} ---", _testName);
            _testManager = new TestManager(); ;
            _testManager.StartTest(testName, testCategory);
        }

        public static void EndTest()
        {
            Console.WriteLine("--- Test end: {0} ---", _testName);
            _testManager.EndTest();
            _testName = null;
        }

        public static void Pass(string text)
        {
            _testManager.Log(LogStatus.Pass, text);
            Console.WriteLine(text + ". Status: Pass");
        }

        public static void TakeScreen(string step)
        {
            _testManager.Log(LogStatus.Pass, step, TakeScreenshot());
            Console.WriteLine(step + ". Status: Pass");
        }

        public static void Fail(string text, Exception ex)
        {
            _testManager.Log(LogStatus.Fail, text);
            _testManager.Log(LogStatus.Fail, "Exception: " + ex.Message);
            _testManager.Log(LogStatus.Fail, "Screenshot on fail", TakeScreenshot());
            Console.WriteLine(text + ". Status: Fail");
            Console.WriteLine("Exception: " + ex.Message);
        }

        private static string TakeScreenshot()
        {
            var screenshot = Appium.Instance.Driver.GetScreenshot();
            string screenDir = ExcelReport.ScreenshotDir;
            string fullPath = ExcelReport.ScreenshotDir+
            "\\" + TestContext.CurrentContext.Test.FullName + "-" +
            DateTime.Now.ToString("yyyy-MM-dd--hh-mm-ss") + ".jpeg";
            screenshot.SaveAsFile(fullPath, ImageFormat.Jpeg);
//            return fullPath;
            return GetRelativePath(fullPath, TestContext.CurrentContext.TestDirectory + "\\" + Settings.Instance.Version + "-outPut");
        }

        static string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }
    }
}
