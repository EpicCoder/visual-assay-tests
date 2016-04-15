using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitCreateDialog
    {
        static string ActivityName = "Jit Create Group Dialog";

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Create
        {
            get
            {
                string id = "button1";
                string name = "Create";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText GroupNumber
        {
            get
            {
                string id = "number_groups";
                string name = "Group Count";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidEditText GroupSize
        {
            get
            {
                string id = "number_rows";
                string name = "Group size";
                return new AndroidEditText(id, name, ActivityName);
            }
        }
    }
}
