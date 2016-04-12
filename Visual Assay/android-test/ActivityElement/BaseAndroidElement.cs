using System;
using OpenQA.Selenium.Appium.Android;

namespace android_test.ActivityElement
{
    class BaseAndroidElement
    {
        protected AndroidElement Element;
        protected string ActivityName;
        protected string ElementName;
        protected string ElementId;

        protected BaseAndroidElement(string elementId, string elementName, string activityName)
        {
            ElementName = elementName;
            ActivityName = activityName;
            try
            {
                Element = Appium.Instance.Driver.FindElementById(elementId);
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't find element with name: {1} and android id: {2}",
                    ActivityName, elementName, elementId), ex);
                throw;
            }
        }

        protected BaseAndroidElement(string elementName, string activityName)
        {
            ElementName = elementName;
            try
            {
                Element = Appium.Instance.Driver.FindElementByName(elementName);
                ActivityName = activityName;
                ElementId = "No id";
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't find element with name: {1}", ActivityName, elementName), ex);
                throw;
            }
        }

        public AndroidElement GetInternalElement()
        {
            return Element;
        }
    }
}
