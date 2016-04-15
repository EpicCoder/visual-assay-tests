using System;
using OpenQA.Selenium.Appium.Android;

namespace android_test.ActivityElement
{
    class BaseAndroidElement
    {
        protected AndroidElement Element;
        public string ActivityName;
        public string ElementName;
        public string ElementId;

        protected BaseAndroidElement(string elementId, string elementName, string activityName)
        {
            ElementName = elementName;
            ActivityName = activityName;
            ElementId = elementId;
            try
            {
                Element = Appium.Instance.Driver.FindElementById(ElementId);
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't find element with name: {1} and android id: {2}",
                    ActivityName, ElementName, ElementId), ex);
                throw;
            }
        }

        protected BaseAndroidElement(string elementName, string activityName)
        {
            ElementName = elementName;
            try
            {
                Element = Appium.Instance.Driver.FindElementByName(ElementName);
                ActivityName = activityName;
                ElementId = "No id";
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't find element with name: {1}", ActivityName, ElementName), ex);
                throw;
            }
        }

        public AndroidElement GetInternalElement()
        {
            return Element;
        }
    }
}
