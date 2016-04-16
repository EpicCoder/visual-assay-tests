using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Plate
{
    class PlateSheetDeleteDialog
    {
        static string ActivityName = "Plate Sheet Delete Dialog";

        public static AndroidButton Delete
        {
            get
            {
                string id = "button1";
                string name = "Delete";
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
    }
}
