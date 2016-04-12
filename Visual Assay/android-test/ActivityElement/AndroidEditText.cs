using System;
using NUnit.Framework;

namespace android_test.ActivityElement
{
    class AndroidEditText : BaseAndroidElement
    {
        public AndroidEditText(string elementId, string elementName, string activityName) : base(elementId, elementName, activityName)
        {
        }

        public void ClearText()
        {
            try
            {
                Element.Click();
                Element.Clear();
                CommonOperation.HideKeyboard();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public void EnterText(string text)
        {
            try
            {
                Element.Click();
                Element.SendKeys(text);
                CommonOperation.HideKeyboard();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void VerifyText(string expectedText)
        {
            try
            {
                Assert.True(Element.Text.Contains(expectedText),
                    "Element text: " + Element.Text + " not contain expected: " + expectedText);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
