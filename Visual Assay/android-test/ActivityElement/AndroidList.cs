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
                return element;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void FindAndTap(string elementName)
        {
            try
            {
                string selector = "new UiScrollable(new UiSelector().resourceId(\"com.assayrt:id/" + ElementId +
                                  "\")).scrollIntoView(text(\"" + elementName + "\"))";
                AndroidElement element = (AndroidElement)Element.FindElementByAndroidUIAutomator(selector);
                element.Click();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void VerifyElementCountByClass(int expectedCount, string className)
        {
            try
            {
                int currentCount = Element.FindElementsByClassName(className).Count;
                Assert.AreEqual(expectedCount, currentCount,
                    "Current element count: " + currentCount + " not equal to expected: " + expectedCount);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void VerifyElementCountById(int expectedCount, string id)
        {
            try
            {
                int currentCount = Element.FindElementsById(id).Count;
                Assert.AreEqual(expectedCount, currentCount,
                    "Current element count: " + currentCount + " not equal to expected: " + expectedCount);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
