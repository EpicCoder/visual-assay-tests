using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace android_test.ActivityRepo.Flow
{
    class FlowActivity
    {
        static string ActivityName = "Flow Activity";

        public static AndroidList ElementList
        {
            get
            {
                string id = "flow_view";
                string name = "Flow Element List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList LibraryList
        {
            get
            {
                string id = "flow_tools";
                string name = "Library List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton Share
        {
            get
            {
                string id = "flow_share";
                string name = "Share";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Log
        {
            get
            {
                string id = "flow_log";
                string name = "Log";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Report
        {
            get
            {
                string id = "flow_report";
                string name = "Report";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton DeleteFlow
        {
            get
            {
                string id = "flow_delete";
                string name = "Delete Flow";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Start
        {
            get
            {
                string id = "button_flow_start_timer";
                string name = "Start";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ChangeLibrary
        {
            get
            {
                string id = "current_library";
                string name = "Change Library";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Trash
        {
            get
            {
                string id = "flow_trashcan";
                string name = "Trash Can";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidLabel FlowName
        {
            get
            {
                string id = "flow_name";
                string name = "Flow Name";
                return new AndroidLabel(id, name, ActivityName);
            }
        }

        public static AndroidButton ShareOk
        {
            get
            {
                string id = "flow_share_ok";
                string name = "Share Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton CancelShare
        {
            get
            {
                string id = "flow_share_cancel";
                string name = "Cancel Share";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Permission
        {
            get
            {
                string id = "flow_permissions";
                string name = "Permission";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidElement FlowNav()
        {
            return Appium.Instance.Driver.FindElementById("flow_navigation_bar");
        }

        public static void AddElement(string elementName)
        {
            AndroidElement dragItem = LibraryList.FindElement(elementName);
            AndroidElement dropItem = ElementList.GetInternalElement();
            try
            {
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).MoveTo(dropItem).Release().Perform();
                ConsoleMessage.Pass(String.Format("{0}. Add element to flow. Drag item: {1} and drop to: {2}",
                    ActivityName, elementName, ElementList.ElementName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't add element to flow. Can't drag item: {1} and drop to: {2}",
                    ActivityName, elementName, ElementList.ElementName), ex);
                throw;
            }
        }

        public static void OpenElement(string elementName)
        {
            try
            {
                var elementList = ElementList.GetInternalElement().FindElementsByClassName("android.widget.EditText");
                for (int i = 0; i < elementList.Count; i++)
                {
                    var element = elementList[i];
                    if (element.Text.Contains(elementName))
                    {
                        ElementList.GetInternalElement().FindElementsById("document_icon")[i].Click();
                        break;
                    }
                }
                ConsoleMessage.Pass(String.Format("{0}. Find and tap on flow element with name: {1} in flow list",
                    ActivityName, elementName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Can't Find and tap on flow element with name: {1} in flow list",
                        ActivityName, elementName), ex);
                throw;
            }
        }

        public static void OpenElement(int pos)
        {
            try
            {
                ElementList.GetInternalElement().FindElementsById("document_icon")[pos].Click();
                ConsoleMessage.Pass(String.Format("{0}. Find and tap on flow element at position: {1} in flow list",
                    ActivityName, pos));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Find and tap on flow element at position: {1} in flow list",
                    ActivityName, pos), ex);
                throw;
            }
        }

        public static void DeleteElement(string elementName)
        {
            AndroidElement dragItem = ElementList.FindElement(elementName);
            AndroidElement dropItem = Trash.GetInternalElement();
            try
            {
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dragItem).MoveTo(dropItem).Release().Perform();
                ConsoleMessage.Pass(String.Format("{0}. Delete element from flow. Drag item: {1} and drop to: {2}",
                    ActivityName, elementName, Trash.ElementName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't delete element from flow. Can't drag item: {1} and drop to: {2}",
                    ActivityName, elementName, Trash.ElementName), ex);
                throw;
            }
        }

        public static void TapOnFlowElement(int position)
        {
            try
            {
                ElementList.GetInternalElement().FindElementsById("document_icon")[position].Click();
                ConsoleMessage.Pass(String.Format("{0}. Tap flow element by position: {1}",
                    ActivityName, position));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Tap flow element by position: {1}",
                    ActivityName, position), ex);
                throw;
            }
        }

        public static void VerifyElementMarkAsBlocked(int position)
        {
            try
            {
                var currentText = ElementList.GetInternalElement().FindElementsById("document_name")[position].Text;
                Assert.True(String.IsNullOrEmpty(currentText),
                    "Current element text name: " + currentText + " but should be empty");
                ConsoleMessage.Pass(String.Format("{0}. Verify, element at position: {1} is blocked",
                    ActivityName, position));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't verify element at position: {1} is blocked",
                    ActivityName, position), ex);
                throw;
            }
        }

        public static void VerifyElementName(int position, string expectedName)
        {
            try
            {
                var currentText = ElementList.GetInternalElement().FindElementsById("document_name")[position].Text;
                Assert.True(currentText.Contains(expectedName),
                    String.Format("Current element name: {0} at position {1} not contain expected: {2}", currentText,
                        position, expectedName));
                ConsoleMessage.Pass(String.Format("{0}. Verify, element at position: {1} contain name: {2}",
                    ActivityName, position, expectedName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Verify FAIL, element at position: {1} not contain name: {2}",
                    ActivityName, position, expectedName), ex);
                throw;
            }
        }
    }
}
