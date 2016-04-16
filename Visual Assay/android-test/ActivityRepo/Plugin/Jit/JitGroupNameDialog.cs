using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitGroupNameDialog
    {
        static string ActivityName = "Jit Group Edit Name Dialog";

        public static AndroidButton Ok
        {
            get
            {
                string id = "button1";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "CancelOk";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText GroupName
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
