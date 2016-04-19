using System;
using android_test.ActivityElement;
using NUnit.Framework;

namespace android_test.ActivityRepo.Library
{
    class LibraryPropertyDialog
    {
        static string ActivityName = "Library Element Property Dialog";

        public static AndroidCheckbox Required
        {
            get
            {
                string id = "property_required";
                string name = "Is Required";
                return new AndroidCheckbox(id, name, ActivityName);
            }
        }

        public static AndroidButton Ok
        {
            get
            {
                string id = "button_edit_ok";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button_edit_cancel";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText PropertyName
        {
            get
            {
                string id = "property_name";
                string name = "Property Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidEditText PropertyValue
        {
            get
            {
                string id = "property_value";
                string name = "Property Value";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidLabel PropertyType
        {
            get
            {
                string id = "property_type";
                string name = "Property Type";
                return new AndroidLabel(id, name, ActivityName);
            }
        }

        public static void VerifyPropertyType(string expectedText)
        {
            try
            {
                string currentText = PropertyType.GetInternalElement().FindElementById("text1").Text;
                Assert.True(currentText.Contains(expectedText),
                    "Element text: " + currentText + " not contain expected: " + expectedText);
                ConsoleMessage.Pass(
                    String.Format("{0}. Verify current element type: {1} equal to expected: {2}",
                        ActivityName, currentText, expectedText));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        "{0}. Verify current element type not equal to expected: {2}",
                        ActivityName, expectedText), ex);
                throw;
            }
        }
    }
}
