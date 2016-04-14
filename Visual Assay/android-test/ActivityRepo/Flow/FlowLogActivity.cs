using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowLogActivity
    {
        static string ActivityName = "Flow Log Activity";

        public static AndroidList LogList
        {
            get
            {
                string id = "flow_log_table";
                string name = "Flow Log List";
                return new AndroidList(id, name, ActivityName);
            }
        }
    }
}
