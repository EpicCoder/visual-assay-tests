using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitSelectKeyDialog
    {
        static string ActivityName = "Jit Select Key Dialog";

        public static AndroidList KeyList
        {
            get
            {
                string id = "select_dialog_listview";
                string name = "Key List";
                return new AndroidList(id, name, ActivityName);
            }
        }
    }
}
