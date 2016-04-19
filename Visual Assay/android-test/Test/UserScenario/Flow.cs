using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Browser;
using android_test.ActivityRepo.Flow;
using android_test.ActivityRepo.Login;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario
{
    class Flow
    {
        private User _user;
        private int _timeout;
        private string _version;
        private string _assay;
        private string _flow;

        private string element1 = "Add";
        private string element2 = "Aspirate";
        private string element3 = "CFU";
        private List<string> elements = new List<string>();

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user = Settings.Instance.User1;
            _timeout = Settings.Instance.LoginTimeout;
            _version = Settings.Instance.Version;
            _assay = string.Format("{0}-FlowTest", _version);
            _flow = string.Format("{0}-FlowTest", _version);
            elements.Add(element1);
            elements.Add(element2);
            elements.Add(element3);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SingleFlowTest()
        {
            ConsoleMessage.StartTest("Flow Test", "Flow");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user, _timeout);
            BrowserActivity.CreateAssay(_assay);
            BrowserActivity.CreateFlow(_flow);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.AddElement(element1);
            FlowActivity.AddElement(element2);
            FlowActivity.AddElement(element3);
            FlowActivity.ElementList.VerifyElementCountByClass(3, "android.widget.EditText");
            //delete element
            FlowActivity.DeleteElement(element3);
            FlowActivity.ElementList.VerifyElementCountByClass(2, "android.widget.EditText");
            //property test
            FlowActivity.ElementList.FindAndTap(element1);
            //add property
            FlowElementDialog.AddProperty.Tap();
            FlowPropertyDialog.PropertyName.EnterText("propName1");
            FlowPropertyDialog.PropertyValue.EnterText("propValue1");
            FlowPropertyDialog.PropertyType.Tap();
            ComboBoxItemDialog.FindAndTap("Text");
            FlowPropertyDialog.VerifyPropertyType("Text");
            FlowPropertyDialog.Ok.Tap();
            FlowElementDialog.PropertyList.VerifyElementCountByClass(1, "android.widget.RelativeLayout");
            FlowElementDialog.VerifyPropertyValue("propName1", "propValue1");
            //change property value
            FlowElementDialog.OpenProperty("propName1");
            FlowPropertyDialog.PropertyValue.EnterText("CanChange");
            FlowPropertyDialog.Ok.Tap();
            FlowElementDialog.VerifyPropertyValue("propName1", "CanChange");

            //add second property
            FlowElementDialog.AddProperty.Tap();
            FlowPropertyDialog.PropertyName.EnterText("propName2");
            FlowPropertyDialog.PropertyValue.EnterText("propValue2");
            FlowPropertyDialog.IsRequired.Tap();
            FlowPropertyDialog.IsRequired.VerifyStatus(true);
            FlowPropertyDialog.Ok.Tap();
            FlowElementDialog.PropertyList.VerifyElementCountByClass(2, "android.widget.RelativeLayout");
            FlowElementDialog.VerifyPropertyMarkAsRequired("propName2");
            //delete property
            FlowElementDialog.DeleteProperty("propName1");
            FlowElementDialog.PropertyList.VerifyElementCountByClass(1, "android.widget.RelativeLayout");
            FlowElementDialog.DeleteProperty("propName2");
            FlowElementDialog.PropertyList.VerifyElementCountByClass(0, "android.widget.RelativeLayout");

            //swap properies
            //add property
            FlowElementDialog.AddProperty.Tap();
            FlowPropertyDialog.PropertyName.EnterText("swap1");
            FlowPropertyDialog.Ok.Tap();
            //add property
            FlowElementDialog.AddProperty.Tap();
            FlowPropertyDialog.PropertyName.EnterText("swap2");
            FlowPropertyDialog.Ok.Tap();
            //add property
            FlowElementDialog.AddProperty.Tap();
            FlowPropertyDialog.PropertyName.EnterText("swap3");
            FlowPropertyDialog.Ok.Tap();
            FlowElementDialog.PropertyList.VerifyElementCountByClass(3, "android.widget.RelativeLayout");
            FlowElementDialog.SwapProperty("swap1", "swap3");
            FlowElementDialog.VerifyPropertyAtPosition(2, "swap1");
            FlowElementDialog.Ok.Tap();

            //delete flow
            FlowActivity.DeleteFlow.Tap();
            FlowDeleteDialog.Delete.Tap();
            BrowserActivity.VerifyFlowNotExist(_flow);
            BrowserActivity.DeleteAssay.Tap();
            AssayDeleteDialog.Delete.Tap();
            BrowserActivity.VerifyAssayNotExit(_assay);
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
