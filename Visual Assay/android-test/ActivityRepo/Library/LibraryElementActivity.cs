using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android_test.ActivityElement;

namespace android_test.ActivityRepo.Library
{
    class LibraryElementActivity
    {
        static string ActivityName = "Library Element Activity";

        public static AndroidButton Ok
        {
            get
            {
                string id = "library_element_ok";
                string name = "Ok";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Delete
        {
            get
            {
                string id = "library_element_delete";
                string name = "Delete";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Cancel
        {
            get
            {
                string id = "library_element_cancel";
                string name = "Cancel";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton Image
        {
            get
            {
                string id = "library_element_icon";
                string name = "Image";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidEditText ElementName
        {
            get
            {
                string id = "library_element_name";
                string name = "Element Name";
                return new AndroidEditText(id, name, ActivityName);
            }
        }

        public static AndroidButton ElementType
        {
            get
            {
                string id = "library_element_spinner";
                string name = "Element Type";
                return new AndroidButton(id, name, ActivityName);
            }
        }

        public static AndroidButton PropertyList
        {
            get
            {
                string id = "properties_list";
                string name = "Property List";
                return new AndroidButton(id, name, ActivityName);
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
    }
}
