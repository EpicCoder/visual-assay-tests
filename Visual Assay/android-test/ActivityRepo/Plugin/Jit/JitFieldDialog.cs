using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitFieldDialog
    {
        static string ActivityName = "Jit Field Name";

        public static AndroidButton Ok
        {
            get
            {
                string id = "button1";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Delete
        {
            get
            {
                string id = "button3";
                string name = "Delete Field";
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

        public static AndroidEditText FieldName
        {
            get
            {
                string id = "field_name_edit";
                string name = "Field Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidButton ShowTimestamp
        {
            get
            {
                string id = "field_timestamp_button";
                string name = "Show Time Stamp";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton SetFormula
        {
            get
            {
                string id = "edit_formula";
                string name = "Set Formula";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
