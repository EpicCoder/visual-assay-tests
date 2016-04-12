using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace android_test.Test.UserScenario
{
    class ShareLibraryWithUser
    {
        [OneTimeSetUp]
        public void BeforeClass()
        {

        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCheck()
        {
            Appium.Instance.Driver.LaunchApp();
        }


        [TearDown]
        public void TearDown()
        {
            Appium.Instance.Driver.CloseApp();
        }

        [OneTimeTearDown]
        public void AfterClass()
        {

        }
    }
}
