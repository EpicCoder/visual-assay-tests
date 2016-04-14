using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowPropertyDialog
    {
        static string ActivityName = "Flow Property Dialog";

        public static AndroidCheckbox IsRequired
        {
            get
            {
                string id = "property_required";
                string name = "IsRequired";
                return new AndroidCheckbox(id, name, ActivityName);
            }
        }

        public static AndroidButton Ok
        {
            get
            {
                string id = "button_edit_ok";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button_edit_cancel";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText PropertyName
        {
            get
            {
                string id = "property_name";
                string name = "Property Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidEditText PropertyValue
        {
            get
            {
                string id = "property_value";
                string name = "Property Value";
                return new AndroidEditText(id, name, ActivityName);
            }
        }
    }
}
