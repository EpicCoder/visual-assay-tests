using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace android_test.ActivityRepo
{
    class ComboBoxItemDialog
    {
        static string ActivityName = "ComboBox Item Dialog";

        public static void FindAndTap(string element)
        {
            try
            {
                Appium.Instance.Driver.FindElementByClassName("android.widget.ListView")
                    .FindElementByName(element)
                    .Click();
                ConsoleMessage.Pass(String.Format("{0}. Find element with name: {1} and select",
                    ActivityName, element));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't find element with name: {1} and select",
                    ActivityName, element), ex);
                throw;
            }
        }
    }
}
