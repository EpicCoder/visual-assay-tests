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
using android_test.ActivityRepo.Team;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario.FlowObject
{
    class ChainAndShareWithNested
    {
        private User _user1;
        private User _user2;
        private int _timeout;
        private string _version;
        private string _team;
        private string _assay;
        private int _shareDelay;
        private int _loginDelay;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user1 = Settings.Instance.User1;
            _user2 = Settings.Instance.User2;
            _timeout = Settings.Instance.LoginTimeout;
            _version = Settings.Instance.Version;
            _team = String.Format("!{0}-ShrNested", _version);
            _shareDelay = Settings.Instance.ShareDelay;
            _loginDelay = Settings.Instance.LoginDelay;
            _assay = string.Format("{0}-ChainAndExe", _version);
        }

        [SetUp]
        public void Setup()
        {
            try
            {
                ConsoleMessage.StartTest("Flow Object: Chain and Exe: Setup", "FlowObject");
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(_user1, _timeout);
                //create team
                TabMenu.Teams.Tap();
                TeamActivity.NewTeam.Tap();
                TeamCreateDialog.TeamName.EnterText(_team);
                TeamCreateDialog.Create.Tap();
                TeamActivity.TeamMemberList.VerifyElementCountById(1, "user_picture");
                TeamActivity.AddUserToTeam(_user2.Name);
                TeamActivity.TeamMemberList.VerifyElementCountById(2, "user_picture");
                CommonOperation.Delay(5);
                TabMenu.Logout.Tap();
            }
            finally
            {
                Appium.Instance.Driver.CloseApp();
                ConsoleMessage.EndTest();
            }
        }

        [Test]
        public void ChainFlowsAndExe()
        {
            string parentFlow = "Parent";
            string nestedFlow1 = "Nested1";
            Permission permission = new Permission(true, true, true, true);

            ConsoleMessage.StartTest("Flow Object: Chain and Exe", "FlowObject");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
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
            //share
            FlowActivity.Share.Tap();
            FlowActivity.ShareOk.Tap();
            FlowShareNestedDialog.Yes.Tap();
            FlowShareDialog.ShareWithUserStep(_team, _user2.Name, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //check shared flow on recipient
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(parentFlow);
            FlowActivity.ElementList.VerifyElementCountByClass(2, "android.widget.EditText");
            FlowActivity.ElementList.FindAndTap(nestedFlow1);
            FlowElementDialog.ShowNested.Tap();
            FlowActivity.FlowName.VerifyText(nestedFlow1);
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
                LoginActivity.LoginStep(_user1, _timeout);
                BrowserActivity.AssayList.FindAndTap(_assay);
                BrowserActivity.DeleteAllFlows();
                BrowserActivity.DeleteAssay.Tap();
                AssayDeleteDialog.Delete.Tap();
                //delete team
                TabMenu.Teams.Tap();
                TeamActivity.TeamList.FindAndTap(_team);
                TeamActivity.Dismiss.Tap();
                TeamDeleteDialog.Delete.Tap();
                CommonOperation.Delay(5);

            }
            finally
            {
                Appium.Instance.Driver.CloseApp();
                ConsoleMessage.EndTest();
            }
        }
    }
}
