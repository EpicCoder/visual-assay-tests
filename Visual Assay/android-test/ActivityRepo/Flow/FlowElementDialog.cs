using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Flow
{
    class FlowElementDialog
    {
        static string ActivityName = "Flow Element Dialog";

        public static AndroidList PropertyList
        {
            get
            {
                string id = "properties_list";
                string name = "Property List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton AddProperty
        {
            get
            {
                string id = "property_add";
                string name = "Add Property";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText Notes
        {
            get
            {
                string id = "element_notes";
                string name = "Notes";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button_properties_edit_cancel";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Ok
        {
            get
            {
                string id = "button_properties_edit_ok";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton OpenPlugin
        {
            get
            {
                string id = "go_to_plugin_button";
                string name = "Open Plugin";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText ElementName
        {
            get
            {
                string id = "properties_title";
                string name = "Element Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidButton Done
        {
            get
            {
                string id = "button_execution_done";
                string name = "Done";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Skip
        {
            get
            {
                string id = "button_skip";
                string name = "Skip";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Repeat
        {
            get
            {
                string id = "button_repeat";
                string name = "Repeat";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton SelectFlow
        {
            get
            {
                string id = "select_flow";
                string name = "Select Flow";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ShowNested
        {
            get
            {
                string id = "move_to_flow";
                string name = "Move To Flow";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
