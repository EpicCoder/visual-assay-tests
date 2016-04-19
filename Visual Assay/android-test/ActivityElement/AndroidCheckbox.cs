using System;
using System.Threading;
using NUnit.Framework;
using static System.Boolean;

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

        public void VerifyStatus(bool expectedStatus)
        {
            try
            {
                Thread.Sleep(700);
                bool currStatus = Parse(Element.GetAttribute("checked"));
                Assert.AreEqual(expectedStatus, currStatus,
                    "Current checkbox status: " + currStatus + " not equalt to expected: " + expectedStatus);
                ConsoleMessage.Pass(String.Format("{0}. Current checbox status: {1}",
                    ActivityName, expectedStatus));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Current checbox status not equal to expected: {1}",
                    ActivityName, expectedStatus), ex);
                throw;
            }
        }
    }
}
