using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Browser;
using android_test.ActivityRepo.Flow;
using android_test.ActivityRepo.Login;
using android_test.ActivityRepo.Team;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario
{
    class ShareFlowAndRemoveUserFromTeam
    {
        private User _user1;
        private User _user2;
        private User _user3;
        private string _team;
        private int _timeout;
        private int _shareDelay;
        private int _loginDelay;
        private string _version;
        private string _assay;
        private string _flow;

        private string element1 = "Add";
        private string element2 = "Aspirate";
        private string element3 = "CFU";

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user1 = Settings.Instance.User1;
            _user2 = Settings.Instance.User2;
            _user3 = Settings.Instance.User3;
            _timeout = Settings.Instance.LoginTimeout;
            _shareDelay = Settings.Instance.ShareDelay;
            _loginDelay = Settings.Instance.LoginDelay;
            _version = Settings.Instance.Version;
            _assay = string.Format("{0}-ShareFlowAndRemoveUserFromTeam", _version);
            _flow = string.Format("{0}-ShareFlowAndRemoveUserFromTeam", _version);
            _team = String.Format("!{0}-Flow{1}", _version, Settings.Instance.TeamRemove);



            ConsoleMessage.StartTest("Share flow with team and remove user from team: Setup", "ShareFlow");
            try
            {
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(_user1, _timeout);
                BrowserActivity.CreateAssay(_assay);
                BrowserActivity.CreateFlow(_flow);
                BrowserActivity.FlowList.FindAndTap(_flow);
                FlowActivity.AddElement(element1);
                FlowActivity.AddElement(element2);
                FlowActivity.AddElement(element3);
                FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
                //create team
                TabMenu.Teams.Tap();
                CommonOperation.Delay(1);
                TeamActivity.NewTeam.Tap();
                TeamCreateDialog.TeamName.EnterText(_team);
                TeamCreateDialog.Create.Tap();
                TeamActivity.TeamMemberList.VerifyElementCountById(1, "user_picture");
                //add user to team
                TeamActivity.AddUserToTeam(_user2.Name);
                TeamActivity.TeamMemberList.VerifyElementCountById(2, "user_picture");
                CommonOperation.Delay(5);
            }
            finally
            {
                Appium.Instance.Driver.CloseApp();
                ConsoleMessage.EndTest();
            }

        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShareFlowAndRemoveUserFromTeamTest()
        {
            Permission permission = new Permission(false, true, true, true);
            //create flow
            ConsoleMessage.StartTest("Share flow with team and remove user from team", "ShareFlow");
            //share flow
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.Share.Tap();
            FlowActivity.ShareOk.Tap();
            FlowShareDialog.ShareWithTeamStep(_team, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //Login as a Team member and verify user received the shared flow
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _team);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            TabMenu.Logout.Tap();

            //Login as Owner and add a new user to the team
            LoginActivity.LoginStep(_user1, _timeout);
            TabMenu.Teams.Tap();
            CommonOperation.Delay(2);
            TeamActivity.TeamList.FindAndTap(_team);
            TeamActivity.AddUserToTeam(_user3.Name);
            TeamActivity.TeamMemberList.VerifyElementCountById(3, "user_picture");
            CommonOperation.Delay(15);
            TabMenu.Logout.Tap();

            //Login as new user and verify user received shared flow
            LoginActivity.LoginStep(_user3, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _team);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            TabMenu.Logout.Tap();

            //Login as Owner and remove the new user from the team
            LoginActivity.LoginStep(_user1, _timeout);
            TabMenu.Teams.Tap();
            CommonOperation.Delay(2);
            TeamActivity.TeamList.FindAndTap(_team);
            TeamActivity.RemoveUserFromTeam(_user3.Name);
            TeamActivity.TeamMemberList.VerifyElementCountById(2, "user_picture");
            CommonOperation.Delay(15);
            TabMenu.Logout.Tap();

            //Login as Owner and remove the new user from the team
            LoginActivity.LoginStep(_user3, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.VerifyAssayNotExit("Shared With: " + _team);
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
                ConsoleMessage.StartTest("Share flow with team and remove user from team: Cleanup", "ShareFlow");
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
            }
            finally
            {
                Appium.Instance.Driver.CloseApp();
                ConsoleMessage.EndTest();
            }
        }
    }
}
