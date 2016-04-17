using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Pulse
{
    class PulseCustomizeViewDialog
    {
        static string ActivityName = "Pulse Customize View";

        public static AndroidList PropertyList
        {
            get
            {
                string id = "table_columns";
                string name = "Property List";
                return new AndroidList(id, name, ActivityName);
            }
        }

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

        public static void ClickOnPropertyCheckbox(string propName)
        {
            try
            {
                var propList = PropertyList.GetInternalElement().FindElementsByClassName("android.widget.TableRow");
                foreach (var element in propList)
                {
                    string currProp = element.FindElementByClassName("android.widget.TextView").Text;
                    if (currProp.Contains(propName))
                    {
                        element.FindElementByClassName("android.widget.CheckBox").Click();
                        break;
                    }
                }


                ConsoleMessage.Pass(String.Format("{0}. Tap on checkbox on property with name: {1}",
                    ActivityName, propName));
            }
            catch (Exception ex)
            {
                ConsoleMessage.Fail(String.Format("{0}. Can't tap on checkbox on property with name: {1}",
                    ActivityName, propName), ex);
                throw;
            }
        }
    }
}
