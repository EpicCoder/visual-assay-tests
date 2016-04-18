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
    class ShareFlowWithUser
    {
        private User _user1;
        private User _user2;
        private string _team;
        private int _timeout;
        private int _shareDelay;
        private int _loginDelay;
        private string _version;
        private string _assay;
        private string _assayRec;

        private string element1 = "Add";
        private string element2 = "Aspirate";
        private string element3 = "CFU";

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user1 = Settings.Instance.User1;
            _user2 = Settings.Instance.User2;
            _timeout = Settings.Instance.LoginTimeout;
            _shareDelay = Settings.Instance.ShareDelay;
            _loginDelay = Settings.Instance.LoginDelay;
            _version = Settings.Instance.Version;
            _team = String.Format("!{0}-ShareFlow", _version);
            _assay = string.Format("{0}-ShareFlowWithUser", _version);
            _assayRec = string.Format("{0}-Recipient", _version);

            //            create assay
            try
            {
                ConsoleMessage.StartTest("Share flow with user: Setup", "ShareFlow");
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(_user1, _timeout);
                BrowserActivity.CreateAssay(_assay);
                BrowserActivity.AssayList.FindAndTap(_assay);
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

                LoginActivity.LoginStep(_user2, _timeout);
                BrowserActivity.CreateAssay(_assayRec);
                BrowserActivity.AssayList.FindAndTap(_assayRec);
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
        public void ViewOnly()
        {
            string flowName = "View";
            Permission permission = new Permission(true, false, false, false);
            //create flow
            ConsoleMessage.StartTest("Share flow with user: View", "ShareFlow");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.CreateFlow(flowName);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.AddElement(element1);
            FlowActivity.AddElement(element2);
            FlowActivity.AddElement(element3);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //share

                //worked
//            FlowActivity.Share.Tap();
//            FlowActivity.ShareOk.Tap();
//            FlowShareDialog.TeamList.FindAndTap(_team);
//            FlowShareDialog.AddUser(_user2.Name);
//            FlowShareDialog.ShareWithList.VerifyElementCountById(1, "user_picture");
//            FlowShareDialog.SetPermission(permission);
//            FlowShareDialog.Ok.Tap();

            FlowActivity.Share.Tap();
            FlowActivity.ShareOk.Tap();
            FlowShareDialog.ShareWithUserStep(_team, _user2.Name, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();
            //verify 
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can't add element
            FlowActivity.AddElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can't delete element
            FlowActivity.DeleteElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can't share flow
            FlowActivity.Share.Tap();
            FlowPermissionErrorDialog.DialogName.VerifyText("Share Permission");
            FlowPermissionErrorDialog.Ok.Tap();
            //verify can't delete flow
            FlowActivity.DeleteFlow.Tap();
            FlowPermissionErrorDialog.DialogName.VerifyText("Delete Permission");
            FlowPermissionErrorDialog.Ok.Tap();
            TabMenu.Logout.Tap();
        }

        [Test]
        public void AddOnly()
        {
            string flowName = "Add";
            Permission permission = new Permission(true, false, false, true);
            //create flow
            ConsoleMessage.StartTest("Share flow with user: Add", "ShareFlow");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.CreateFlow(flowName);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.AddElement(element1);
            FlowActivity.AddElement(element2);
            FlowActivity.AddElement(element3);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //share
            FlowActivity.Share.Tap();
            FlowActivity.ShareOk.Tap();
            FlowShareDialog.ShareWithUserStep(_team, _user2.Name, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //verify 
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can't add element
            FlowActivity.AddElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(4, "android.widget.EditText");
            //verify can't delete element
            FlowActivity.DeleteElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(4, "android.widget.EditText");
            //verify can't share flow
            FlowActivity.Share.Tap();
            FlowPermissionErrorDialog.DialogName.VerifyText("Share Permission");
            FlowPermissionErrorDialog.Ok.Tap();
            //verify can't delete flow
            FlowActivity.DeleteFlow.Tap();
            FlowPermissionErrorDialog.DialogName.VerifyText("Delete Permission");
            FlowPermissionErrorDialog.Ok.Tap();
            TabMenu.Logout.Tap();

            //verify on recipient
            LoginActivity.LoginStep(_user1, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.ElementList.VerifyElementCountByClass(4, "android.widget.EditText");
            TabMenu.Logout.Tap();
        }

        [Test]
        public void ModifyOnly()
        {
            string flowName = "Modify";
            Permission permission = new Permission(true, false, true, false);
            //create flow
            ConsoleMessage.StartTest("Share flow with user: Modify", "ShareFlow");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.CreateFlow(flowName);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.AddElement(element1);
            FlowActivity.AddElement(element2);
            FlowActivity.AddElement(element3);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //share
            FlowActivity.Share.Tap();
            FlowActivity.ShareOk.Tap();
            FlowShareDialog.ShareWithUserStep(_team, _user2.Name, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //verify 
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can add element
            FlowActivity.AddElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(4, "android.widget.EditText");
            //verify can delete element
            FlowActivity.DeleteElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can delete flow
            FlowActivity.DeleteFlow.Tap();
            FlowDeleteDialog.Cancel.Tap();
            //verify can't share flow
            FlowActivity.Share.Tap();
            FlowPermissionErrorDialog.DialogName.VerifyText("Share Permission");
            FlowPermissionErrorDialog.Ok.Tap();
            TabMenu.Logout.Tap();

            //verify on recipient
            LoginActivity.LoginStep(_user1, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            TabMenu.Logout.Tap();
        }

        [Test]
        public void ShareOnly()
        {
            string flowName = "Share";
            Permission permission = new Permission(true, true, false, false);
            Permission allPermission = new Permission(true, true, true, true);
            //create flow
            ConsoleMessage.StartTest("Share flow with user: Share", "ShareFlow");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.CreateFlow(flowName);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.AddElement(element1);
            FlowActivity.AddElement(element2);
            FlowActivity.AddElement(element3);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //share
            FlowActivity.Share.Tap();
            FlowActivity.ShareOk.Tap();
            FlowShareDialog.ShareWithUserStep(_team, _user2.Name, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //verify 
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can't add element
            FlowActivity.AddElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can't delete element
            FlowActivity.DeleteElement("Add");
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //verify can't delete flow
            FlowActivity.DeleteFlow.Tap();
            FlowPermissionErrorDialog.DialogName.VerifyText("Delete Permission");
            FlowPermissionErrorDialog.Ok.Tap();
            //verify can share flow
            FlowActivity.Share.Tap();
            FlowActivity.ShareOk.Tap();
            FlowReshareDialog.Yes.Tap();
            FlowShareDialog.TeamList.FindAndTap(_team);
            FlowShareDialog.AddUser(_user1.Name);
            FlowShareDialog.ShareWithList.VerifyElementCountById(1, "user_picture");
            FlowShareDialog.SetPermission(allPermission);
            FlowShareDialog.Ok.Tap();
            FlowSelectAssayDialog.AssayList.FindAndTap(_assayRec);
            TabMenu.Logout.Tap();

            //verify on recipient
            LoginActivity.LoginStep(_user1, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user2.Name);
            BrowserActivity.FlowList.FindAndTap(_assayRec);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            TabMenu.Logout.Tap();
        }

        [Test]
        public void ShareFlowAsBlocked()
        {
            string flowName = "BlockedBase";
            Permission permission = new Permission(true, true, true, true);
            //create flow
            ConsoleMessage.StartTest("Share flow with user: Share As Blocked", "ShareFlow");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.CreateFlow(flowName);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.AddElement(element1);
            FlowActivity.AddElement(element2);
            FlowActivity.AddElement(element3);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            FlowActivity.Share.Tap();
            FlowActivity.TapOnFlowElement(0);
            FlowActivity.ShareOk.Tap();
            FlowShareDialog.TeamList.FindAndTap(_team);
            FlowShareDialog.AddUser(_user2.Name);
            FlowShareDialog.ShareWithList.VerifyElementCountById(1, "user_picture");
            FlowShareDialog.SetPermission(permission);
            FlowShareDialog.Ok.Tap();
            FlowSelectAssayDialog.AssayList.FindAndTap(_assay);
            FlowActivity.VerifyElementName(0, "Blocked");
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //verify blocked flow
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName + "-BLK");
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            FlowActivity.VerifyElementName(0, "Blocked");
            TabMenu.Logout.Tap();
        }


        [Test]
        public void Unshare()
        {
            string flowName = "Unshare";
            Permission permission = new Permission(true, true, true, true);
            //create flow
            ConsoleMessage.StartTest("Share flow with user: Unshare", "ShareFlow");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.CreateFlow(flowName);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.AddElement(element1);
            FlowActivity.AddElement(element2);
            FlowActivity.AddElement(element3);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //share
            FlowActivity.Share.Tap();
            FlowActivity.ShareOk.Tap();
            FlowShareDialog.ShareWithUserStep(_team, _user2.Name, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();
            //verify 
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            TabMenu.Logout.Tap();

            //unshare
            LoginActivity.LoginStep(_user1, _timeout);
            BrowserActivity.AssayList.FindAndTap(_assay);
            BrowserActivity.FlowList.FindAndTap(flowName);
            FlowActivity.Permission.Tap();
            FlowShareDialog.Unshare(_user2.Name);
            FlowShareDialog.ShareWithList.VerifyElementCountById(0, "user_picture");
            FlowShareDialog.Ok.Tap();
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //verify flow not exist
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            BrowserActivity.AssayList.FindAndTap("Shared With: " + _user1.Name);
            BrowserActivity.FlowList.FindAndTap(_assay);
            BrowserActivity.VerifyFlowNotExist(flowName);
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
                ConsoleMessage.StartTest("Share flow with user: Clean up", "ShareFlow");
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
                TabMenu.Logout.Tap();

                LoginActivity.LoginStep(_user2, _timeout);
                BrowserActivity.AssayList.FindAndTap(_assayRec);
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
