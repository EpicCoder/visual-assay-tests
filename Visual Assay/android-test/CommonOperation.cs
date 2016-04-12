using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
