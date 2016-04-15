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
            _teamName = String.Format("!{0}-{1}", Settings.Instance.Version, Settings.Instance.Team);
            _initTimeout = Settings.Instance.InitTimeout;
            _timeout = Settings.Instance.LoginTimeout;
            ExcelReport excel =
                new ExcelReport(TestContext.CurrentContext.TestDirectory + "\\" + Settings.Instance.Version + "-outPut");
            try
            {
                //init login
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(Settings.Instance.User1, _initTimeout);
                TabMenu.Logout.Tap();
                LoginActivity.LoginStep(Settings.Instance.User2, _initTimeout);
                TabMenu.Logout.Tap();
                LoginActivity.LoginStep(Settings.Instance.User3, _initTimeout);
                TabMenu.Logout.Tap();
                //create team for share tests
                LoginActivity.LoginStep(Settings.Instance.User1, _timeout);
                TabMenu.Teams.Tap();
                TeamActivity.NewTeam.Tap();
                TeamCreateDialog.TeamName.EnterText(_teamName);
                TeamCreateDialog.Create.Tap();
                TeamActivity.TeamMemberList.VerifyElementCountById(1, "user_picture");
                //add user to team
                TeamActivity.AddUserToTeam(Settings.Instance.User2.Name);
                TeamActivity.TeamMemberList.VerifyElementCountById(2, "user_picture");
                TeamActivity.AddUserToTeam(Settings.Instance.User3.Name);
                TeamActivity.TeamMemberList.VerifyElementCountById(3, "user_picture");
                CommonOperation.Delay(5);
                Appium.Instance.Driver.CloseApp();
            }
            catch (Exception)
            {
                Appium.Instance.Driver.CloseApp();
                throw;
            }
        }

        [OneTimeTearDown]
        public void GlobalTestTearDown()
        {
            try
            {
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(Settings.Instance.User1, _timeout);
                TabMenu.Teams.Tap();
                TeamActivity.TeamList.FindAndTap(_teamName);
                TeamActivity.Dismiss.Tap();
                TeamDeleteDialog.Delete.Tap();
                CommonOperation.Delay(5);
            }
            catch (Exception)
            {
                Appium.Instance.Driver.CloseApp();
                throw;
            }
        }
    }
}
