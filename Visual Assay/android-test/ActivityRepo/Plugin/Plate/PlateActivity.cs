using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;

namespace android_test.ActivityRepo.Plugin.Plate
{
    class PlateActivity
    {
        static string ActivityName = "Plate Activity";

        public static AndroidLabel GridSize
        {
            get
            {
                string id = "plate_size";
                string name = "Plate Size";
                return new AndroidLabel(id, name, ActivityName);
            }
        }

        public static AndroidList LabelList
        {
            get
            {
                string id = "components_list";
                string name = "Label List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton NewLabel
        {
            get
            {
                string id = "add_new_button";
                string name = "New Label";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ToolSelect
        {
            get
            {
                string id = "button_select";
                string name = "Tool Select";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ToolEdit
        {
            get
            {
                string id = "button_edit";
                string name = "Tool Edit";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ToolClear
        {
            get
            {
                string id = "button_clear";
                string name = "Tool Clear";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText PlateName
        {
            get
            {
                string id = "plate_name";
                string name = "Plate Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidButton AddSheet
        {
            get
            {
                string id = "add_new_sheet";
                string name = "Add New Sheet";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidList SheetList
        {
            get
            {
                string id = "tabs";
                string name = "Sheet List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton PutToLibrary
        {
            get
            {
                string id = "put_to_library";
                string name = "Push To Library";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static void ChangeSize(string size)
        {
            try
            {
                GridSize.GetInternalElement().Click();
                Appium.Instance.Driver.FindElementByAndroidUIAutomator(
                    "new UiSelector().resourceId(\"android:id/text1\").className(\"android.widget.CheckedTextView\")" +
                    ".text(\"" + size + "\")").Click();
                ConsoleMessage.Pass(String.Format("{0}. Change plate size to: {1}",
                    ActivityName, size));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't change plate size to: {1}",
                    ActivityName, size), ex);
                throw;
            }
        }

        public static void VerifyCurrentSize(string expectedSize)
        {
            try
            {
                string currentSize = GridSize.GetInternalElement().FindElementById("text1").Text;
                Assert.AreEqual(expectedSize, currentSize,
                    "Current plate grid size: " + GridSize + " not equal to expected: " + expectedSize);
                ConsoleMessage.Pass(String.Format("{0}. Verify plate size, expected size: {1}",
                    ActivityName, expectedSize));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't verify plate szie, expected size: {1}",
                    ActivityName, expectedSize), ex);
                throw;
            }
        }

        public static void FillWell(int xStart, int yStart, int xEnd, int yEnd)
        {
            try
            {
                Appium.Instance.Driver.Swipe(xStart, yStart, xEnd, xEnd, 5000);
                ConsoleMessage.Pass(
                    String.Format("{0}. Fill wells by coordinate. StartPoint[x: {1}, y:{2} ]. EndPoint[x: {3}, y:{4} ]",
                        ActivityName, xStart, yStart, xEnd, yEnd));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        "{0}. Can't fill wells by coordinate. StartPoint[x: {1}, y:{2} ]. EndPoint[x: {3}, y:{4} ]",
                        ActivityName, xStart, yStart, xEnd, yEnd), ex);
                throw;
            }
        }

        public static void TapByCoordinate(int x, int y)
        {
            try
            {
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(x,y).Release().Perform();
                ConsoleMessage.Pass(
                    String.Format("{0}. Tap by coordinate. Point[x: {1}, y:{2} ]", ActivityName, x, y));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Tap by coordinate. Point[x: {1}, y:{2} ]", ActivityName, x, y), ex);
                throw;
            }
        }
    }
}
