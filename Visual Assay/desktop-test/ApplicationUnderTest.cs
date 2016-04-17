using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Logging;
using TestStack.White;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace desktop_test
{
    class ApplicationUnderTest
    {
        private static ApplicationUnderTest _instance;
        private Application _application;
        private string _appName = "VisualAssay";
        private string _mainWindowAutomationId = "VAMainWindow";

        public Application Application
        {
            get { return _application; }
        }


        public static ApplicationUnderTest Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                return _instance = new ApplicationUnderTest();
            }
        }

        public Window MainWindow { get; private set; }

        public void Launch()
        {
            CoreAppXmlConfiguration.Instance.LoggerFactory = new ConsoleFactory(LoggerLevel.Error);
            _application = Application.Launch(GetAppPath());
            Thread.Sleep(3000);
            MainWindow = _application.GetWindow(SearchCriteria.ByAutomationId(_mainWindowAutomationId), InitializeOption.NoCache);
        }

        public void AttachToProcess()
        {
            CoreAppXmlConfiguration.Instance.LoggerFactory = new ConsoleFactory(LoggerLevel.Error);
            Process process = Process.GetProcessesByName(_appName).First();
            _application = Application.Attach(process);
            MainWindow = _application.GetWindow(SearchCriteria.ByAutomationId(_mainWindowAutomationId), InitializeOption.NoCache);
        }

        private static string GetAppPath()
        {
            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string visualAssay = @"VisualAssay\VisualAssay.exe";
            return Path.Combine(programFiles, visualAssay);
        }
    }
}
