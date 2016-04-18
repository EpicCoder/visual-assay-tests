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
    class ShareAssayWithUser
    {
        private User _user1;
        private User _user2;
        private string _team;
        private int _timeout;
        private int _shareDelay;
        private int _loginDelay;
        private string _version;
        private string _assay;
        private string _flow;

        private string element1 = "Add";


        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user1 = Settings.Instance.User1;
            _user2 = Settings.Instance.User2;
            _timeout = Settings.Instance.LoginTimeout;
            _shareDelay = Settings.Instance.ShareDelay;
            _loginDelay = Settings.Instance.LoginDelay;
            _version = Settings.Instance.Version;
            _assay = string.Format("{0}-ShareAssayWithUser", _version);
            _flow = string.Format("{0}-ShareAssayWithUser", _version);
            _team = String.Format("!{0}-ShareAssay", _version);

            ConsoleMessage.StartTest("Share assay with user: Setup", "ShareAssay");
            try
            {
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(_user1, _timeout);
                TabMenu.Teams.Tap();
                TeamActivity.NewTeam.Tap();
                TeamCreateDialog.TeamName.EnterText(_team);
                TeamCreateDialog.Create.Tap();
                TeamActivity.TeamMemberList.VerifyElementCountById(1, "user_picture");
                //add user to team
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

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShareAsasyWithUserTest()
        {
            Permission permission = new Permission(true, true, true, true);

            ConsoleMessage.StartTest("Share assay with user", "ShareAssay");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.CreateAssay(_assay);
            BrowserActivity.CreateFlow(_flow);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.AddElement(element1);
            FlowActivity.ElementList.VerifyElementCountByClass(1, "android.widget.EditText");
            TabMenu.Browser.Tap();
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.ShareAssay.Tap();
            AssayShareDialog.ShareWithUserStep(_team, _user2.Name, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //verify shared assay
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.ElementList.VerifyElementCountByClass(1, "android.widget.EditText");
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
                ConsoleMessage.StartTest("Share assay with user: Clean up", "ShareAssay");
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
