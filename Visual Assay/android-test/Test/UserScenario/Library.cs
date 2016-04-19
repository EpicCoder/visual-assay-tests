using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Library;
using android_test.ActivityRepo.Login;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario
{
    class Library
    {
        private User _user;
        private int _timeout;
        private string _version;
        private string _library;

        private string element1 = "Element1";
        private string element2 = "Element2";
        private string element3 = "Element3";
        private List<string> elements = new List<string>();

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user = Settings.Instance.User1;
            _timeout = Settings.Instance.LoginTimeout;
            _version = Settings.Instance.Version;
            _library = string.Format("{0}-LibraryTest", _version);
            elements.Add(element1);
            elements.Add(element2);
            elements.Add(element3);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SingleLibraryTest()
        {
            ConsoleMessage.StartTest("Library test", "Library");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user, _timeout);
            TabMenu.Library.Tap();
            LibraryActivity.CreateLibrary(_library);
            //add
            foreach (var element in elements)
            {
                LibraryActivity.AddElement.Tap();
                LibraryElementActivity.ElementName.ClearText();
                LibraryElementActivity.ElementName.EnterText(element);
                LibraryElementActivity.Ok.Tap();
            }
            LibraryActivity.ElementList.VerifyElementCountById(3, "library_document_icon");
            //delete element
            LibraryActivity.ElementList.FindAndTap(element2);
            LibraryElementActivity.Delete.Tap();
            LibraryDeleteElementDialog.Delete.Tap();
            LibraryActivity.ElementList.VerifyElementCountById(2, "library_document_icon");
            //change element type
            LibraryActivity.ElementList.FindAndTap(element1);
            LibraryElementActivity.ElementType.Tap();
            ComboBoxItemDialog.FindAndTap("Operation");
            LibraryElementActivity.VerifyElementType("Operation");
            //add property
            LibraryElementActivity.AddProperty.Tap();
            LibraryPropertyDialog.PropertyName.EnterText("propName1");
            LibraryPropertyDialog.PropertyValue.EnterText("propValue1");
            LibraryPropertyDialog.PropertyType.Tap();
            ComboBoxItemDialog.FindAndTap("Text");
            LibraryPropertyDialog.VerifyPropertyType("Text");
            LibraryPropertyDialog.Ok.Tap();
            LibraryElementActivity.PropertyList.VerifyElementCountByClass(1, "android.widget.RelativeLayout");
            LibraryElementActivity.VerifyPropertyValue("propName1", "propValue1");
            //change property value
            LibraryElementActivity.OpenProperty("propName1");
            LibraryPropertyDialog.PropertyValue.EnterText("CanChange");
            LibraryPropertyDialog.Ok.Tap();
            LibraryElementActivity.VerifyPropertyValue("propName1", "CanChange");

            //add second property
            LibraryElementActivity.AddProperty.Tap();
            LibraryPropertyDialog.PropertyName.EnterText("propName2");
            LibraryPropertyDialog.PropertyValue.EnterText("propValue2");
            LibraryPropertyDialog.Required.Tap();
            LibraryPropertyDialog.Required.VerifyStatus(true);
            LibraryPropertyDialog.Ok.Tap();
            LibraryElementActivity.PropertyList.VerifyElementCountByClass(2, "android.widget.RelativeLayout");
            LibraryElementActivity.VerifyPropertyMarkAsRequired("propName2");

            //delete property
            LibraryElementActivity.DeleteProperty("propName1");
            LibraryElementActivity.PropertyList.VerifyElementCountByClass(1, "android.widget.RelativeLayout");
            LibraryElementActivity.DeleteProperty("propName2");
            LibraryElementActivity.PropertyList.VerifyElementCountByClass(0, "android.widget.RelativeLayout");

            //swap properies
            //add property
            LibraryElementActivity.AddProperty.Tap();
            LibraryPropertyDialog.PropertyName.EnterText("swap1");
            LibraryPropertyDialog.Ok.Tap();
            //add property
            LibraryElementActivity.AddProperty.Tap();
            LibraryPropertyDialog.PropertyName.EnterText("swap2");
            LibraryPropertyDialog.Ok.Tap();
            //add property
            LibraryElementActivity.AddProperty.Tap();
            LibraryPropertyDialog.PropertyName.EnterText("swap3");
            LibraryPropertyDialog.Ok.Tap();
            LibraryElementActivity.PropertyList.VerifyElementCountByClass(3, "android.widget.RelativeLayout");
            LibraryElementActivity.SwapProperty("swap1", "swap3");
            LibraryElementActivity.VerifyPropertyAtPosition(2, "swap1");
            LibraryElementActivity.Ok.Tap();
            LibraryActivity.DeleteLibrary.Tap();
            LibraryDeleteDialog.Delete.Tap();
            LibraryActivity.VerifyLibraryNotExist(_library);
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
