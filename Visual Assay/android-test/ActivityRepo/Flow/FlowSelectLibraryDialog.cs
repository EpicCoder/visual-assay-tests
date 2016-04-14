using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowSelectLibraryDialog
    {
        static string ActivityName = "Flow Choose Library Dialog";

        public static AndroidList LibraryList
        {
            get
            {
                string id = "select_dialog_listview";
                string name = "Library List";
                return new AndroidList(id, name, ActivityName);
            }
        }
    }
}
