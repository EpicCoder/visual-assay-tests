using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace android_test
{
    class CommonOperation
    {
        public static void HideKeyboard()
        {
            try
            {
                Appium.Instance.Driver.HideKeyboard();
            }
            catch (Exception ex)
            {

            }
        }

        public static void Delay(int delayInSec)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(delayInSec));
                ConsoleMessage.Pass(string.Format("Time delay: {0} sec.", delayInSec));
            }
            catch (Exception ex)
            {

            }
        }

        public static void DeleteText(AndroidElement element)
        {
            try
            {
                int length = element.Text.Length;
                for (int i = 0; i < length; i++)
                {
                    Appium.Instance.Driver.PressKeyCode(22); // "KEYCODE_DPAD_RIGHT"
                }
                for (int i = 0; i < length; i++)
                {
                    Appium.Instance.Driver.PressKeyCode(67); // "KEYCODE_DEL"
                }
                ConsoleMessage.Pass(string.Format("Custom clear text logic"));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(string.Format("Custom clear text logic. Can't clear text"), ex);
            }
        }

        public static void Fail()
        {
            try
            {
                Assert.Fail("Fail test");
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(string.Format("Shoudl fail"), ex);
                throw;
            }
        }
    }
}
