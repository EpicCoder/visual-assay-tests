using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowPluginSelectFlowDialog
    {
        static string ActivityName = "Flow Object: Select Flow Dialog";

        public static AndroidList AssayList
        {
            get
            {
                string id = "assays_list";
                string name = "List";
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

        public static AndroidButton Back
        {
            get
            {
                string id = "button3";
                string name = "Back";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
