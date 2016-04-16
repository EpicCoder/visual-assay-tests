using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Flow
{
    class FlowSelectNesting
    {
        static string ActivityName = "Select Flow For Nesting Dialog";

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidList ItemList
        {
            get
            {
                string id = "assays_list";
                string name = "Item List";
                return new AndroidList(id, name, ActivityName);
            }
        }
    }
}
