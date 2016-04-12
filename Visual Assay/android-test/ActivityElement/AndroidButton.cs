using System;

namespace android_test.ActivityElement
{
    class AndroidButton : BaseAndroidElement
    {
        public AndroidButton(string elementId, string elementName, string activityName) : base(elementId, elementName, activityName)
        {
        }

        public AndroidButton(string elementName, string activityName) : base(elementName, activityName)
        {
        }

        public void Tap()
        {
            try
            {
                Element.Click();
                ConsoleMessage.Pass(String.Format("{0}. Tap on button with name: {1}",
                    ActivityName, ElementName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't tap on button with name: {1} and android id: {2}",
                    ActivityName, ElementName, ElementId), ex);
                throw;
            }
        }
    }
}
