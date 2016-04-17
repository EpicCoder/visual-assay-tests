using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Browser;
using android_test.ActivityRepo.Flow;
using android_test.ActivityRepo.Login;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario
{
    class Search
    {
        private User _user;
        private int _timeout;
        private string _version;
        private string _assay;
        private string _flow;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user = Settings.Instance.User1;
            _timeout = Settings.Instance.LoginTimeout;
            _version = Settings.Instance.Version;
            _assay = string.Format("{0}-Search", _version);
            _flow = string.Format("{0}-Search", _version);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCheck()
        {
            ConsoleMessage.StartTest("Search Test", "SearchTest");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user, _timeout);
            BrowserActivity.CreateAssay(_assay);
            BrowserActivity.CreateFlow(_flow);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.AddElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(1, "android.widget.EditText");
            //search
            TabMenu.Search.Tap();
            TabMenu.SearchItem(_flow);
            CommonOperation.HideKeyboard();
            SearchActivity.SearchResultList.FindAndTap(_flow);
            CommonOperation.Delay(3);
            FlowActivity.FlowName.VerifyText(_flow);
        }


        [TearDown]
        public void TearDown()
        {
            Appium.Instance.Driver.CloseApp();
            ConsoleMessage.EndTest();
        }

        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {
                ConsoleMessage.StartTest("Search Test: Cleanup", "SearchTest");
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(_user, _timeout);
                BrowserActivity.AssayList.FindAndTap(_assay);
                BrowserActivity.DeleteAllFlows();
                BrowserActivity.DeleteAssay.Tap();
                AssayDeleteDialog.Delete.Tap();

            }
            finally
            {
                Appium.Instance.Driver.CloseApp();
                ConsoleMessage.EndTest();
            }
        }
    }
}
