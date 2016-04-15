using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Plugin.Jit
{
    class JitFormulaDialog
    {
        static string ActivityName = "Jit Formula Dialog";

        public static AndroidList FieldList
        {
            get
            {
                string id = "table";
                string name = "Field List";
                return new AndroidList(id, name, ActivityName);
            }
        }

        public static AndroidEditText FormulaExpression
        {
            get
            {
                string id = "formula_edit";
                string name = "Formula text";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidButton Ok
        {
            get
            {
                string id = "button_ok";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "button_cancel";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }
    }
}
