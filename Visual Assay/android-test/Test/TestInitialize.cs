using System;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Login;
using android_test.ActivityRepo.Team;
using NUnit.Framework;
using test_report;

namespace android_test.Test
{
    [SetUpFixture]
    class TestInitialize
    {
        //set 300 sec timeout for first login from clear cache
        private int _initTimeout;
        private int _timeout;
        private string _teamName;

        [OneTimeSetUp]
        public void GlobalTestSetup()
        {
            _teamName = Settings.Instance.Team;
            _initTimeout = Settings.Instance.InitTimeout;
            _timeout = Settings.Instance.LoginTimeout;
            ExcelReport excel =
                new ExcelReport(TestContext.CurrentContext.TestDirectory + "\\" + Settings.Instance.Version + "-outPut");
            try
            {
                //init login
                ConsoleMessage.StartTest("Global Setup", "GlobalSetup");
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(Settings.Instance.User1, _initTimeout);
                TabMenu.Logout.Tap();
                LoginActivity.LoginStep(Settings.Instance.User2, _initTimeout);
                TabMenu.Logout.Tap();
                LoginActivity.LoginStep(Settings.Instance.User3, _initTimeout);
                TabMenu.Logout.Tap();
                LoginActivity.LoginStep(Settings.Instance.User4, _initTimeout);
                TabMenu.Logout.Tap();
            }
            finally
            {
                Appium.Instance.Driver.CloseApp();
                ConsoleMessage.EndTest();
            }
        }

        [OneTimeTearDown]
        public void GlobalTestTearDown()
        {
            
        }
    }
}
