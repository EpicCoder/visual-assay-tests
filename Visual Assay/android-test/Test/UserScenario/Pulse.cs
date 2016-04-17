using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Login;
using android_test.ActivityRepo.Pulse;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario
{
    class Pulse
    {
        private User _user;
        private int _timeout;

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user = Settings.Instance.User3;
            _timeout = Settings.Instance.LoginTimeout;
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PulseTest()
        {

            ConsoleMessage.StartTest("Pulse Test", "Pulse");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user, _timeout);
            TabMenu.Pulse.Tap();
            CommonOperation.Delay(10);
            PulseActivity.VerifyListNotEmpty();
            ConsoleMessage.TakeScreen("Verify pulse not empty after 10 sec");
            PulseActivity.HeaderList.VerifyElementCountByClass(11, "android.widget.TextView");
            PulseActivity.CustomizeView.Tap();
            PulseCustomizeViewDialog.ClickOnPropertyCheckbox("property1");
            PulseCustomizeViewDialog.ClickOnPropertyCheckbox("property2");
            PulseCustomizeViewDialog.Ok.Tap();
            PulseActivity.HeaderList.VerifyElementCountByClass(12, "android.widget.TextView");
            ConsoleMessage.TakeScreen("Verify pulse after checking props in customize view");
            PulseActivity.MoveToFlow();
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

        }
    }
}
