using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Browser;
using android_test.ActivityRepo.Flow;
using android_test.ActivityRepo.Login;
using android_test.ActivityRepo.Plugin.Flow;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario.FlowObject
{
    class ChangeNested
    {
        private User _user;
        private int _timeout;
        private string _version;
        private string _assay;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user = Settings.Instance.User1;
            _timeout = Settings.Instance.LoginTimeout;
            _version = Settings.Instance.Version;
            _assay = string.Format("{0}-FlowChangeNested", _version);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ChangeNestedTest()
        {
            string parentFlow = "Parent";
            string nestedFlow1 = "Nested1";
            string nestedFlow2 = "Nested2";

            ConsoleMessage.StartTest("Flow Object: Change Nested", "FlowObject");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user, _timeout);
            BrowserActivity.CreateAssay(_assay);
            //setup parent
            BrowserActivity.CreateFlow(parentFlow);
            BrowserActivity.FlowList.FindAndTap(parentFlow);
            FlowActivity.AddElement("Add");
            FlowActivity.AddElement("Flow");
            FlowActivity.ElementList.VerifyElementCountByClass(2, "android.widget.EditText");
            TabMenu.Browser.Tap();
            //setup nested1
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.CreateFlow(nestedFlow1);
            BrowserActivity.FlowList.FindAndTap(nestedFlow1);
            FlowActivity.AddElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(1, "android.widget.EditText");
            TabMenu.Browser.Tap();
            //setup nested2
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.CreateFlow(nestedFlow2);
            BrowserActivity.FlowList.FindAndTap(nestedFlow2);
            FlowActivity.AddElement("Aspirate");
            FlowActivity.ElementList.VerifyElementCountByClass(1, "android.widget.EditText");
            TabMenu.Browser.Tap();

            //link parent and nested1
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(parentFlow);
            FlowActivity.ElementList.FindAndTap("Flow");
            FlowElementDialog.SelectFlow.Tap();
            FlowSelectNesting.ItemList.FindAndTap(_assay);
            FlowSelectNesting.ItemList.FindAndTap(nestedFlow1);
            FlowElementDialog.Ok.Tap();
            FlowActivity.ElementList.FindAndTap(nestedFlow1);
            FlowElementDialog.ShowNested.Tap();
            FlowActivity.FlowName.VerifyText(nestedFlow1);
            FlowActivity.NavPanel(NavPanel.Parent);
            //change nested
            FlowActivity.ElementList.FindAndTap(nestedFlow1);
            FlowElementDialog.SelectFlow.Tap();
            FlowSelectNesting.ItemList.FindAndTap(_assay);
            FlowSelectNesting.ItemList.FindAndTap(nestedFlow2);
            FlowElementDialog.Ok.Tap();
            FlowActivity.ElementList.FindAndTap(nestedFlow2);
            FlowElementDialog.ShowNested.Tap();
            FlowActivity.FlowName.VerifyText(nestedFlow2);
            TabMenu.Logout.Tap();
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
                ConsoleMessage.StartTest("Flow Object: Change Nested: Clean up", "FlowObject");
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
