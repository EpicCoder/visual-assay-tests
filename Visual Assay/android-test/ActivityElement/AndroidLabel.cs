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
