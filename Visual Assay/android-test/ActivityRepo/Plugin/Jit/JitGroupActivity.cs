using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitGroupActivity
    {
        static string ActivityName = "Jit Group Activity";

        public static AndroidButton Close
        {
            get
            {
                string id = "close_button";
                string name = "Close";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
