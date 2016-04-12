using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Library
{
    class LibraryDeleteElementDialog
    {
        static string ActivityName = "Library Delete Element Dialog";

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "No";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Delete
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
