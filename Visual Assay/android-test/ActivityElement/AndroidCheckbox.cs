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
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
