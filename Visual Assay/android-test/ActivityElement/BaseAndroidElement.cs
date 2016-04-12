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
            try
            {
                Element = Appium.Instance.Driver.FindElementById(elementId);
                ElementName = elementName;
                ActivityName = activityName;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected BaseAndroidElement(string elementName, string activityName)
        {
            try
            {
                Element = Appium.Instance.Driver.FindElementByName(elementName);
                ElementName = elementName;
                ActivityName = activityName;
                ElementId = "No id";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public AndroidElement GetInternalElement()
        {
            return Element;
        }
    }
}
