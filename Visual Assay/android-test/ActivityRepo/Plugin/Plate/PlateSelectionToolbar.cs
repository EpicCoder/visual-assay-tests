using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Plate
{
    class PlateSelectionToolbar
    {
        static string ActivityName = "Plate selection toolbar";

        public static AndroidButton DiluteRight
        {
            get
            {
                string id = "dilute_right";
                string name = "Dilute Right";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton DiluteDown
        {
            get
            {
                string id = "dilute_down";
                string name = "Dilute Down";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton FillRight
        {
            get
            {
                string id = "fill_right";
                string name = "Fill Right";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton FillDown
        {
            get
            {
                string id = "fill_down";
                string name = "Fill Down";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Reset
        {
            get
            {
                string id = "reset_selection";
                string name = "Reset Selection";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
