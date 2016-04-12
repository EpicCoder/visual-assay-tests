using System;
using NUnit.Framework;

namespace android_test.ActivityElement
{
    class AndroidLabel : BaseAndroidElement
    {
        public AndroidLabel(string elementId, string elementName, string activityName) : base(elementId, elementName, activityName)
        {
        }

        public void VerifyText(string expectedText)
        {
            string currentText = Element.Text;
            try
            {
                Assert.True(currentText.Contains(expectedText),
                    "Element text: " + Element.Text + " not contain expected: " + expectedText);
                ConsoleMessage.Pass(
                    String.Format("{0}. Verify TextBox with name: {1} current text: {2} contain expected text: {3}",
                        ActivityName, ElementName, currentText, expectedText));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        "{0}. Can't Verify TextBox with name: {1} current text: {2} not contain expected text: {3}",
                        ActivityName, ElementName, currentText, expectedText), ex);
                throw;
            }
        }
    }
}
