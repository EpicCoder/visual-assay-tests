using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowShareNestedDialog
    {
        static string ActivityName = "Flow Share with Nested";

        public static AndroidButton No
        {
            get
            {
                string id = "button2";
                string name = "No";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Yes
        {
            get
            {
                string id = "button1";
                string name = "Yes";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
