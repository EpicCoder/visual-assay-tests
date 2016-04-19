using System;
using System.Collections.ObjectModel;
using android_test.ActivityElement;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace android_test.ActivityRepo.Library
{
    class LibraryElementActivity
    {
        static string ActivityName = "Library Element Activity";

        public static AndroidButton Ok
        {
            get
            {
                string id = "library_element_ok";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Delete
        {
            get
            {
                string id = "library_element_delete";
                string name = "Delete";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "library_element_cancel";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Image
        {
            get
            {
                string id = "library_element_icon";
                string name = "Image";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText ElementName
        {
            get
            {
                string id = "library_element_name";
                string name = "Element Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidLabel ElementType
        {
            get
            {
                string id = "library_element_spinner";
                string name = "Element Type";
                return new AndroidLabel(id, name, ActivityName);
            }
        }

        public static AndroidList PropertyList
        {
            get
            {
                string id = "properties_list";
                string name = "Property List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton AddProperty
        {
            get
            {
                string id = "property_add";
                string name = "Add Property";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static void VerifyElementType(string expectedText)
        {
            try
            {
                string currentText = ElementType.GetInternalElement().FindElementById("text1").Text;
                Assert.True(currentText.Contains(expectedText),
                    "Element text: " + currentText + " not contain expected: " + expectedText);
                ConsoleMessage.Pass(
                    String.Format("{0}. Verify current element type: {1} equal to expected: {2}",
                        ActivityName,  currentText, expectedText));
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

        private static AndroidElement GetPropertyItem(string propertyName)
        {
            try
            {
                AndroidElement propItem = null;
                ReadOnlyCollection<AppiumWebElement> propertyItems = PropertyList.GetInternalElement().FindElementsByClassName("android.widget.RelativeLayout");
                foreach (var element in propertyItems)
                {
                    string currPropName = element.FindElementById("property_name").Text;
                    if (currPropName.Contains(propertyName))
                    {
                        propItem = (AndroidElement) element;
                        return propItem;
                    }
                }
                Assert.Fail("Can't find property with name: " + propertyName);
                return null;
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format(
                        "{0}. Can't find property.", ActivityName), ex);
                throw;
            }
        }


        public static void VerifyPropertyValue(string propertyName, string expectedValue)
        {
            try
            {
                string currValue = GetPropertyItem(propertyName).FindElementById("property_value").Text;
                Assert.AreEqual(currValue, expectedValue,
                    "Current property value: " + currValue + " not equal to expected: " + expectedValue);
                ConsoleMessage.Pass(
                    String.Format("{0}. Current value: {1} of property: {2} equal to expected: {3}", ActivityName, currValue, propertyName, expectedValue));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Current value of property: {2} equal to expected: {3}", ActivityName, propertyName, expectedValue), ex);
                throw;
            }
        }

        public static void OpenProperty(string propertyName)
        {
            try
            {
                GetPropertyItem(propertyName).Click();
                ConsoleMessage.Pass(
                    String.Format("{0}. Open property with name: {1}", ActivityName, propertyName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Can't open property with name: {1}", ActivityName, propertyName), ex);
                throw;
            }
        }

        public static void VerifyPropertyMarkAsRequired(string propertyName)
        {
            try
            {
                Assert.Greater(GetPropertyItem(propertyName).FindElementsById("property_required").Count, 0,
                    "Can't find required mark on property: " + propertyName);
                ConsoleMessage.Pass(
                    String.Format("{0}. Verify, property with name: {1} marked as required", ActivityName, propertyName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Can't verify, property with name: {1} marked as required", ActivityName, propertyName), ex);
                throw;
            }
        }

        public static void DeleteProperty(string propertyName)
        {
            try
            {
                GetPropertyItem(propertyName).FindElementById("property_delete").Click();
                ConsoleMessage.Pass(
                    String.Format("{0}. Click delete property: {1}", ActivityName, propertyName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Can't click delete property: {1}", ActivityName, propertyName), ex);
                throw;
            }
        }

        public static void SwapProperty(string prop1, string prop2)
        {
            try
            {
                AndroidElement dragItem = GetPropertyItem(prop1);
                AndroidElement dropItem = GetPropertyItem(prop2);
                TouchAction action = new TouchAction(Appium.Instance.Driver);
                action.Press(dragItem).Wait(1500).MoveTo(dragItem).Wait(1500).MoveTo(dropItem).Wait(1500).Release();
                MultiAction multi = new MultiAction(Appium.Instance.Driver);
                multi.Add(action).Perform();
                ConsoleMessage.Pass(
                    String.Format("{0}. Swap property. Drag property: {1} and drop to property: {2}", ActivityName, prop1, prop2));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Can't swap property. Drag property: {1} and drop to property: {2}", ActivityName, prop1, prop2), ex);
                throw;
            }
        }

        public static void VerifyPropertyAtPosition(int propPos, string expectedProp)
        {
            try
            {
                string currText = PropertyList.GetInternalElement().FindElementsByClassName("android.widget.RelativeLayout")[propPos]
                    .FindElementById("property_name").Text;
                Assert.AreEqual(expectedProp, currText, "Current property name: " + currText + " not equal to expected: " + expectedProp);
                ConsoleMessage.Pass(
                    String.Format("{0}. Verify property at position: {1} has name {2}", ActivityName, propPos, expectedProp));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(
                    String.Format("{0}. Verify property at position: {1} has name {2}", ActivityName, propPos, expectedProp), ex);
                throw;
            }
        }

    }
}
