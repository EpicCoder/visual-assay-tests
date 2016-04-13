using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace android_test.ActivityElement
{
    class AndroidList : BaseAndroidElement
    {
        public AndroidList(string elementId, string elementName, string activityName) : base(elementId, elementName, activityName)
        {
        }

        public AndroidElement FindElement(string elementName)
        {
            try
            {
                string selector = "new UiScrollable(new UiSelector().resourceId(\"com.assayrt:id/" + ElementId +
                                  "\")).scrollIntoView(text(\"" + elementName + "\"))";
                AndroidElement element = (AndroidElement) Element.FindElementByAndroidUIAutomator(selector);
                ConsoleMessage.Pass(String.Format("{0}. Find element with name: {1} in list: {2}",
                    ActivityName, elementName, ElementName));
                return element;

            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't find element with name: {1} in list: {2} id: {3}",
                    ActivityName, elementName, ElementName, ElementId), ex);
                throw;
            }
        }

        public void FindAndTap(string elementName)
        {
            try
            {
                string selector = "new UiScrollable(new UiSelector().resourceId(\"com.assayrt:id/" + ElementId +
                                  "\")).scrollIntoView(text(\"" + elementName + "\"))";
                AndroidElement element = (AndroidElement) Element.FindElementByAndroidUIAutomator(selector);
                ConsoleMessage.Pass(String.Format("{0}. Find and tap on element with name: {1} in list: {2}",
                    ActivityName, elementName, ElementName));
                element.Click();
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Can't find and tap on element with name: {1} in list: {2} id: {3}",
                        ActivityName, elementName, ElementName, ElementId), ex);
                throw;
            }
        }

        public void VerifyElementCountByClass(int expectedCount, string className)
        {
            try
            {
                CommonOperation.Delay(1);
                int currentCount = Element.FindElementsByClassName(className).Count;
                Assert.AreEqual(expectedCount, currentCount,
                    "Current element count: " + currentCount + " not equal to expected: " + expectedCount);
                ConsoleMessage.Pass(
                    String.Format("{0}. Verify. Current element count in list with name {1}, equl to expected: {2}",
                        ActivityName, ElementName, expectedCount));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        "{0}. Can't verify. Current element count in list with name {1}, NOT equl to expected: {2}",
                        ActivityName, ElementName, expectedCount), ex);
                throw;
            }
        }

        public void VerifyElementCountById(int expectedCount, string id)
        {
            try
            {
                CommonOperation.Delay(1);
                int currentCount = Element.FindElementsById(id).Count;
                Assert.AreEqual(expectedCount, currentCount,
                    "Current element count: " + currentCount + " not equal to expected: " + expectedCount);
                ConsoleMessage.Pass(
                    String.Format("{0}. Verify. Current element count in list with name {1}, equl to expected: {2}",
                        ActivityName, ElementName, expectedCount));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        "{0}. Can't verify. Current element count in list with name {1}, NOT equl to expected: {2}",
                        ActivityName, ElementName, expectedCount), ex);
                throw;
            }
        }
    }
}
