using System;
using System.Threading;
using NUnit.Framework;

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
