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
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
