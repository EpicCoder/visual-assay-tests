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
                ConsoleMessage.Pass(String.Format("{0}. Clear text in textbox with name: {1}",
                    ActivityName, ElementName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't clear text in textbox with name: {1} and android id: {2}",
                    ActivityName, ElementName, ElementId), ex);
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
                ConsoleMessage.Pass(String.Format("{0}. Enter text in textbox with name: {1}, Text: {2}",
                    ActivityName, ElementName, text));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't enter text in textbox with name: {1} and android id: {2}",
                    ActivityName, ElementName, ElementId), ex);
                throw;
            }
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
