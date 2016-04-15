using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitActivity
    {
        static string ActivityName = "Jit Activity";

        public static AndroidButton Close
        {
            get
            {
                string id = "close_button";
                string name = "Close";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText JitName
        {
            get
            {
                string id = "title";
                string name = "Jit Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidButton AddKey
        {
            get
            {
                string id = "add_new_field";
                string name = "Add Key";
                return new AndroidButton(name, ActivityName);
            }
        }

        public static AndroidButton AddField
        {
            get
            {
                string id = "add_new_field";
                string name = "Add Field";
                return new AndroidButton(name, ActivityName);
            }
        }

        public static AndroidButton HideAll
        {
            get
            {
                string id = "show_all";
                string name = "Hide All";
                return new AndroidButton(name, ActivityName);
            }
        }

        public static AndroidButton ShowAll
        {
            get
            {
                string id = "show_all";
                string name = "Show All";
                return new AndroidButton(name, ActivityName);
            }
        }

        public static AndroidButton ShowGroups
        {
            get
            {
                string id = "by_groups";
                string name = "Show Groups";
                return new AndroidButton(name, ActivityName);
            }
        }

        public static AndroidButton HideGroups
        {
            get
            {
                string id = "by_groups";
                string name = "Hide Groups";
                return new AndroidButton(name, ActivityName);
            }
        }

        public static AndroidButton SelectKeyField
        {
            get
            {
                string id = "select_exists_field";
                string name = "Select Key Field";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Groups
        {
            get
            {
                string id = "groups_button";
                string name = "Groups";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Ungroup
        {
            get
            {
                string id = "ungroup_button";
                string name = "Ungroup";
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

        public static AndroidButton CreateField
        {
            get
            {
                string id = "field_name_edit_ok_button";
                string name = "Create Field";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "field_name_edit_cancel_button";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidList FieldList
        {
            get
            {
                string id = "table_header";
                string name = "Field List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidList TableList
        {
            get
            {
                string id = "table";
                string name = "Table List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidButton AddRow
        {
            get
            {
                string id = "add_new_row";
                string name = "Add Row";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText RowNumber
        {
            get
            {
                string id = "num_rows";
                string name = "Row Number Textbox";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidButton SetRowNum
        {
            get
            {
                string id = "set_num_rows";
                string name = "Set Row Num";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ExportToCsv
        {
            get
            {
                string id = "export_to_csv";
                string name = "Export To CSV";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton ExportTemplate
        {
            get
            {
                string id = "export_scale_template";
                string name = "Export Template";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton LoadFromTemplate
        {
            get
            {
                string id = "import_from_template";
                string name = "Load From Template";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
