using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Plate
{
    class PlateWellEditDialog
    {
        static string ActivityName = "Plate Edit Well Dialog";

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Ok
        {
            get
            {
                string id = "button1";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText Name
        {
            get
            {
                string className = "android.widget.EditText";
                try
                {
                    return new AndroidEditText(
                        Appium.Instance.Driver.FindElementByClassName(className), ActivityName);
                }
                catch (Exception ex)
                {
                    ConsoleMessage.Fail(String.Format("{0}. Can't find element by Class: {1}", ActivityName, className), ex);
                    throw;
                }

            }
        }
    }
}
