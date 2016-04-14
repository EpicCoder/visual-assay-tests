using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowPermissionErrorDialog
    {
        static string ActivityName = "Flow Permission Error Dialog";

        public static AndroidLabel DialogName
        {
            get
            {
                string id = "alertTitle";
                string name = "Dialog Header";
                return new AndroidLabel(id, name, ActivityName);
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
    }
}
