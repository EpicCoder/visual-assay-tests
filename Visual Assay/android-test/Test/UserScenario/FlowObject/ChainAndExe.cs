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
    class ChainAndExe
    {
        private User _user;
        private int _timeout;
        private string _version;
        private string _assay;
        private string _preExeAssay;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user = Settings.Instance.User3;
            _timeout = Settings.Instance.LoginTimeout;
            _version = Settings.Instance.Version;
            _assay = string.Format("{0}-ChainAndExe", _version);
            _preExeAssay = "!FlowObjectExe";
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ChainFlowsAndExe()
        {
            string parentFlow = "Parent";
            string nestedFlow1 = "Nested1";
            string nestedFlow2 = "Nested2";

            ConsoleMessage.StartTest("Flow Object: Chain and Exe", "FlowObject");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user, _timeout);
            BrowserActivity.CreateAssay(_assay);
            //setup parent
            BrowserActivity.CreateFlow(parentFlow);
            BrowserActivity.FlowList.FindAndTap(parentFlow);
            FlowActivity.AddElement("Add");
            FlowActivity.AddElement("Aspirate");
            FlowActivity.AddElement("Flow");
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            TabMenu.Browser.Tap();

            //setup nested1
            BrowserActivity.CreateFlow(nestedFlow1);
            BrowserActivity.FlowList.FindAndTap(nestedFlow1);
            FlowActivity.AddElement("Add");
            FlowActivity.AddElement("Flow");
            FlowActivity.ElementList.VerifyElementCountByClass(2, "android.widget.EditText");
            TabMenu.Browser.Tap();

            //setup nested2
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


            //link nested1 and nested2
            FlowActivity.ElementList.FindAndTap("Flow");
            FlowElementDialog.SelectFlow.Tap();
            FlowSelectNesting.ItemList.FindAndTap(_assay);
            FlowSelectNesting.ItemList.FindAndTap(nestedFlow2);
            FlowElementDialog.Ok.Tap();
            FlowActivity.ElementList.FindAndTap(nestedFlow2);
            FlowElementDialog.ShowNested.Tap();
            CommonOperation.Delay(1);

            //move to parent and start flow
            FlowActivity.NavPanel(NavPanel.Parent);
            FlowActivity.Start.Tap();
            FlowStartDialog.Ok.Tap();
            FlowSelectAssayDialog.AssayList.FindAndTap(_preExeAssay);
            CommonOperation.Delay(2);
            FlowActivity.OpenElement(0);
            FlowElementDialog.Done.Tap();
            FlowActivity.OpenElement(1);
            FlowElementDialog.Done.Tap();
            FlowActivity.OpenElement(2);
            FlowElementDialog.ShowNested.Tap();

            //exe nested1
            FlowActivity.Start.Tap();
            FlowStartDialog.Ok.Tap();
            FlowActivity.OpenElement(0);
            FlowElementDialog.Done.Tap();
            FlowActivity.OpenElement(1);
            FlowElementDialog.ShowNested.Tap();

            //exe nested2
            FlowActivity.Start.Tap();
            FlowStartDialog.Ok.Tap();
            FlowActivity.OpenElement(0);
            FlowElementDialog.Done.Tap();
            //sign nested2
            FlowSignActivity.SignSignature.Tap();
            SignDialog.Ok.Tap();
            FlowSignActivity.Ok.Tap();

            //move to nested1 and finish
            FlowActivity.NavPanel(NavPanel.Nested1);
            FlowActivity.OpenElement(1);
            FlowElementDialog.Done.Tap();
            //sign nested1
            FlowSignActivity.SignSignature.Tap();
            SignDialog.Ok.Tap();
            FlowSignActivity.Ok.Tap();

            //move to parent and finish
            FlowActivity.NavPanel(NavPanel.Parent);
            FlowActivity.OpenElement(2);
            FlowElementDialog.Done.Tap();
            //sign parent
            FlowSignActivity.SignSignature.Tap();
            SignDialog.Ok.Tap();
            FlowSignActivity.Ok.Tap();
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
                ConsoleMessage.StartTest("Flow Object: Chain and Exe: Cleanup", "FlowObject");
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
