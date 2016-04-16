using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitGroupActivity
    {
        static string ActivityName = "Jit Group Activity";

        public static AndroidButton Close
        {
            get
            {
                string id = "close_button";
                string name = "Close";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton NotInGroupArea
        {
            get
            {
                string id = "not_in_group_layout";
                string name = "Not in group";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidList NotInGroupList
        {
            get
            {
                string id = "not_in_group_table";
                string name = "Not In Group List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList FieldList
        {
            get
            {
                string id = "fields_buttons_layout";
                string name = "Field List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList GroupList
        {
            get
            {
                string id = "groups_grid";
                string name = "Group List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static void ClickEditGroupName(string groupName)
        {
            try
            {
                var groupList = GroupList.GetInternalElement().FindElementsById("tools_layout");
                foreach (var element in groupList)
                {
                    string name = element.FindElementById("group_name").Text;
                    if (name.Contains(groupName))
                    {
                        element.FindElementById("button_edit_name").Click();
                        break;
                    }
                }
                ConsoleMessage.Pass(String.Format("{0}. Tap edit group name button in group with name: {1}",
                    ActivityName, groupName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't tap edit group name button in group with name: {1}",
                    ActivityName, groupName), ex);
                throw;
            }
        }

        public static void ClickExpand(string groupName)
        {
            try
            {
                var groupList = GroupList.GetInternalElement().FindElementsById("tools_layout");
                foreach (var element in groupList)
                {
                    string name = element.FindElementById("group_name").Text;
                    if (name.Contains(groupName))
                    {
                        element.FindElementById("group_expand_button").Click();
                        break;
                    }
                }
                ConsoleMessage.Pass(String.Format("{0}. Tap edit group name button in group with name: {1}",
                    ActivityName, groupName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't tap edit group name button in group with name: {1}",
                    ActivityName, groupName), ex);
                throw;
            }
        }

        public static void MoveGroupRow(int fromGroup, int pickRow, int toGroup, int dropRow)
        {
            try
            {
                AndroidElement dragItem = null;
                AndroidElement dropItem = null;
                //get drag item
                var root = Appium.Instance.Driver.FindElementById("groups_grid");
                var groupList = root.FindElementsById("table");
                dragItem =
                    (AndroidElement) groupList[fromGroup].FindElementsByClassName("android.widget.TableRow")[pickRow];
                //get drop item
                dropItem =
                    (AndroidElement) groupList[toGroup].FindElementsByClassName("android.widget.TableRow")[dropRow];
                //drag n drop
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dragItem).MoveTo(dropItem).Release().Perform();

                ConsoleMessage.Pass(
                    String.Format(
                        "{0}. Take row at position: {1} from group at pos: {2} and drop to row at position: {3}" +
                        " in group at pos: {4}",
                        ActivityName, pickRow, fromGroup, dropRow, toGroup));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        String.Format(
                            "{0}. Take row at position: {1} from group at pos: {2} and drop to row at position: {3}" +
                            " in group at pos: {4}",
                            ActivityName, pickRow, fromGroup, dropRow, toGroup)), ex);
                throw;
            }
        }

        public static void MoveToNotInGroup(int fromGroup, int pickRow)
        {
            try
            {
                AndroidElement dragItem = null;
                AndroidElement dropItem = null;
                //get drag item
                var root = Appium.Instance.Driver.FindElementById("groups_grid");
                var groupList = root.FindElementsById("table");
                dragItem =
                    (AndroidElement)groupList[fromGroup].FindElementsByClassName("android.widget.TableRow")[pickRow];
                //get drop item
                dropItem = NotInGroupArea.GetInternalElement();
                //drag n drop
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dragItem).MoveTo(dropItem).Release().Perform();

                ConsoleMessage.Pass(
                    String.Format(
                        "{0}. Take row at position: {1} from group at pos: {2} and drop to : {3}" ,
                        ActivityName, pickRow, fromGroup, NotInGroupList.ElementName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        String.Format(
                            "{0}. Take row at position: {1} from group at pos: {2} and drop to row at position: {3}",
                            ActivityName, pickRow, fromGroup, NotInGroupList.ElementName)), ex);
                throw;
            }
        }

        public static void MoveFromNotInGroupToGroup(int pickRow, int toGroup, int dropRow)
        {
            try
            {
                AndroidElement dragItem = null;
                AndroidElement dropItem = null;
                //get drag item
                var root = Appium.Instance.Driver.FindElementById("groups_grid");
                var groupList = root.FindElementsById("table");
                dropItem =
                    (AndroidElement)groupList[toGroup].FindElementsByClassName("android.widget.TableRow")[dropRow];
                //get drop item
                dragItem = (AndroidElement) NotInGroupList.GetInternalElement().FindElementsById("row_layout")[pickRow];
                //drag n drop
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dragItem).MoveTo(dropItem).Release().Perform();

                ConsoleMessage.Pass(
                    String.Format(
                        "{0}. Take row at position: {1} from group not in group and drop to group at position: {2} at row: {3}",
                        ActivityName, pickRow, toGroup, dropRow));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        String.Format(
                        "{0}. Can't take row at position: {1} from group not in group and drop to group at position: {2} at row: {3}",
                        ActivityName, pickRow, toGroup, dropRow)), ex);
                throw;
            }
        }

        public static void VerifyFroupRow(int groupNum, int expectedRow)
        {
            try
            {
                //get drag item
                var root = Appium.Instance.Driver.FindElementById("groups_grid");
                var groupList = root.FindElementsById("table");
                int currentCount = groupList[groupNum].FindElementsByClassName("android.widget.TableRow").Count - 1;
                Assert.AreEqual(expectedRow, currentCount,
                    "Current table count: " + currentCount + " not equal to expected: " + expectedRow);



                ConsoleMessage.Pass(
                    String.Format(
                        "{0}. Verify row count in group at position: {1}, expected count: {2}",
                        ActivityName, groupNum, expectedRow));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        String.Format(
                        "{0}. Can't Verify row count in group at position: {1}, expected count: {2}",
                        ActivityName, groupNum, expectedRow)), ex);
                throw;
            }
        }
    }
}
