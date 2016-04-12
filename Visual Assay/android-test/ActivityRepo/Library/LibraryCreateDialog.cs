using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Library
{
    class LibraryCreateDialog
    {
        static string ActivityName = "Library Create Dialog";

        public static AndroidButton Cancel
        {
            get
            {
                string id = "library_create_cancel";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Create
        {
            get
            {
                string id = "library_create_ok";
                string name = "Create";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText LibraryName
        {
            get
            {
                string id = "library_create_name";
                string name = "Library Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }
    }
}
