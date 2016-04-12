using System;

namespace android_test.ActivityElement
{
    class AndroidCheckbox : BaseAndroidElement
    {
        public AndroidCheckbox(string elementId, string elementName, string activityName) : base(elementId, elementName, activityName)
        {
        }

        public void Tap()
        {
            try
            {
                Element.Click();
                ConsoleMessage.Pass(String.Format("{0}. Tap on checkbox with name: {1}",
                    ActivityName, ElementName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't tap on checkbox with name: {1} and android id: {2}",
                    ActivityName, ElementName, ElementId), ex);
                throw;
            }
        }
    }
}
