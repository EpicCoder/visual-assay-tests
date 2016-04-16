using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Plate
{
    class PlateCreateSheetDialog
    {
        static string ActivityName = "Plate Create Sheet Library";

        public static AndroidEditText Name
        {
            get
            {
                string id = "name";
                string name = "Plate Name";
                return new AndroidEditText(id, name, ActivityName);
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

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button2";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Delete
        {
            get
            {
                string id = "button3";
                string name = "Delete";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
