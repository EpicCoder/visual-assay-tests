using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowSelectAssayDialog
    {
        static string ActivityName = "Select Assay For Flow Dialog";

        public static AndroidList AssayList
        {
            get
            {
                string id = "assays_list";
                string name = "Assay List";
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

        public static AndroidButton NewAssay
        {
            get
            {
                string id = "button1";
                string name = "New Assay";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
