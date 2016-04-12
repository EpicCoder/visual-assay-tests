using System;

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
    }
}
