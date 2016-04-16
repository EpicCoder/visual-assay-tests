using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Plate
{
    class PlateEditLabelDialog
    {
        static string ActivityName = "Plate Edit Label Dialo";

        public static AndroidButton ChangeColor
        {
            get
            {
                string id = "color_button";
                string name = "Change color";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText TagName
        {
            get
            {
                string id = "name";
                string name = "Tag Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidEditText LabelName
        {
            get
            {
                string id = "long_name";
                string name = "Label Name";
                return new AndroidEditText(id, name, ActivityName);
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
