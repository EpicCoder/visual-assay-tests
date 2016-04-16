using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityRepo;
using android_test.ActivityRepo.Browser;
using android_test.ActivityRepo.Flow;
using android_test.ActivityRepo.Login;
using android_test.ActivityRepo.Plugin.Jit;
using android_test.Entity;
using NUnit.Framework;
using test_report;

namespace android_test.Test.UserScenario
{
    class Jit
    {
        private User _user;
        private int _timeout;
        private string _version;
        private string _assay;
        private string _flow;

        private string element = "JIT Table";


        [OneTimeSetUp]
        public void BeforeClass()
        {
            _user = Settings.Instance.User1;
            _timeout = Settings.Instance.LoginTimeout;
            _version = Settings.Instance.Version;
            _assay = string.Format("{0}-JitTest", _version);
            _flow = string.Format("{0}-JitTest", _version);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void JitTest()
        {
            string key = "MyKey";
            string filed1 = "Field1";
            string filed2 = "Field2";
            string filed3 = "Field3";
            string filed4 = "Field4";

            ConsoleMessage.StartTest("Jit Test", "Jit");
            Appium.Instance.Driver.LaunchApp();
            LoginActivity.LoginStep(_user, _timeout);
            BrowserActivity.CreateAssay(_assay);
            BrowserActivity.CreateFlow(_flow);
            BrowserActivity.FlowList.FindAndTap(_flow);
            FlowActivity.AddElement(element);
            FlowActivity.OpenElement(element);
            //add key
            JitActivity.AddKey.Tap();
            JitActivity.FieldName.EnterText(key);
            JitActivity.CreateField.Tap();
            JitActivity.FieldList.VerifyElementCountByClass(1, "android.widget.Button");
            //add 4 fields
            JitActivity.AddField.Tap();
            JitActivity.FieldName.EnterText(filed1);
            JitActivity.CreateField.Tap();
            JitActivity.AddField.Tap();
            JitActivity.FieldName.EnterText(filed2);
            JitActivity.CreateField.Tap();
            JitActivity.AddField.Tap();
            JitActivity.FieldName.EnterText(filed3);
            JitActivity.CreateField.Tap();
            JitActivity.AddField.Tap();
            JitActivity.FieldName.EnterText(filed4);
            JitActivity.CreateField.Tap();
            JitActivity.FieldList.VerifyElementCountByClass(5, "android.widget.Button");
            //add single row
            JitActivity.AddRow.Tap();
            JitActivity.TableList.VerifyElementCountById(1, "row_layout");
            //Set num row
            JitActivity.RowNumber.ClearText();
            JitActivity.RowNumber.EnterText("6");
            JitActivity.SetRowNum.Tap();
            JitActivity.TableList.VerifyElementCountById(6, "row_layout");
            JitActivity.RowNumber.ClearText();
            JitActivity.RowNumber.EnterText("4");
            JitActivity.SetRowNum.Tap();
            JitActivity.TableList.VerifyElementCountById(4, "row_layout");
            //populate row
            for (int i = 0; i < 4; i++)
            {
                JitActivity.PopulateCell(i, 0, (i + 1).ToString());
                JitActivity.VerifyCell(i, 0, (i + 1).ToString());
            }
            //set formula
            JitActivity.FieldList.FindAndTap(filed3);
            CommonOperation.HideKeyboard();
            JitFieldDialog.SetFormula.Tap();
            JitFormulaDialog.FormulaExpression.EnterText("20 + [Field1]");
            JitFormulaDialog.Ok.Tap();
            JitFieldDialog.Ok.Tap();
            for (int i = 0; i < 4; i++)
            {
                JitActivity.VerifyCell(i, 2, (i + 21).ToString("0.0", System.Globalization.CultureInfo.InvariantCulture));
            }
            //update formula
            JitActivity.FieldList.FindAndTap(filed3);
            CommonOperation.HideKeyboard();
            JitFieldDialog.SetFormula.Tap();
            CommonOperation.DeleteText(JitFormulaDialog.FormulaExpression.GetInternalElement());
            JitFormulaDialog.FormulaExpression.EnterText("20 * [Field1]");
            JitFormulaDialog.Ok.Tap();
            JitFieldDialog.Ok.Tap();
            for (int i = 0; i < 4; i++)
            {
                JitActivity.VerifyCell(i, 2,
                    ((i + 1)*20).ToString("0.0", System.Globalization.CultureInfo.InvariantCulture));
            }
            //delete formula
            JitActivity.FieldList.FindAndTap(filed3);
            CommonOperation.HideKeyboard();
            JitFieldDialog.SetFormula.Tap();
            CommonOperation.DeleteText(JitFormulaDialog.FormulaExpression.GetInternalElement());
            JitFormulaDialog.Ok.Tap();
            JitFieldDialog.Ok.Tap();
            ConsoleMessage.TakeScreen("Verify, formula is deleted");
            //create group
            JitActivity.Groups.Tap();
            JitGroupCreateDialog.GroupNumber.ClearText();
            JitGroupCreateDialog.GroupNumber.EnterText("2");
            JitGroupCreateDialog.GroupSize.ClearText();
            JitGroupCreateDialog.GroupSize.EnterText("2");
            JitGroupCreateDialog.Create.Tap();
            JitGroupActivity.ClickEditGroupName("Group 1");
            JitGroupNameDialog.GroupName.EnterText("MyGroup1");
            JitGroupNameDialog.Ok.Tap();
            JitGroupActivity.ClickEditGroupName("Group 2");
            JitGroupNameDialog.GroupName.EnterText("MyGroup2");
            JitGroupNameDialog.Ok.Tap();
            JitGroupActivity.ClickExpand("MyGroup1");
            JitGroupActivity.ClickExpand("MyGroup2");
            JitGroupActivity.MoveGroupRow(0, 1, 1, 1);
            JitGroupActivity.VerifyFroupRow(1, 3);
            JitGroupActivity.MoveToNotInGroup(1, 1);
            JitGroupActivity.NotInGroupList.VerifyElementCountById(1, "row_layout");
            JitGroupActivity.MoveFromNotInGroupToGroup(0, 0, 1);
            JitGroupActivity.NotInGroupList.VerifyElementCountById(0, "row_layout");
            ConsoleMessage.TakeScreen("Jit group activity");
            JitGroupActivity.Close.Tap();
            //show/hide functionality
            JitActivity.ShowGroups.Tap();
            JitActivity.VerifyGroupIsShown(0, "MyGroup1 - 1");
            JitActivity.VerifyGroupIsShown(1, "MyGroup1 - 2");
            JitActivity.VerifyGroupIsShown(2, "MyGroup2 - 1");
            JitActivity.VerifyGroupIsShown(3, "MyGroup2 - 2");
            JitActivity.HideGroups.Tap();
            JitActivity.VerifyGroupIsHide();
            //show/hide functionality
            JitActivity.ShowGroups.Tap();
            JitActivity.Ungroup.Tap();
            JitUngroupDialog.Ungroup.Tap();
            JitActivity.VerifyGroupIsHide();
            JitActivity.Close.Tap();

            //add second jit
            string secFiled1 = "Second_Field1";
            string secFiled2 = "Second_Field2";

            FlowActivity.AddElement(element);
            FlowActivity.OpenElement(1);
            //select key field
            JitActivity.SelectKeyField.Tap();
            JitSelectKeyDialog.KeyList.FindAndTap(key);
            JitActivity.FieldList.VerifyElementCountByClass(5, "android.widget.Button");
            JitActivity.AddField.Tap();
            JitActivity.FieldName.EnterText(secFiled1);
            JitActivity.CreateField.Tap();
            JitActivity.AddField.Tap();
            JitActivity.FieldName.EnterText(secFiled2);
            JitActivity.CreateField.Tap();
            JitActivity.FieldList.VerifyElementCountByClass(7, "android.widget.Button");
            //populate row
            for (int i = 0; i < 4; i++)
            {
                JitActivity.PopulateCell(i, 0, (i + 100).ToString());
                JitActivity.VerifyCell(i, 0, (i + 100).ToString());
            }
            //show/hide functionality
            JitActivity.HideAll.Tap();
            JitActivity.FieldList.VerifyElementCountByClass(3, "android.widget.Button");
            JitActivity.ShowAll.Tap();
            JitActivity.FieldList.VerifyElementCountByClass(7, "android.widget.Button");
            JitActivity.Close.Tap();
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
                ConsoleMessage.StartTest("Jit Test: Clean up", "Jit");
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
