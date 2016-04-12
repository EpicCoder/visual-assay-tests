using System;
using System.Threading;

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
            }
            catch (Exception ex)
            {

            }
        }
    }
}
