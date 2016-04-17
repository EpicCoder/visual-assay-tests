using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Browser;
using android_test.ActivityRepo.Flow;
using android_test.ActivityRepo.Library;
using android_test.ActivityRepo.Login;
using android_test.ActivityRepo.Team;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario
{
    class ShareLibraryAndRemoveUserFromTeam
    {
        private User _user1;
        private User _user2;
        private User _user3;
        private string _team;
        private int _timeout;
        private int _shareDelay;
        private int _loginDelay;
        private string _version;
        private string _baseLibrary;
        private string _shareName;

        private string element1 = "Element1";
        private string element2 = "Element2";
        private string element3 = "Element3";

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
            _team = String.Format("!{0}-Lib{1}", _version, Settings.Instance.TeamRemove);
            _baseLibrary = String.Format("!{0}-UserRemoveBase", _version);
            _shareName = String.Format("!{0}-UserRemove", _version);

            ConsoleMessage.StartTest("Share library with team and remove user from team: Setup", "ShareLibrary");
            try
            {
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(_user1, _timeout);
                TabMenu.Library.Tap();
                LibraryActivity.CreateLibrary(_baseLibrary);
                LibraryActivity.AddElement.Tap();
                LibraryElementActivity.ElementName.ClearText();
                LibraryElementActivity.ElementName.EnterText(element1);
                LibraryElementActivity.Ok.Tap();
                LibraryActivity.ElementList.VerifyElementCountById(1, "library_document_icon");
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
        public void ShareLibraryAndRemoveUserFromTeamTest()
        {
            Permission permission = new Permission(false, true, true, true);
            
            ConsoleMessage.StartTest("Share library with team and remove user from team", "ShareLibrary");
            //Login as Library owner and share a library with a Team
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user1, _timeout);
            TabMenu.Library.Tap();
            LibraryActivity.LibraryList.FindAndTap(_baseLibrary);
            LibraryActivity.SelectAndShareLibrary(_baseLibrary, _shareName);
            LibraryShareDialog.ShareWithTeamStep(_team, permission);
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //Login as a Team member and verify user received the shared library
            LoginActivity.LoginStep(_user2, _timeout);
            CommonOperation.Delay(_loginDelay);
            TabMenu.Library.Tap();
            LibraryActivity.LibraryList.FindAndTap(_shareName);
            LibraryActivity.ElementList.VerifyElementCountById(1, "library_document_icon");
            TabMenu.Logout.Tap();

            //Login as Owner and add a new user to the team
            LoginActivity.LoginStep(_user1, _timeout);
            TabMenu.Teams.Tap();
            CommonOperation.Delay(2);
            TeamActivity.TeamList.FindAndTap(_team);
            TeamActivity.AddUserToTeam(_user3.Name);
            TeamActivity.TeamMemberList.VerifyElementCountById(3, "user_picture");
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //Login as new user and verify user received shared library
            LoginActivity.LoginStep(_user3, _timeout);
            CommonOperation.Delay(_loginDelay);
            TabMenu.Library.Tap();
            LibraryActivity.LibraryList.FindAndTap(_shareName);
            LibraryActivity.ElementList.VerifyElementCountById(1, "library_document_icon");
            TabMenu.Logout.Tap();

            //Login as Owner and remove the new user from the team
            LoginActivity.LoginStep(_user1, _timeout);
            TabMenu.Teams.Tap();
            CommonOperation.Delay(2);
            TeamActivity.TeamList.FindAndTap(_team);
            TeamActivity.RemoveUserFromTeam(_user3.Name);
            TeamActivity.TeamMemberList.VerifyElementCountById(2, "user_picture");
            CommonOperation.Delay(_shareDelay);
            TabMenu.Logout.Tap();

            //Login as new user and verify user does not have the shared library
            LoginActivity.LoginStep(_user3, _timeout);
            CommonOperation.Delay(_loginDelay);
            TabMenu.Library.Tap();
            LibraryActivity.VerifyLibraryNotExist(_shareName);
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
            //clean up after test
            try
            {
                ConsoleMessage.StartTest("Share library with team and remove user from team: Cleanup", "ShareLibrary");
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(_user1, _timeout);
                TabMenu.Library.Tap();
                LibraryActivity.DeleteAllLibs();
                CommonOperation.Delay(3);
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
