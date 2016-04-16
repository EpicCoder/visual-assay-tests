using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Browser;
using android_test.ActivityRepo.Flow;
using android_test.ActivityRepo.Login;
using android_test.ActivityRepo.Plugin.Plate;
using android_test.Entity;
using NUnit.Framework;

namespace android_test.Test.UserScenario
{
    class Plate
    {
        private User _user;
        private int _timeout;
        private string _version;
        private string _assay;
        private string _flow;

        private string element = "Plate";

        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user = Settings.Instance.User1;
            _timeout = Settings.Instance.LoginTimeout;
            _version = Settings.Instance.Version;
            _assay = string.Format("{0}-PlateTest", _version);
            _flow = string.Format("{0}-PlateTest", _version);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PlateTest()
        {
            string comp1 = "Component 1";
            string comp2 = "Component 2";
            string comp3 = "Component 3";
            string comp4 = "Component 4";
            string input = "10";

            ConsoleMessage.StartTest("PlateTest", "Plate");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user, _timeout);
            BrowserActivity.CreateAssay(_assay);
            BrowserActivity.CreateFlow(_flow);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.AddElement(element);
            FlowActivity.OpenElement(element);
            FlowElementDialog.OpenPlugin.Tap();
            //chage size
            string[] size = {"2x3", "3x4", "4x6", "16x24", "8x12"};
            foreach (var s in size)
            {
                PlateActivity.ChangeSize(s);
                PlateActivity.VerifyCurrentSize(s);
            }
            //add labels
            PlateActivity.NewLabel.Tap();
            PlateActivity.NewLabel.Tap();
            PlateActivity.NewLabel.Tap();
            PlateActivity.NewLabel.Tap();
            PlateActivity.LabelList.VerifyElementCountById(4, "component_name");
            //fill wells
            PlateActivity.LabelList.FindAndTap(comp1);
            PlateActivity.FillWell(125, 420, 415, 420);
            PlateActivity.LabelList.FindAndTap(comp2);
            PlateActivity.FillWell(560, 420, 845, 420);
            PlateActivity.LabelList.FindAndTap(comp3);
            PlateActivity.FillWell(125, 560, 415, 560);
            PlateActivity.LabelList.FindAndTap(comp4);
            PlateActivity.FillWell(560, 560, 845, 560);
            //create sheet
            PlateActivity.AddSheet.Tap();
            PlateCreateSheetDialog.Name.EnterText("Test");
            PlateCreateSheetDialog.Ok.Tap();
            PlateActivity.SheetList.VerifyElementCountByClass(2, "android.widget.LinearLayout");

            //fill function
            PlateActivity.AddSheet.Tap();
            PlateCreateSheetDialog.Name.EnterText("Fill");
            PlateCreateSheetDialog.Ok.Tap();
            PlateActivity.SheetList.VerifyElementCountByClass(3, "android.widget.LinearLayout");
            PlateActivity.ToolEdit.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateWellEditDialog.Name.EnterText(input);
            PlateWellEditDialog.Ok.Tap();
            //fill right
            PlateActivity.ToolSelect.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateSelectionToolbar.FillRight.Tap();
            ConsoleMessage.TakeScreen("Verify: Fill Right");
            //fill down
            PlateActivity.ToolSelect.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateSelectionToolbar.FillDown.Tap();
            ConsoleMessage.TakeScreen("Verify: Fill Down");

            //dilute function
            PlateActivity.AddSheet.Tap();
            PlateCreateSheetDialog.Name.EnterText("Dilute");
            PlateCreateSheetDialog.Ok.Tap();
            PlateActivity.SheetList.VerifyElementCountByClass(4, "android.widget.LinearLayout");
            PlateActivity.ToolEdit.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateWellEditDialog.Name.EnterText(input);
            PlateWellEditDialog.Ok.Tap();
            //dilute right
            PlateActivity.ToolSelect.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateSelectionToolbar.DiluteRight.Tap();
            CommonOperation.HideKeyboard();
            PlateDiluteDialog.Ok.Tap();
            ConsoleMessage.TakeScreen("Verify: Dilute Right");
            //dilute down
            PlateActivity.ToolSelect.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateSelectionToolbar.DiluteDown.Tap();
            CommonOperation.HideKeyboard();
            PlateDiluteDialog.Ok.Tap();
            ConsoleMessage.TakeScreen("Verify: Dilute Down");

            //clear function
            PlateActivity.AddSheet.Tap();
            PlateCreateSheetDialog.Name.EnterText("Clear");
            PlateCreateSheetDialog.Ok.Tap();
            PlateActivity.SheetList.VerifyElementCountByClass(5, "android.widget.LinearLayout");
            PlateActivity.ToolEdit.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateWellEditDialog.Name.EnterText(input);
            PlateWellEditDialog.Ok.Tap();
            //clear
            PlateActivity.ToolClear.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateActivity.ToolEdit.Tap();
            PlateActivity.TapByCoordinate(125, 420);
            PlateWellEditDialog.Name.VerifyText("");
            CommonOperation.HideKeyboard();
            PlateWellEditDialog.Ok.Tap();
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
                ConsoleMessage.StartTest("PlateTest: Clean up", "Plate");
                Appium.Instance.Driver.LaunchApp();
                LoginActivity.LoginStep(_user, _timeout);
                BrowserActivity.AssayList.FindAndTap(_assay);
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
